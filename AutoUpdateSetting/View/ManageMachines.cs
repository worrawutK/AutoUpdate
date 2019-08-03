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

namespace AutoUpdateSetting.View
{
    public partial class ManageMachines : UserControl
    {
        private List<CellconData> c_CellconList;
        private List<MachineData> c_MachineList;
        private MainForm c_MainFrom;
        public ManageMachines(MainForm mainForm,List<CellconData> cellconDatas)
        {
            InitializeComponent();
            c_MachineList = new List<MachineData>();
            c_CellconList = cellconDatas;//GetApplicationCellconData();
            UpdateComboBox(c_CellconList);
            var mcDatas = GetMachineData();
            UpdateTreeViewMachine(mcDatas);
            c_MainFrom = mainForm;
        }

        //private List<CellconData> GetApplicationCellconData()
        //{
        //    //(Properties.Settings.Default.APCSProDB))
        //    List<CellconData> cellconDatas = new List<CellconData>();
        //    using (SqlConnection con = new SqlConnection(Properties.Settings.Default.APCSProDB))
        //    {
        //        con.Open();
        //        SqlCommand command = con.CreateCommand();
        //        command.CommandText = "select [application_sets].[id],[application_sets].[name],[application_sets].[version],[application_sets].[update_at] from [cellcon].[application_sets] " +
        //            "order by [application_sets].[update_at] desc";
        //        var result = command.ExecuteReader();
        //        while (result.Read())
        //        {
        //            CellconData cellconData = new CellconData();
        //            cellconData.CellconName = result["name"].ToString();
        //            cellconData.CellconVersion = result["version"].ToString();
        //            cellconData.CellconId = int.Parse(result["id"].ToString());
        //            cellconDatas.Add(cellconData);
        //        }
        //        //command.CommandText = "select [application_set].id,[application_set].name as cellcon_name,[application_set].version as cellcon_version " +
        //        //    "[application_set].update_at as cellcon_update  from [cellcon].[application_set] ";


        //    }
        //    return cellconDatas;
        //}

