using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdateSetting.Model;
using MessageDialog;
namespace AutoUpdateSetting.View
{
    public partial class FormFileList : Form
    {
        public string FileName { get; set; }
        public string FileVersion { get; set; }
        public int? BinaryId { get; set; }
        private List<FileData> c_FileDataList;
        public FormFileList(List<FileData> fileList)
        {
            InitializeComponent();
            c_FileDataList = fileList;
        }
        
        private void FormFileList_Load(object sender, EventArgs e)
        {
            labelFileName.Parent = pictureBox1;
            pictureBoxSelect.Parent = pictureBox1;
            labelVersion.Parent = pictureBox1;
            labelHeader.Parent = pictureBox1;
            pictureBoxCancel.Parent = pictureBox1;
            List<string> fileName = c_FileDataList.Select(x => x.Name).Distinct().OrderBy(x=>x).ToList();
            foreach (var item in fileName)
            {
                listBoxProgramName.Items.Add(item);
            }
            //foreach (var item in c_FileDataList)
            //{
            //    listBoxProgramName.Items.Add(item.Name + " : " + item.FileVersion + ":" + item.BinaryId);
            //}
        }

        private void listBoxProgramName_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            var fileData = c_FileDataList.Where(x => x.Name == listBox.SelectedItem.ToString()).Select(x=> x.FileVersion).Distinct().OrderByDescending(x=>x).ToList();
            listBoxFileList.Items.Clear();
            List<Version> versions = new List<Version>();
           
            foreach (var item in fileData)
            {
             
                versions.Add(new Version(item));
            }
            versions.Sort();
            versions.Reverse();
            foreach (var item in versions)
            {
                listBoxFileList.Items.Add(item);
            }

        }

        private void listBoxProgramName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxSelect_Click(object sender, EventArgs e)
        {
            if (listBoxProgramName.SelectedItem == null)
            {
                MessageBoxDialog.ShowMessageDialog("select file", "กรุณาเลือก file name", "");
                return;
            }
               

            if (listBoxFileList.SelectedItem == null)
            {
                MessageBoxDialog.ShowMessageDialog("select version", "กรุณาเลือก version name", "");
                return;
            }
               
            FileName = listBoxProgramName.SelectedItem.ToString();
            FileVersion = listBoxFileList.SelectedItem.ToString();
            var fileId = c_FileDataList.Where(x => x.Name == FileName && x.FileVersion == FileVersion).Select(x => x.BinaryId);
            foreach (var id in fileId)
            {
                BinaryId = id;
                break;
            }
            //FileId = c_FileDataList.Where(x => x.Name == FileName && x.FileVersion == FileVersion).Select(x => x.FileId);
            this.DialogResult = DialogResult.OK;
        }

        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void pictureBoxSelect_MouseHover(object sender, EventArgs e)
        {
            pictureBoxSelect.Image = AutoUpdateSetting.Properties.Resources.button_select_cursor;
        }

        private void pictureBoxSelect_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxSelect.Image = AutoUpdateSetting.Properties.Resources.button_select;
        }

        private void pictureBoxCancel_MouseHover(object sender, EventArgs e)
        {
            pictureBoxCancel.Image = AutoUpdateSetting.Properties.Resources.button_Cancel_Cursor;
        }

        private void pictureBoxCancel_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxCancel.Image = AutoUpdateSetting.Properties.Resources.button_Cancel;
        }
    }
}
