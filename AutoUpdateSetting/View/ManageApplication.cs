using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdateSetting.Model;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using MessageDialog;

namespace AutoUpdateSetting.View
{
    public partial class ManageApplication : UserControl
    {
        private ApplicationData c_ApplictionData;
        private List<ApplicationData> c_AppOnServer;
        private MainForm c_MainFrom;

        public ManageApplication(MainForm mainForm,List<FileData> fileDatas,List<ApplicationData> applicationDatas)
        {
            InitializeComponent();
            c_ApplictionData = new ApplicationData();
            c_MainFrom = mainForm;
            c_ApplictionData.FileDataList = fileDatas; //GetData();
            c_AppOnServer = applicationDatas;// GetApplicationData();
            comboBox1.DataSource = c_ApplictionData.FileDataList.Select(x => x.Directory).Distinct().ToList();
            AddListComboBoxProgramName(c_AppOnServer);
        }
        private void AddListComboBoxProgramName(List<ApplicationData> applicationDatas)
        {
            comboBoxProgramName.Items.Clear();
            var appList = applicationDatas.Select(x => new { x.ApplictionName }).Distinct().OrderBy(y => y.ApplictionName).ToList();
            foreach (var item in appList)
            {
                comboBoxProgramName.Items.Add(item.ApplictionName);
            }
        }
        //private List<ApplicationData> GetApplicationData()
        //{
        //    List<ApplicationData> appDataList = new List<ApplicationData>();
        //    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.APCSProDB))
        //    {
        //        conn.Open();

        //        SqlCommand command = conn.CreateCommand();

        //        // Must assign both transaction object and connection
        //        // to Command object for a pending local transaction
        //        command.Connection = conn;

        //        try
        //        {
        //            command.CommandText = "select  [id],[name],[version] from [cellcon].[applications]";
        //            //command.Parameters.AddWithValue("@file", fileData.Data);
        //            var result = command.ExecuteReader();
        //            while (result.Read())
        //            {
        //                ApplicationData appData = new ApplicationData
        //                {
        //                    ApplicationId = int.Parse(result["id"].ToString()),
        //                    ApplictionName = result["name"].ToString(),
        //                    ApplictionVersion = result["version"].ToString()
        //                };
        //                appDataList.Add(appData);
        //            }
        //            //fileData.BinaryId = int.Parse(fileId.ToString());
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.ToString());
        //        }
        //        conn.Close();
        //    }
        //    return appDataList;
        //}
        //private List<FileData> GetData()
        //{
        //    List<FileData> fileDatas = new List<FileData>();
        //    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.APCSProDB))
        //    {
        //        conn.Open();
        //        SqlCommand command = conn.CreateCommand();
        //        command.Connection = conn;

        //        try
        //        {
        //            command.CommandText = "select top(10000) [id],[name],[binary_id],[version],[directory],[update_at] from [APCSProDB].[cellcon].[files] order by update_at desc";
        //            //command.Parameters.AddWithValue("@file", "");
        //            var reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                FileData fileData = new FileData();
        //                fileData.FileId = int.Parse(reader["id"].ToString());
        //                fileData.Name = reader["name"].ToString();
        //                fileData.BinaryId = int.Parse(reader["binary_id"].ToString());
        //                fileData.FileVersion = reader["version"].ToString();
        //                fileData.Directory = reader["directory"].ToString();
        //                fileData.Date = DateTime.Parse(reader["update_at"].ToString());
        //                fileDatas.Add(fileData);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.ToString());
        //        }
        //        conn.Close();
        //    }
        //    return fileDatas;

