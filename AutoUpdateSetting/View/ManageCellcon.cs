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
    public partial class ManageCellcon : UserControl
    {
        private List<ApplicationData> c_ApplicationDatas;
        private List<CellconData> c_CellOnServer;
        private MainForm c_MainFrom;
        public ManageCellcon(MainForm mainForm,List<ApplicationData> applicationDatas,List<CellconData> cellconDatas)
        {
            InitializeComponent();
            c_ApplicationDatas = applicationDatas;// GetData();
            UpdateTreeView(c_ApplicationDatas);
            c_MainFrom = mainForm;
            c_CellOnServer = cellconDatas;//GetCellconData();
            AddListComboBoxCellconName(c_CellOnServer);
        }
        //private List<CellconData> GetCellconData()
        //{
        //    List<CellconData> cellconDataList = new List<CellconData>();
        //    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.APCSProDB))
        //    {
        //        conn.Open();

        //        SqlCommand command = conn.CreateCommand();

        //        // Must assign both transaction object and connection
        //        // to Command object for a pending local transaction
        //        command.Connection = conn;

        //        try
        //        {
        //            command.CommandText = "select  [id],[name],[version] from [cellcon].[application_sets]";
        //            //command.Parameters.AddWithValue("@file", fileData.Data);
        //            var result = command.ExecuteReader();
        //            while (result.Read())
        //            {
        //                CellconData cellconData = new CellconData();
        //                cellconData.CellconId = int.Parse(result["id"].ToString());
        //                cellconData.CellconName = result["name"].ToString();
        //                cellconData.CellconVersion = result["version"].ToString();
        //                cellconDataList.Add(cellconData);
        //            }
        //            //fileData.BinaryId = int.Parse(fileId.ToString());
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.ToString());
        //        }
        //        conn.Close();
        //    }
        //    return cellconDataList;
        //}
        private void AddListComboBoxCellconName(List<CellconData> cellconDatas)
        {
            comboBoxCellconName.Items.Clear();
            var appList = cellconDatas.Select(x => new { x.CellconName }).Distinct().OrderBy(y => y.CellconName).ToList();
            foreach (var item in appList)
            {
                comboBoxCellconName.Items.Add(item.CellconName);
            }
        }
        //private List<ApplicationData> GetData()
        //{
        //    List<ApplicationData> app_Data = new List<ApplicationData>();
        //    //(Properties.Settings.Default.APCSProDB))
        //    using (SqlConnection con = new SqlConnection(Properties.Settings.Default.APCSProDB))
        //    {
        //        con.Open();
        //        SqlCommand command = con.CreateCommand();
        //        command.CommandText = "select [applications].[id],[applications].[name],[applications].[version],[applications].[update_at] from [cellcon].[applications] " +
        //            "order by [applications].[update_at] desc";
        //        var result = command.ExecuteReader();
        //        while (result.Read())
        //        {
        //            ApplicationData applicationData = new ApplicationData();
        //            applicationData.ApplictionName = result["name"].ToString();
        //            applicationData.ApplictionVersion = result["version"].ToString();
        //            applicationData.ApplicationId = int.Parse(result["id"].ToString());
        //            List<FileData> fileDatas = new List<FileData>();
        //            using (SqlConnection con2 = new SqlConnection(Properties.Settings.Default.APCSProDB))
        //            {
        //                con2.Open();
        //                SqlCommand command2 = con2.CreateCommand();
        //                command2.CommandText = "select app.id as app_id,app.[name] as [app_name],app.[version] as app_version " +
        //                " ,app.update_at as app_update_at,  [file].id as [file_id], " +
        //                " [file].directory as file_directory,[file].[name] as [file_name]," +
        //                " [file].update_at as file_update_at,[file].[version] as file_version " +
        //                " ,[file].binary_id as file_binary_id " +
        //                " from  cellcon.applications as app " +
        //                " inner join cellcon.applications_file as app_file on app_file.application_id = app.id " +
        //                " inner join cellcon.files as [file] on[file].id = app_file.[file_id] " +
        //                " where app.id = @app_id";
        //                command2.Parameters.AddWithValue(@"app_id", applicationData.ApplicationId);
        //               var result2 = command2.ExecuteReader();
        //                while (result2.Read())
        //                {
        //                    FileData fileData = new FileData();
        //                    fileData.FileId = (int)result2["file_id"];
        //                    fileData.Name = (string)result2["file_name"];
        //                    fileData.Directory = (string)result2["file_directory"]; 
        //                    fileData.FileVersion = (string)result2["file_version"];
        //                    fileDatas.Add(fileData);
        //                }
        //            }
        //            applicationData.FileDataList = fileDatas;
        //            app_Data.Add(applicationData);
        //        }
              
        //    }
        //    return app_Data;
        //}
        private void UpdateTreeView(List<ApplicationData> applicationDatas)
        {
            treeView1.Nodes.Clear();
            //Add Program List
            var programNameList = applicationDatas.Select(x => new { x.ApplictionName }).OrderBy(x=>x.ApplictionName).Distinct().ToList();
            int i = 0;
            foreach (var app in programNameList)
            {
                treeView1.Nodes.Add(app.ApplictionName);

                var appDatas = applicationDatas.Where(x => x.ApplictionName == app.ApplictionName);
                int j = 0;
                foreach (var item in appDatas)
                {
                   
                    treeView1.Nodes[i].Nodes.Add(item.ApplictionVersion);
                    foreach (var fileItem in item.FileDataList)
                    {
                        treeView1.Nodes[i].Nodes[j].Nodes.Add(fileItem.Name + ":" + fileItem.FileVersion);
                        
                    }
                    j++;
                }
                i++;
            }

            //RemoveCheckBoxes Root Node
            RemoveCheckBoxes(treeView1);
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

        private List<TreeNode> GetNodes(TreeNode node,int rootOpen = 0)
        {
            rootOpen++;
            List<TreeNode> nodes = new List<TreeNode>();
            if ((node.Nodes.Count > 0 && rootOpen != 2) || rootOpen == 3)
                nodes.Add(node);
            foreach (TreeNode n in node.Nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    nodes.AddRange(GetNodes(n,rootOpen));
                }
            }
            return nodes;
        }
        #endregion
        private SetDataResult SetData(List<ApplicationData> appDatas, string cellconName, string cellconVersion)
        {
            //string cellconName = textBoxCellconName.Text;
            //string cellconVersion = textBoxCellconVersion.Text;
            if (cellconName == "" || cellconVersion == "")
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

                    command.CommandText = "insert into [APCSProDB].[cellcon].[application_sets] ([name],[version]) values (@name,@version); SELECT SCOPE_IDENTITY()";
                    if (command.Parameters.Count > 0)
                    {
                        command.Parameters.Clear();
                    }
                    command.Parameters.AddWithValue("@name", cellconName);
                    command.Parameters.AddWithValue("@version", cellconVersion);
                    var cellId = command.ExecuteScalar();

                    foreach (ApplicationData app in appDatas)
                    {

                        if (command.Parameters.Count > 0)
                        {
                            command.Parameters.Clear();
                        }
                        command.CommandText = "insert into [APCSProDB].[cellcon].[application_application_sets] ([application_set_id],[application_id]) values (@cellconId,@appId)";

                        command.Parameters.AddWithValue("@cellconId", int.Parse(cellId.ToString()));
                        command.Parameters.AddWithValue("@appId", app.ApplicationId);

                        int result = command.ExecuteNonQuery();

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

        private void GetTreeNodeSetToApplicationData(TreeNodeCollection treeNodeCollection, List<ApplicationData> applicationData)
        {

            foreach (var item in treeNodeCollection)
            {
                TreeNode treeNode = (TreeNode)item;
                if(treeNode.Checked)
                {

                    var applicationList = applicationData.Where(x => x.ApplictionName == treeNode.Parent.Text && x.ApplictionVersion == treeNode.Text && treeNode.Checked).ToList();
                    foreach (var file in applicationList)
                    {
                        file.ApplicationSelect = true;
                        // machine.ApplicationSetId = c_CellconList.Where(x => x.CellconName == comboBoxCellconName.Text);
                    }
                }
                if (treeNode.Nodes.Count > 0)
                {
                    GetTreeNodeSetToApplicationData(treeNode.Nodes, applicationData);
                }
                //else
                //{

                //    var applicationList = applicationData.Where(x => x.ApplictionName == treeNode.Parent.Text && x.ApplictionVersion == treeNode.Text && treeNode.Checked).ToList();
                //    foreach (var file in applicationList)
                //    {
                //        file.ApplicationSelect = true;
                //        // machine.ApplicationSetId = c_CellconList.Where(x => x.CellconName == comboBoxCellconName.Text);
                //    }
                //}
            }
        }
        private bool ExitFile(string cellconName, string cellconVersion)
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
                    command.CommandText = "select [name],[version] from [APCSProDB].[cellcon].[application_sets] where [name] = @cellconName and [version] = @cellconVersion";
                    command.Parameters.AddWithValue("@cellconName", cellconName);
                    command.Parameters.AddWithValue("@cellconVersion", cellconVersion);
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
            string cellconName = comboBoxCellconName.Text;
            string cellconVersion = textBoxCellconVersion.Text;
            if (string.IsNullOrEmpty(cellconName) || string.IsNullOrEmpty(cellconVersion))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน!!");
                return;
            }
            if (!ExitFile(cellconName, cellconVersion))
            {
                MessageBoxDialog.ShowMessageDialog("Manage Application", string.Format("Cellcon:{0} \r\n Version:{1} มีอยู่ในระบบแล้ว", cellconName, cellconVersion), "Error");
                return;
            }

            //remove select file
            var appDatas = c_ApplicationDatas.Where(x => x.ApplicationSelect);
            foreach (var app in appDatas)
            {
                app.ApplicationSelect = false;
            }
            GetTreeNodeSetToApplicationData(treeView1.Nodes, c_ApplicationDatas);
            List<string> dataList = new List<string>();

            var fileDataList = c_ApplicationDatas.Where(x => x.ApplicationSelect == true).ToList();
            foreach (var item in fileDataList)
            {
                dataList.Add(item.ApplictionName + " ,version:" + item.ApplictionVersion);
            }
            FormConfirmRegisterProgram frm = new FormConfirmRegisterProgram(dataList);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //Save to data base
                //SetData(fileDataList);
                SetDataResult result = SetData(fileDataList, cellconName, cellconVersion);
                if (!result.IsPass)
                    MessageBoxDialog.ShowMessageDialog("Manage Cellcon", result.Cause, "Fail");
                else
                {
                    MessageBoxDialog.ShowMessageDialog("Manage Cellcon", "Save Succeed", "Succeed");
                    c_MainFrom.panelMain.Controls.Clear();
                }

               
//this.DialogResult = DialogResult.OK;
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

        private void ComboBoxCellconName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tmp = c_CellOnServer.Where(x => x.CellconName == comboBoxCellconName.Text).OrderByDescending(y => y.CellconId).FirstOrDefault();
            if (tmp == null)
            {
                textBoxCellconVersion.Text = "1.0.0.0";
                return;
            }
            var cellconVersion = tmp.CellconVersion;
            var countVersion = cellconVersion.Split('.');
            string fileNewVersion = countVersion[0] + "." + countVersion[1] + "." + countVersion[2] + "." + (int.Parse(countVersion[3]) + 1);
            textBoxCellconVersion.Text = fileNewVersion;
        }
    }
}