        private List<MachineData> GetMachineData()
        {
            //(Properties.Settings.Default.APCSProDB))
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.APCSProDB))
            {
                con.Open();
                SqlCommand command = con.CreateCommand();
                command.CommandText = "select machines.id as machine_id , machines.name as machine_name ,models.id as model_id, " +
                    "models.name as model_name,group_models.machine_group_id as group_id,groups.name as group_name, " +
                    "cellcon.application_sets.name as cellcon_name,cellcon.application_sets.id as cellcon_id , cellcon.application_sets.version as cellcon_version " +
                    "from mc.machines inner join mc.models on models.id = machines.machine_model_id " +
                    "inner join mc.group_models on group_models.machine_model_id = machines.machine_model_id " +
                    "inner join mc.groups on groups.id = group_models.machine_group_id " +
                    "left join cellcon.application_sets on cellcon.application_sets.id = mc.machines.application_set_id ";
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    MachineData machineData = new MachineData();
                    machineData.MachineId = int.Parse(result["machine_id"].ToString());
                    machineData.MachineName = result["machine_name"].ToString();
                    machineData.ModelId = int.Parse(result["model_id"].ToString());
                    machineData.ModelName = result["model_name"].ToString();
                    machineData.GroupId = int.Parse(result["group_id"].ToString());
                    machineData.GroupName = result["group_name"].ToString();

                    int.TryParse(result["cellcon_id"].ToString(), out int cellId);
                    machineData.CellconId = cellId;
                    machineData.CellconName = result["cellcon_name"].ToString();

                    machineData.CellconVersion = result["cellcon_version"].ToString();
                    c_MachineList.Add(machineData);
                }
                //command.CommandText = "select [application_set].id,[application_set].name as cellcon_name,[application_set].version as cellcon_version " +
                //    "[application_set].update_at as cellcon_update  from [cellcon].[application_set] ";

            }
            return c_MachineList;
        }

        private void UpdateComboBox(List<CellconData> cellconApplicationDatas)
        {
            var cellcon = cellconApplicationDatas.Select(x => new { x.CellconName }).Distinct();
            foreach (var item in cellcon)
            {
                comboBoxCellconName.Items.Add(item.CellconName);
            }
        }
        private void UpdateTreeViewCellconVersion(List<CellconData> cellconApplicationDatas)
        {
            treeViewCellconVersion.Nodes.Clear();
            int i = 0;
            foreach (var file in cellconApplicationDatas.OrderByDescending(x=>x.CellconId))
            {
                treeViewCellconVersion.Nodes.Add(file.CellconVersion);
                var appList = file.ApplicationDataList.Select(x => new { x.ApplicationId, x.ApplictionName, x.ApplictionVersion }).Distinct().OrderBy(x=>x.ApplictionName);
                foreach (var app in appList)
                {
                    treeViewCellconVersion.Nodes[i].Nodes.Add(app.ApplictionName + "|" + app.ApplictionVersion);
                }
                i++;
            }
            RemoveCheckBoxes(treeViewCellconVersion);
        }
        private void UpdateTreeViewMachine(List<MachineData> machineDatas)
        {
            treeViewMachine.Nodes.Clear();
            var groups = machineDatas.Select(x => new { x.GroupName }).Distinct().OrderBy(x => x.GroupName).ToList();
            int i = 0;
            foreach (var file in groups)
            {
                treeViewMachine.Nodes.Add(file.GroupName);

                int j = 0;
                var models = machineDatas.Where(x => x.GroupName == file.GroupName).Select(x => new { x.ModelName }).Distinct().OrderBy(x => x.ModelName).ToList();
                foreach (var model in models)
                {
                    treeViewMachine.Nodes[i].Nodes.Add(model.ModelName);

                    var machines = machineDatas.Where(x => x.GroupName == file.GroupName && x.ModelName == model.ModelName).Select(x => new { x.MachineName, x.CellconName, x.CellconVersion }).Distinct().OrderBy(x => x.MachineName).ToList();
                    foreach (var mcNo in machines)
                    {
                        treeViewMachine.Nodes[i].Nodes[j].Nodes.Add(mcNo.MachineName + "|" + mcNo.CellconName + "|" + mcNo.CellconVersion);
                    }
                    j++;
                }
                i++;
            }

        }

        private void ComboBoxCellconName_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            var programData = c_CellconList.Where(x => x.CellconName == comboBox.Text).ToList();
            UpdateTreeViewCellconVersion(programData);
        }

        private void TreeViewMachine_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckTreeViewNode(e.Node, e.Node.Checked);
        }

        private void CheckTreeViewNode(TreeNode node, Boolean isChecked)
        {

            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = isChecked;

                if (item.Nodes.Count > 0)
                {
                    this.CheckTreeViewNode(item, isChecked);
                }
            }
        }

        private void SetMachine(TreeNodeCollection treeNodeCollection, List<MachineData> machineDatas)
        {
            foreach (var item in treeNodeCollection)
            {
                TreeNode treeNode = (TreeNode)item;
                if (treeNode.Nodes.Count > 0)
                {
                    SetMachine(treeNode.Nodes, machineDatas);
                }
                else
                {
                    var machineList = machineDatas.Where(x => x.MachineName == treeNode.Text.Split('|')[0] && treeNode.Checked).ToList();
                    foreach (var machine in machineList)
                    {
                        machine.MachineSelect = true;
                        // machine.ApplicationSetId = c_CellconList.Where(x => x.CellconName == comboBoxCellconName.Text);
                    }
                }
            }
        }
        private int? GetAppId(TreeNodeCollection treeNodeCollection, List<CellconData> cellconDatas)
        {
            foreach (var item in treeNodeCollection)
            {
                TreeNode treeNode = (TreeNode)item;
                var cellconData = cellconDatas.Where(x => x.CellconName == comboBoxCellconName.Text && x.CellconVersion == treeNode.Text && treeNode.Checked).ToList();
                if (cellconData.Count == 1)
                {
                    //MessageBoxDialog.ShowMessage(MethodBase.GetCurrentMethod().Name, "กรุณาตรวจสอบความถูกต้องของข้อมูล(" + cellconData.Count + ")", "Error");
                    //return null;
                    foreach (var app in cellconData)
                    {
                        return app.CellconId;
                    }
                }


            }
            return null;
        }
        private bool SetToDb(List<MachineData> machineDatas, int appId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.APCSProDB))
                {
                    con.Open();
                    SqlCommand command = con.CreateCommand();
                    foreach (MachineData mc in machineDatas)
                    {
                        if (command.Parameters.Count > 0)
                        {
                            command.Parameters.Clear();
                        }

                        command.CommandText = "Update mc.machines set application_set_id = @app_set_id where mc.machines.id = @machine_id";
                        command.Parameters.AddWithValue("@app_set_id", appId);
                        command.Parameters.AddWithValue("@machine_id", mc.MachineId);
                        //"order by [applications].[update_at] desc";
                        var result = command.ExecuteNonQuery();
                    }
                    con.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        private void PictureBoxRegister_Click(object sender, EventArgs e)
        {
            int? appId = GetAppId(treeViewCellconVersion.Nodes, c_CellconList);
            if (!appId.HasValue)
            {
                return;
            }
            SetMachine(treeViewMachine.Nodes, c_MachineList);
            var machines = c_MachineList.Where(x => x.MachineSelect).ToList();
            if (!SetToDb(machines, appId.Value))
            {
                MessageDialog.MessageBoxDialog.ShowMessageDialog("Register", "Register Fail!", "Error");
            }
            else
            {
                MessageDialog.MessageBoxDialog.ShowMessageDialog("Register", "Register Succeed!", "Succeed");
                c_MainFrom.panelMain.Controls.Clear();
              //  this.DialogResult = DialogResult.OK;
            }
        }

        #region View
        private void pictureBoxRegister_MouseHover(object sender, EventArgs e)
        {
            pictureBoxRegister.Image = AutoUpdateSetting.Properties.Resources.button_resister_cursor;
        }

        private void pictureBoxRegister_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxRegister.Image = AutoUpdateSetting.Properties.Resources.button_resister;
        }

        #endregion

        private void TreeViewCellconVersion_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //// only do it if the node became checked:
            //if (e.Node.Checked)
            //{

            //    int i = 0;

            //    // for all the nodes in the tree...
            //    foreach (TreeNode cur_node in e.Node.TreeView.Nodes)
            //    {

            //        if (e.Node.Parent == e.Node.TreeView.Nodes[i])
            //        {
            //            foreach (TreeNode item in e.Node.TreeView.Nodes[i].Nodes)
            //            {
            //                if (item != e.Node)
            //                {
            //                    // ... uncheck them
            //                    item.Checked = false;

            //                }

            //            }
            //            return;
            //        }

            //        i++;
            //    }
            //}
            // only do it if the node became checked:
            if (e.Node.Checked)
            {
                CheckedTreeNode(e.Node.TreeView.Nodes, e.Node);
            }
        }
        private void CheckedTreeNode(TreeNodeCollection treeNodeCollection, TreeNode treeNode)
        {
            // for all the nodes in the tree...
            foreach (TreeNode cur_node in treeNodeCollection)
            {
                if (cur_node.Nodes.Count > 0)
                {
                   // CheckedTreeNode(cur_node.Nodes, treeNode);
                }
                if (cur_node != treeNode)
                {
                    // ... uncheck them
                    cur_node.Checked = false;
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
                SendMessage(this.treeViewCellconVersion.Handle, TVM_SETITEM, IntPtr.Zero, lparam);
            }
        }

        private List<TreeNode> GetNodes(TreeNode node, int countNode = 0)
        {
            countNode++;
            List<TreeNode> nodes = new List<TreeNode>();
            if (countNode == 2)
                nodes.Add(node);
            foreach (TreeNode n in node.Nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    nodes.AddRange(GetNodes(n, countNode));
                }
            }
            return nodes;
        }
        #endregion
    }
}
