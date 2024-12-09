using AutoUpdateSetting.Model;
using AutoUpdateSetting.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AutoUpdateSetting.Model.FileData;
using MessageDialog;
namespace AutoUpdateSetting
{
    public partial class AddFileForm : Form
    {
        private List<FileData> c_FileDatas;
        private StatusFile? c_Status;
        private int? c_FileId;
        public AddFileForm()
        {
            InitializeComponent();
            c_FileDatas = new List<FileData>();
            InitializeView();
            // c_Connection = new SqlConnection(Properties.Settings.Default.APCSProDB);
        }

        private void AddFileForm_Load(object sender, EventArgs e)
        {
          
        }
        private void InitializeView()
        {
            pictureBoxUploadFiles.Parent = pictureBoxBackground;
            labelHeader.Parent = pictureBoxBackground;
            pictureBoxAdditem.Parent = pictureBoxBackground;
            pictureBoxClose.Parent = pictureBoxBackground;
            labelDirectory.Parent = pictureBoxBackground;
            labelFile.Parent = pictureBoxBackground;
            labelFileVersion.Parent = pictureBoxBackground;
            labelFileName.Parent = pictureBoxBackground;
        }
        private void ButtonBrowseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxPathFile.Text = openFileDialog1.FileName;
                c_Status = StatusFile.Local;
                UpdateUIState(c_Status.Value);
            }
               
        }

        private void PictureBoxAdditem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDirectory.Text) || string.IsNullOrEmpty(textBoxFileVersion.Text) || string.IsNullOrEmpty(textBoxPathFile.Text))
            {
                return;
            }
            FileData fileData = new FileData();
            fileData.Directory = textBoxDirectory.Text;
            fileData.FileVersion = textBoxFileVersion.Text;
            switch (c_Status)
            {
                case StatusFile.Local:
                    fileData.Name = Path.GetFileName(textBoxPathFile.Text).Trim();
                    fileData.Data = FileToByteArray(textBoxPathFile.Text);
                    fileData.Status = StatusFile.Local;
                    if (ExitFile(fileData))
                    {
                        MessageBoxDialog.ShowMessageDialog("Manage Files", "ไฟล์นี้มีอยู่แล้ว", "Error");
                        return;
                    }
                    break;
                case StatusFile.Server:
                    fileData.Name = textBoxPathFile.Text.Trim();
                    fileData.Data = null;
                    fileData.Status = StatusFile.Server;
                    fileData.BinaryId = c_FileId.Value;
                    break;
                default:
                    break;
            }
         

            if (c_FileDatas.Where(x => x.Name == fileData.Name).Any())
            {
                return;
            }
            c_FileDatas.Add(fileData);
            var bindingList = new BindingList<FileData>(c_FileDatas);
            var source = new BindingSource(bindingList, null);
            fileDataBindingSource.DataSource = source;

        }


        public byte[] FileToByteArray(string patgFile)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(patgFile,
                                           FileMode.Open,
                                           FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(patgFile).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }

        private void PictureBoxSaveToDbx_Click(object sender, EventArgs e)
        {
            if (InsertDataToDbx(c_FileDatas) && c_FileDatas.Count != 0)
            {
                MessageBoxDialog.ShowMessageDialog("Manage Files", "Save Succeed", "Succeed");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBoxDialog.ShowMessageDialog("Manage Files", "Save Fail", "Fail");
            }


        }
        private bool InsertDataToDbx(List<FileData> fileDatas)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.APCSProDB))
            {
                conn.Open();
                foreach (FileData fileData in c_FileDatas)
                {
                    SqlCommand command = conn.CreateCommand();
                    SqlTransaction transaction;

                    // Start a local transaction.
                    transaction = conn.BeginTransaction("SampleTransaction");

                    // Must assign both transaction object and connection
                    // to Command object for a pending local transaction
                    command.Connection = conn;
                    command.Transaction = transaction;

                    try
                    {
                        if (!fileData.BinaryId.HasValue)
                        {
                            
                            command.CommandText = "insert into [APCSProDBFile].[dbo].[files] ([data]) values (@file); SELECT SCOPE_IDENTITY()";
                            command.Parameters.AddWithValue("@file", fileData.Data);
                            var fileId = command.ExecuteScalar();
                            fileData.BinaryId = int.Parse(fileId.ToString());
                        }
                     
                        command.CommandText = "insert into [APCSProDB].[cellcon].[files] ([name],[binary_id],[version],[directory]) values (@name,@binary_id,@version,@directory); SELECT SCOPE_IDENTITY()";
                        if (command.Parameters.Count > 0)
                        {
                            command.Parameters.Clear();
                        }
                        command.Parameters.AddWithValue("@name", fileData.Name);
                        command.Parameters.AddWithValue("@binary_id", fileData.BinaryId);
                        command.Parameters.AddWithValue("@version", fileData.FileVersion);
                        command.Parameters.AddWithValue("@directory", fileData.Directory);
                        command.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        // Attempt to roll back the transaction.
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception)
                        {
                            // This catch block will handle any errors that may have occurred
                            // on the server that would cause the rollback to fail, such as
                            // a closed connection.
                            //Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                            //Console.WriteLine("  Message: {0}", ex2.Message);
                            return false;
                        }
                        return false;
                    }
                }

                conn.Close();
                return true;
            }
            
            
        }
        private bool ExitFile(FileData fileData)
        {
            List<FileData> fileDataList = new List<FileData>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.APCSProDB))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = conn;

                try
                {
                    command.CommandText = "select distinct [name],[binary_id],[version] from [cellcon].[files]";
                    //command.Parameters.AddWithValue("@file", fileData.Data);
                    var result = command.ExecuteReader();
                    while (result.Read())
                    {
                        FileData Data = new FileData();
                        Data.Name = result["name"].ToString();
                        Data.BinaryId = int.Parse(result["binary_id"].ToString());
                        Data.FileVersion = result["version"].ToString();
                        fileDataList.Add(Data);
                    }
                    //fileData.BinaryId = int.Parse(fileId.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
            return fileDataList.Where(x => x.Name == fileData.Name && x.FileVersion == fileData.FileVersion).Any();
            
        }
        private void ButtonBrowseServer_Click(object sender, EventArgs e)
        {

            List<FileData> fileDataList = new List<FileData>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.APCSProDB))
            {
                conn.Open();
   
                SqlCommand command = conn.CreateCommand();
                
                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = conn;

                try
                {
                    command.CommandText = "select distinct [name],[binary_id],[version] from [cellcon].[files]";
                    //command.Parameters.AddWithValue("@file", fileData.Data);
                    var result = command.ExecuteReader();
                    while (result.Read())
                    {
                        FileData fileData = new FileData();
                        fileData.Name = result["name"].ToString();
                        fileData.BinaryId = int.Parse(result["binary_id"].ToString());
                        fileData.FileVersion = result["version"].ToString();
                        fileDataList.Add(fileData);
                    }
                    //fileData.BinaryId = int.Parse(fileId.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }

            FormFileList frm = new FormFileList(fileDataList);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                textBoxPathFile.Text = frm.FileName;
                textBoxFileVersion.Text = frm.FileVersion;
                c_FileId = frm.BinaryId;
                c_Status = StatusFile.Server;
                UpdateUIState(c_Status.Value);
            }

        }
        private void UpdateUIState(StatusFile statusFile)
        {
            switch (statusFile)
            {
                case StatusFile.Local:
                    textBoxFileVersion.Enabled = true;
                    textBoxFileVersion.Text = "";
                    break;
                case StatusFile.Server:
                    textBoxFileVersion.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void PictureBoxUploadFiles_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxUploadFiles.Image = AutoUpdateSetting.Properties.Resources.upload_files;
        }

        private void PictureBoxUploadFiles_MouseHover(object sender, EventArgs e)
        {
            pictureBoxUploadFiles.Image = AutoUpdateSetting.Properties.Resources.upload_files_cursor;
        }

        private void PictureBoxClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void PictureBoxAdditem_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAdditem.Image = AutoUpdateSetting.Properties.Resources.add_file;
        }

        private void PictureBoxAdditem_MouseHover(object sender, EventArgs e)
        {
            pictureBoxAdditem.Image = AutoUpdateSetting.Properties.Resources.add_file_cursor;
        }
    }
}
