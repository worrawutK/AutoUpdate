using AutoUpdateSetting.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUpdateSetting.View
{
    public partial class FormConfirmRegisterProgram : Form
    {
        private List<string> c_FileData;
        public FormConfirmRegisterProgram(List<string> fileDatas)
        {
            InitializeComponent();
            c_FileData = fileDatas;
        }
        
        private void FormConfirmRegisterProgram_Load(object sender, EventArgs e)
        {
            labelHeader.Parent = pictureBox1;
            pictureBoxOk.Parent = pictureBox1;
            pictureBoxCancel.Parent = pictureBox1;
           
            foreach (var item in c_FileData)
            {
                treeViewItem.Nodes.Add(item);
            }
        }

        private void pictureBoxOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void pictureBoxCancel_MouseHover(object sender, EventArgs e)
        {
            pictureBoxCancel.Image = AutoUpdateSetting.Properties.Resources.button_Cancel_Cursor;
        }

        private void pictureBoxCancel_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxCancel.Image = AutoUpdateSetting.Properties.Resources.button_Cancel;
        }

        private void pictureBoxOk_MouseHover(object sender, EventArgs e)
        {
            pictureBoxOk.Image = AutoUpdateSetting.Properties.Resources.button_Ok_Cursor;
        }

        private void pictureBoxOk_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxOk.Image = AutoUpdateSetting.Properties.Resources.button_Ok;
        }
    }
}