        //}

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var data = c_ApplictionData.FileDataList.Where(x => x.Directory.Contains(((ComboBox)sender).SelectedValue.ToString())).ToList();
            UpdateTreeView(data);
        }

        private void UpdateTreeView(List<FileData> fileDataList)
        {
            treeView1.Nodes.Clear();
            //Add Program List
            var programNameList = fileDataList.Select(x => new { x.Name }).Distinct().ToList();
            int i = 0;
            foreach (var file in programNameList)
            {
                treeView1.Nodes.Add(file.Name);

                var fileDatas = fileDataList.Where(x => x.Name == file.Name).OrderByDescending(x=>x.FileId);
                foreach (var item in fileDatas)
                {
                    treeView1.Nodes[i].Nodes.Add(item.FileVersion + "|" + item.Directory);
                }
                i++;
            }
            //RemoveCheckBoxes Root Node
            RemoveCheckBoxes(treeView1);
        }
        #region RemoveCheck
        public const int TVIF_STATE = 0x8;
        public const int TVIS_STATEIMAGEMASK = 0xF000;
        public const int TV_FIRST = 0x1100;
        public const int TVM_SETITEM = TV_FIRST + 63;

        public struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public String lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);


        private void RemoveCheckBoxes(TreeView tree)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (TreeNode n in tree.Nodes)
            {
                if (n.Nodes.Count > 0)
                {
                    nodes.AddRange(GetNodes(n));
                }
            }

            foreach (TreeNode n in nodes)
            {
                TVITEM tvi = new TVITEM();
                tvi.hItem = n.Handle;
                tvi.mask = TVIF_STATE;
                tvi.stateMask = TVIS_STATEIMAGEMASK;
                tvi.state = 0;
                IntPtr lparam = Marshal.AllocHGlobal(Marshal.SizeOf(tvi));
                Marshal.StructureToPtr(tvi, lparam, false);
                SendMessage(this.treeView1.Handle, TVM_SETITEM, IntPtr.Zero, lparam);
            }
        }

        private List<TreeNode> GetNodes(TreeNode node)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            if (node.Nodes.Count > 0)
                nodes.Add(node);
            foreach (TreeNode n in node.Nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    nodes.AddRange(GetNodes(n));
                }
            }
            return nodes;
        }
        #endregion

        private bool ExitFile(string programName, string programVersion)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.APCSProDB))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = conn;

                try
                {
                    command.CommandText = "select [name],[version] from [APCSProDB].[cellcon].[applications] where [name] = @programName and [version] = @version";
                    command.Parameters.AddWithValue("@programName", programName);
                    command.Parameters.AddWithValue("@version", programVersion);
                    var result = command.ExecuteReader();
                    if (!result.HasRows)
                    {
                        conn.Close();
                        return true;
                    }
                    conn.Close();
                    return false;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.ToString());
                    return false;
                }
             
            }
          

        }
        private void PictureBoxRegister_Click(object sender, EventArgs e)
        {
            string programName = comboBoxProgramName.Text;
            string programVersion = textBoxProgramVersion.Text;
            if (string.IsNullOrEmpty(programName) || string.IsNullOrEmpty(programVersion))
            {
                MessageBoxDialog.ShowMessageDialog("Manage Application", "ข้อมูลไม่ครบ! กรุณาตรวจสอบอีกครั้ง", "Error");
                return;
            }
            if (!ExitFile(programName, programVersion))
            {
                MessageBoxDialog.ShowMessageDialog("Manage Application", string.Format("Program:{0} \r\n Version:{1} มีอยู่ในระบบแล้ว", programName, programVersion), "Error");
                return;
            }

            var fileData = c_ApplictionData.FileDataList.Where(x => x.FileSelect);
            foreach (var data in fileData)
            {
                data.FileSelect = false;
            }
            GetTreeNodeSetToFileData(treeView1.Nodes, c_ApplictionData.FileDataList);
            if (!c_ApplictionData.FileDataList.Where(x => x.FileSelect == true).Any())
            {
                MessageBoxDialog.ShowMessageDialog("Manage Application", "กรุณาเลือก file ที่จะทำการ Register", "Error");
                return;
            }

            List<string> dataList = new List<string>();
            var fileDataList = c_ApplictionData.FileDataList.Where(x => x.FileSelect == true).ToList();
            foreach (var item in fileDataList)
            {
                dataList.Add(item.Name + " |version:" + item.FileVersion + " |path:" + item.Directory);
            }
            FormConfirmRegisterProgram frm = new FormConfirmRegisterProgram(dataList);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //Save to data base
                SetDataResult result = SetData(fileDataList, programName, programVersion);
                if (!result.IsPass)
                    MessageBoxDialog.ShowMessageDialog("Manage Application", result.Cause, "Error");
                else
                {
                    MessageBoxDialog.ShowMessageDialog("Manage Application", "Save Succeed", "Succeed");
                    c_MainFrom.panelMain.Controls.Clear();
                }
                    

              //  this.DialogResult = DialogResult.OK;
            }
        }
        private SetDataResult SetData(List<FileData> fileDatas, string programName, string programVersion)
        {
            // string programName = textBoxProgramName.Text;
            // string programVersion = textBoxProgramVersion.Text;
            if (programName == "" || programVersion == "")
            {
                return new SetDataResult("ข้อมูลไม่ครบ! กรุณาตรวจสอบอีกครั้ง");
            }

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.APCSProDB))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                SqlTransaction sqlTransaction = conn.BeginTransaction("Transaction");
                try
                {
                    command.Connection = conn;
                    command.Transaction = sqlTransaction;

                    command.CommandText = "insert into  [APCSProDB].[cellcon].[applications] ([name],[version]) values (@name,@version); SELECT SCOPE_IDENTITY()";
                    if (command.Parameters.Count > 0)
                    {
                        command.Parameters.Clear();
                    }
                    command.Parameters.AddWithValue("@name", programName);
                    command.Parameters.AddWithValue("@version", programVersion);
                    var appId = command.ExecuteScalar();

                    foreach (FileData file in fileDatas)
                    {

                        if (command.Parameters.Count > 0)
                        {
                            command.Parameters.Clear();
                        }
                        command.CommandText = "insert into [cellcon].[applications_file] ([application_id],[file_id]) values (@applicationId,@fileId)";

                        command.Parameters.AddWithValue("@applicationId", int.Parse(appId.ToString()));
                        command.Parameters.AddWithValue("@fileId", file.FileId);

                        int result2 = command.ExecuteNonQuery();

                    }
                    command.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    command.Transaction.Rollback();
                    return new SetDataResult(ex.Message.ToString());
                }

                conn.Close();
                return new SetDataResult();
            }

        }

        private void GetTreeNodeSetToFileData(TreeNodeCollection treeNodeCollection, List<FileData> fileData)
        {
            foreach (var item in treeNodeCollection)
            {
                TreeNode treeNode = (TreeNode)item;
                if (treeNode.Nodes.Count > 0)
                {
                    GetTreeNodeSetToFileData(treeNode.Nodes, fileData);
                }
                else
                {
                    var fileList = fileData.Where(x => x.Name == treeNode.Parent.Text && x.FileVersion == treeNode.Text.Split('|')[0].Trim() && treeNode.Checked && x.Directory == comboBox1.Text.Trim()).ToList();
                    foreach (var file in fileList)
                    {
                        file.FileSelect = true;
                    }
                }
            }
        }

        private void pictureBoxRegister_MouseHover(object sender, EventArgs e)
        {
            pictureBoxRegister.Image = AutoUpdateSetting.Properties.Resources.button_resister_cursor;
        }

        private void pictureBoxRegister_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxRegister.Image = AutoUpdateSetting.Properties.Resources.button_resister;
        }

        private void ComboBoxProgramName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tmp = c_AppOnServer.Where(x => x.ApplictionName == comboBoxProgramName.Text).OrderByDescending(y => y.ApplicationId).FirstOrDefault();
            if (tmp == null)
            {
                textBoxProgramVersion.Text = "1.0.0.0";
                return;
            }
            var appVersion = tmp.ApplictionVersion;
            var countVersion = appVersion.Split('.');
            string fileNewVersion = countVersion[0] + "." + countVersion[1] + "." + countVersion[2] + "." + (int.Parse(countVersion[3]) + 1);
            textBoxProgramVersion.Text = fileNewVersion;
        }

        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // only do it if the node became checked:
            if (e.Node.Checked)
            {

                int i = 0;

                // for all the nodes in the tree...
                foreach (TreeNode cur_node in e.Node.TreeView.Nodes)
                {

                    if (e.Node.Parent == e.Node.TreeView.Nodes[i])
                    {
                        foreach (TreeNode item in e.Node.TreeView.Nodes[i].Nodes)
                        {
                            if (item != e.Node)
                            {
                                // ... uncheck them
                                item.Checked = false;

                            }

                        }
                        return;
                    }

                    i++;
                }
            }
            //if (e.Node.Checked)
            //{
            //    CheckedTreeNode(e.Node.TreeView.Nodes, e.Node);
            //}
        }
        private void CheckedTreeNode(TreeNodeCollection treeNodeCollection, TreeNode treeNode)
        {
            // for all the nodes in the tree...
            foreach (TreeNode cur_node in treeNodeCollection)
            {
                if (cur_node.Nodes.Count > 0)
                {
                     CheckedTreeNode(cur_node.Nodes, treeNode);
                }
                if (cur_node != treeNode)
                {
                    // ... uncheck them
                    cur_node.Checked = false;
                }
            }

        }
    }
}
