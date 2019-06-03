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
        private MainForm c_MainFrom;
        public ManageCellcon(MainForm mainForm)
        {
            InitializeComponent();
            c_ApplicationDatas = new List<ApplicationData>();
            var data = GetData();
            UpdateTreeView(data);
            c_MainFrom = mainForm;
        }
        private List<ApplicationData> GetData()
        {
            //(Properties.Settings.Default.APCSProDB))
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.APCSProDB))
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandText = "select [applications].[id],[applications].[name],[applications].[version],[applications].[update_at] from [cellcon].[applications] " +
                    "order by [applications].[update_at] desc";
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    ApplicationData applicationData = new ApplicationData();
                    applicationData.ApplictionName = result["name"].ToString();
                    applicationData.ApplictionVersion = result["version"].ToString();
                    applicationData.ApplicationId = int.Parse(result["id"].ToString());
                    c_ApplicationDatas.Add(applicationData);
                }
                //command.CommandText = "select [application_set].id,[application_set].name as cellcon_name,[application_set].version as cellcon_version " +
                //    "[application_set].update_at as cellcon_update  from [cellcon].[application_set] ";


            }
            return c_ApplicationDatas;
        }
        private void UpdateTreeView(List<ApplicationData> applicationDatas)
        {
            treeView1.Nodes.Clear();
            //Add Program List
            var programNameList = applicationDatas.Select(x => new { x.ApplictionName }).Distinct().ToList();
            int i = 0;
            foreach (var file in programNameList)
            {
                treeView1.Nodes.Add(file.ApplictionName);

                var fileDatas = applicationDatas.Where(x => x.ApplictionName.Contains(file.ApplictionName));
                foreach (var item in fileDatas)
                {
                    treeView1.Nodes[i].Nodes.Add(item.ApplictionVersion);
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
                if (treeNode.Nodes.Count > 0)
                {
                    GetTreeNodeSetToApplicationData(treeNode.Nodes, applicationData);
                }
                else
                {

                    var applicationList = applicationData.Where(x => x.ApplictionName == treeNode.Parent.Text && x.ApplictionVersion == treeNode.Text && treeNode.Checked).ToList();
                    foreach (var file in applicationList)
                    {
                        file.ApplicationSelect = true;
                        // machine.ApplicationSetId = c_CellconList.Where(x => x.CellconName == comboBoxCellconName.Text);
                    }
                }
            }
        }

        private void PictureBoxRegister_Click(object sender, EventArgs e)
        {
            string cellconName = textBoxCellconName.Text;
            string cellconVersion = textBoxCellconVersion.Text;
            if (string.IsNullOrEmpty(cellconName) || string.IsNullOrEmpty(cellconVersion))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน!!");
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

     
    }
}
