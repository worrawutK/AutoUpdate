using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdateSetting.Model;
using AutoUpdateSetting.View;
namespace AutoUpdateSetting
{
    public partial class MainForm : Form
    {
        //private MenuProgram c_MenuProgram;

        private MenuProgram c_MenuFrom;
        public MenuProgram MenuFrom
        {
            get { return c_MenuFrom; }
            set {
                c_MenuFrom = value;
                switch (MenuFrom)
                {
                    case MenuProgram.DEFAULT:
                        pictureBoxManageFiles.Image = AutoUpdateSetting.Properties.Resources.manage_files;
                        pictureBoxManageApplication.Image = AutoUpdateSetting.Properties.Resources.manage_application;
                        pictureBoxManageCellcon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon;
                        pictureBoxManageMachines.Image = AutoUpdateSetting.Properties.Resources.manage_machine;
                        break;
                    case MenuProgram.MANAGEFILES:
                        pictureBoxManageFiles.Image = AutoUpdateSetting.Properties.Resources.manage_files_cursor;
                        pictureBoxManageApplication.Image = AutoUpdateSetting.Properties.Resources.manage_application;
                        pictureBoxManageCellcon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon;
                        pictureBoxManageMachines.Image = AutoUpdateSetting.Properties.Resources.manage_machine;
                        break;
                    case MenuProgram.MANAGEAPPLICATION:
                        pictureBoxManageFiles.Image = AutoUpdateSetting.Properties.Resources.manage_files;
                        pictureBoxManageApplication.Image = AutoUpdateSetting.Properties.Resources.manage_application_cursor;
                        pictureBoxManageCellcon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon;
                        pictureBoxManageMachines.Image = AutoUpdateSetting.Properties.Resources.manage_machine;
                        break;
                    case MenuProgram.MANAGECELLCON:
                        pictureBoxManageFiles.Image = AutoUpdateSetting.Properties.Resources.manage_files;
                        pictureBoxManageApplication.Image = AutoUpdateSetting.Properties.Resources.manage_application;
                        pictureBoxManageCellcon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon_cursor;
                        pictureBoxManageMachines.Image = AutoUpdateSetting.Properties.Resources.manage_machine;
                        break;
                    case MenuProgram.MANAGEMACHINES:
                        pictureBoxManageFiles.Image = AutoUpdateSetting.Properties.Resources.manage_files;
                        pictureBoxManageApplication.Image = AutoUpdateSetting.Properties.Resources.manage_application;
                        pictureBoxManageCellcon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon;
                        pictureBoxManageMachines.Image = AutoUpdateSetting.Properties.Resources.manage_machine_cursor;
                        break;
                }
            }
        }
      //  public List<FileData> c_FileData;
       // public List<ApplicationData> c_ApplicationData;
        //public List<CellconData> c_CellconData;
        public MainForm()
        {
            InitializeComponent();
            MenuFrom = MenuProgram.DEFAULT;
            //  c_ProgramData = new List<ProgramData>();
           // c_CellconData = GetCellconDataList();
           // c_ApplicationData = GetApplicationData();// ConvertToApplicationDataList(c_ProgramData);
           // c_FileData = GetFileDatas();


        }
        private List<FileData> ConvertToFileDataList(List<ProgramData> programDatas)
        {
            List<FileData> fileDataList = new List<FileData>();
            var tmp = programDatas.Select(x => new { x.File_Id, x.File_Binary_Id, x.File_Directory, x.File_Version, x.File_Name }).Distinct().ToList();
            return tmp.Select(x =>
            new FileData
            {
                FileId = x.File_Id,
                BinaryId = x.File_Binary_Id,
                Directory = x.File_Directory,
                FileVersion = x.File_Version,
                Name = x.File_Name,
            }).OrderBy(x => x.FileId).ToList();

        }
        private List<ApplicationData> ConvertToApplicationDataList(List<ProgramData> programDatas)
        {
            List<ApplicationData> fileDataList = new List<ApplicationData>();
            var tmp = programDatas.Select(x => new { x.App_Id, x.App_Name, x.App_Version, x.App_Update_At }).Distinct().ToList();
            return tmp.Select(x =>
            new ApplicationData
            {
                ApplicationId = x.App_Id,
                ApplictionName = x.App_Name,
                ApplictionVersion = x.App_Version,
                FileDataList = programDatas.Where(y => y.App_Id == x.App_Id).Select(y =>
                 new FileData {
                     FileId = y.File_Id,
                     Directory = y.File_Directory,
                     FileVersion = y.File_Version,
                     Name = y.File_Name,
                     BinaryId = y.File_Binary_Id }).ToList()
            }).OrderByDescending(x => x.ApplicationId).ToList();

        }
        private List<CellconData> GetCellconDataList()
        {
            List<ProgramData> programDatas = GetProgramData();
            List<FileData> fileDataList = new List<FileData>();
            var tmp = programDatas.Select(x => new { x.Cell_Id, x.Cell_Name, x.Cell_Version, x.Cell_Update_At}).Distinct().ToList();
            return  tmp.Select(x =>
            new CellconData
            {
                CellconId = x.Cell_Id,
                CellconName = x.Cell_Name,
                CellconVersion = x.Cell_Version,
                ApplicationDataList = programDatas.Where(y => y.Cell_Id == x.Cell_Id).Select(y => 
                new ApplicationData() {
                    ApplicationId = y.App_Id,
                    ApplictionName = y.App_Name,
                    ApplictionVersion = y.App_Version,
                    FileDataList = programDatas.Where(z=>z.File_Id == y.File_Id).Select(z=>
                    new FileData() {
                        FileId =z.File_Id,
                         Name = z.File_Name,
                         BinaryId =z.File_Binary_Id,
                         Directory = z.File_Directory,
                         FileVersion = z.File_Version,
                         Date =z.File_Update_At
                    }).ToList()
                }).ToList()
            }).OrderBy(x => x.CellconId).ToList();
            //return tmp.Select(x =>
            //new ApplicationData
            //{
            //    ApplicationId = x.App_Id,
            //    ApplictionName = x.App_Name,
            //    ApplictionVersion = x.App_Version,
            //    FileDataList = c_ProgramData.Where(y => y.App_Id == x.App_Id).Select(y => new FileData() { FileId = y.File_Id, Name = y.File_Name, FileVersion = y.File_Version }).ToList()

            //}).OrderBy(x => x.ApplicationId).ToList();
        }
        private void pictureBoxAddFile_Click(object sender, EventArgs e)
        {
            MenuFrom = MenuProgram.MANAGEFILES;
            panelMain.Controls.Clear();
            ManageFiles manageFiles = new ManageFiles(this, GetFileDatas());
            panelMain.Controls.Add(manageFiles);
        }

        private void pictureBoxRegisterProgram_Click(object sender, EventArgs e)
        {
            MenuFrom = MenuProgram.MANAGEAPPLICATION;
            ManageApplication manageApplication = new ManageApplication(this, GetFileDatas(), GetApplicationData());
            panelMain.Controls.Clear();
            panelMain.Controls.Add(manageApplication);
            //RegisterProgramForm registerProgramForm = new RegisterProgramForm();
            //registerProgramForm.ShowDialog();
        }

        private void pictureBoxRegisterProgramCellCon_Click(object sender, EventArgs e)
        {
            MenuFrom = MenuProgram.MANAGECELLCON;
            ManageCellcon manageCellcon = new ManageCellcon(this, GetApplicationData(), GetCellconDataList());
            panelMain.Controls.Clear();
            panelMain.Controls.Add(manageCellcon);

            //RegisterProgramCellconForm registerProgramCellconForm = new RegisterProgramCellconForm();
            //registerProgramCellconForm.ShowDialog();
        }

        private void pictureBoxSettingProgramMachine_Click(object sender, EventArgs e)
        {
            MenuFrom = MenuProgram.MANAGEMACHINES;
            ManageMachines manageMachines = new ManageMachines(this, GetCellconDataList());
            panelMain.Controls.Clear();
            panelMain.Controls.Add(manageMachines);


            //SettingProgramMachineForm setting = new SettingProgramMachineForm();
            //setting.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //pictureBox1.Controls.Add(pictureBoxAddFile);
            //pictureBoxAddFile.Location = new Point(24, 12);
            
            pictureBoxManageFiles.Parent = pictureBox1;
            pictureBoxManageApplication.Parent = pictureBox1;
            pictureBoxManageCellcon.Parent = pictureBox1;
            pictureBoxManageMachines.Parent = pictureBox1;
            pictureBoxExit.Parent = pictureBox1;
            labelHeader.Parent = pictureBox1;
            panelMain.Parent = pictureBox1;
            labelVersion.Parent = pictureBox1;
            labelVersion.Text = "Version :" + this.ProductVersion;
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public enum MenuProgram
        {
            DEFAULT,
            MANAGEFILES,
            MANAGEAPPLICATION,
            MANAGECELLCON,
            MANAGEMACHINES
            
        }
        private bool CheckMenu(MenuProgram menuProgram)
        {
            if (menuProgram == MenuFrom)
                return false;

            return true;
        }
        #region View
        private void pictureBoxSettingProgramMachine_MouseLeave(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGEMACHINES))
                return;
            pictureBoxManageMachines.Image = AutoUpdateSetting.Properties.Resources.manage_machine;
        }
        private void pictureBoxRegisterProgramCellCon_MouseLeave(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGECELLCON))
                return;
            pictureBoxManageCellcon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon;
        }
        private void pictureBoxRegisterProgram_MouseLeave(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGEAPPLICATION))
                return;
            pictureBoxManageApplication.Image = AutoUpdateSetting.Properties.Resources.manage_application;
        }
        private void pictureBoxAddFile_MouseLeave(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGEFILES))
                return;
            pictureBoxManageFiles.Image = AutoUpdateSetting.Properties.Resources.manage_files;
        }

        private void pictureBoxExit_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxExit.Image = AutoUpdateSetting.Properties.Resources.exitProgram;
        }

        private void pictureBoxSettingProgramMachine_MouseHover(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGEMACHINES))
                return;
            pictureBoxManageMachines.Image = AutoUpdateSetting.Properties.Resources.manage_machine_cursor;
        }

        private void pictureBoxRegisterProgramCellCon_MouseHover(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGECELLCON))
                return;
            pictureBoxManageCellcon.Image = AutoUpdateSetting.Properties.Resources.manage_cellcon_cursor;
        }
        private void pictureBoxRegisterProgram_MouseHover(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGEAPPLICATION))
                return;
            pictureBoxManageApplication.Image = AutoUpdateSetting.Properties.Resources.manage_application_cursor;
        }
        private void pictureBoxAddFile_MouseHover(object sender, EventArgs e)
        {
            if (!CheckMenu(MenuProgram.MANAGEFILES))
                return;
            pictureBoxManageFiles.Image = AutoUpdateSetting.Properties.Resources.manage_files_cursor;

        }
        private void pictureBoxExit_MouseHover(object sender, EventArgs e)
        {
            pictureBoxExit.Image = AutoUpdateSetting.Properties.Resources.exitProgram_cursor;
        }
        #endregion
        private List<ProgramData> GetProgramData()
        {
            DateTime dateTime = DateTime.Now;
            List<ProgramData> programnDataList = new List<ProgramData>();
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.APCSProDB))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT [name] FROM cellcon.application_sets GROUP BY [name]";
                var rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.APCSProDB))
                    {
                        conn.Open();
                        SqlCommand command = conn.CreateCommand();
                        command.Connection = conn;

                        try
                        {
                            //command.CommandText = "select app_set.id as cell_id,app_set.[name] as cell_name, app_set.[version] as cell_version,app_set.update_at as cell_update_at" +
                            //             " ,app.id as app_id,app.[name] as [app_name],app.[version] as app_version,app.update_at as app_update_at, " +
                            //             " [file].id as [file_id],[file].directory as file_directory,[file].[name] as [file_name]," +
                            //             " [file].update_at as file_update_at,[file].[version] as file_version ,[file].binary_id as file_binary_id " +
                            //             " from cellcon.application_sets as app_set " +
                            //             " inner join cellcon.application_application_sets as cell_app on cell_app.application_set_id = app_set.id " +
                            //             " inner join cellcon.applications as app on app.id = cell_app.application_id " +
                            //             " inner join cellcon.applications_file as app_file on app_file.application_id = app.id " +
                            //             " inner join cellcon.files as [file] on[file].id = app_file.[file_id] ";
                            command.CommandText = "SELECT app_detail.* " +
                                                  "FROM(SELECT TOP 100 * FROM cellcon.application_sets WHERE [name] = @cellcon_name ORDER BY update_at DESC) AS app_set "+
                                                    "INNER JOIN(select app_set.id as cell_id,app_set.[name] as cell_name, app_set.[version] as cell_version,app_set.update_at as cell_update_at , " +
                                                    "app.id as app_id,app.[name] as [app_name],app.[version] as app_version,app.update_at as app_update_at,  [file].id as [file_id], " +
                                                    "[file].directory as file_directory,[file].[name] as [file_name], [file].update_at as file_update_at,[file].[version] as file_version ,[file].binary_id as file_binary_id " +
                                                    "from cellcon.application_sets as app_set " +
                                                    "inner join cellcon.application_application_sets as cell_app on cell_app.application_set_id = app_set.id " +
                                                    "inner join cellcon.applications as app on app.id = cell_app.application_id " +
                                                    "inner join cellcon.applications_file as app_file on app_file.application_id = app.id " +
                                                    "inner join cellcon.files as [file] on[file].id = app_file.[file_id] ) AS app_detail ON app_detail.cell_id = app_set.id";
                            command.Parameters.Add("@cellcon_name", SqlDbType.VarChar).Value = rd["name"].ToString();
                            var reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                ProgramData programData = new ProgramData
                                {
                                    Cell_Id = int.Parse(reader["cell_id"].ToString()),
                                    Cell_Name = reader["cell_name"].ToString(),
                                    Cell_Version = reader["cell_version"].ToString(),
                                    Cell_Update_At = (DateTime)reader["cell_update_at"],

                                    App_Id = (int)reader["app_id"],
                                    App_Name = (string)reader["app_name"],
                                    App_Version = (string)reader["app_version"],
                                    App_Update_At = (DateTime)reader["app_update_at"],

                                    File_Id = (int)reader["file_id"],
                                    File_Name = (string)reader["file_name"],
                                    File_Directory = (string)reader["file_directory"],
                                    File_Version = (string)reader["file_version"],
                                    File_Update_At = (DateTime)reader["file_update_at"],
                                    File_Binary_Id = (int)reader["file_binary_id"]
                                };
                                programnDataList.Add(programData);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        conn.Close();
                    }
                }
                cmd.Connection.Close();
            }
          
            Debug.Print("GetProgramData:" + (DateTime.Now - dateTime).TotalSeconds.ToString());
            return programnDataList;

        }
        #region GetData
        private List<FileData> GetFileDatas()
        {
            DateTime dateTime = DateTime.Now;
            List<FileData> fileDataList = new List<FileData>();
            using (SqlConnection con = new SqlConnection(Properties.Settings.Default.APCSProDB))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = "select [name],directory from [cellcon].[files] group by [name],directory";
                var data =  cmd.ExecuteReader();
                while (data.Read())
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
                            command.CommandText = "select top 30 [id],[name],[binary_id],[version],[directory] from [cellcon].[files]  " +
                                                    "where [name] = @file_name and directory = @directory " +
                                                    "order by update_at desc";
                            //command.CommandText = "select [id],[name],[binary_id],[version],[directory] from [cellcon].[files]";
                            command.Parameters.Add("@file_name", SqlDbType.VarChar).Value = data["name"].ToString();
                            command.Parameters.Add("@directory", SqlDbType.VarChar).Value = data["directory"].ToString();
                            var result = command.ExecuteReader();
                            while (result.Read())
                            {
                                FileData fileData = new FileData
                                {
                                    FileId = int.Parse(result["id"].ToString()),
                                    Name = result["name"].ToString(),
                                    BinaryId = int.Parse(result["binary_id"].ToString()),
                                    FileVersion = result["version"].ToString(),
                                    Directory = result["directory"].ToString()
                                };
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
                }

            }
     
            Debug.Print("GetFileDatas:" + (DateTime.Now - dateTime).TotalSeconds.ToString());
            return fileDataList;
        }

        //private List<ApplicationData> GetApplicationData()
        //{
        //    DateTime dateTime = DateTime.Now;
        //    List<ApplicationData> app_Data = new List<ApplicationData>();
        //    //(Properties.Settings.Default.APCSProDB))
        //    using (SqlConnection con = new SqlConnection(Properties.Settings.Default.APCSProDB))
        //    {
        //        con.Open();
        //        SqlCommand command = con.CreateCommand();
        //        command.CommandText = "select [applications].[id],[applications].[name],[applications].[version],[applications].[update_at] from [cellcon].[applications] " +
        //            "order by [applications].[update_at] desc";
        //        var result = command.ExecuteReader();
        //        Debug.Print("GetApplicationData1:" + (DateTime.Now - dateTime).TotalSeconds.ToString());
        //        while (result.Read())
        //        {
        //            ApplicationData applicationData = new ApplicationData
        //            {
        //                ApplictionName = result["name"].ToString(),
        //                ApplictionVersion = result["version"].ToString(),
        //                ApplicationId = int.Parse(result["id"].ToString())
        //            };
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
        //                var result2 = command2.ExecuteReader();
        //                Debug.Print("GetApplicationData2:" + (DateTime.Now - dateTime).TotalSeconds.ToString());
        //                while (result2.Read())
        //                {
        //                    FileData fileData = new FileData
        //                    {
        //                        FileId = (int)result2["file_id"],
        //                        Name = (string)result2["file_name"],
        //                        Directory = (string)result2["file_directory"],
        //                        FileVersion = (string)result2["file_version"]
        //                    };
        //                    fileDatas.Add(fileData);
        //                }
        //            }
        //            applicationData.FileDataList = fileDatas;
        //            app_Data.Add(applicationData);
        //        }

        //    }
        //    Debug.Print("GetApplicationData:" + (DateTime.Now - dateTime).TotalSeconds.ToString());
        //    return app_Data;
        //}
        private List<ApplicationData> GetApplicationData()
        {
            DateTime dateTime = DateTime.Now;
            List<ApplicationData> app_Data = new List<ApplicationData>();
            //(Properties.Settings.Default.APCSProDB))
            using (SqlConnection conGetAppName = new SqlConnection(Properties.Settings.Default.APCSProDB))
            {
                conGetAppName.Open();
                SqlCommand commandGetName = conGetAppName.CreateCommand();
                commandGetName.CommandText = "select [name] from [cellcon].[applications] group by [name] order by [name] desc";
                var resultGetName = commandGetName.ExecuteReader();
            //    Debug.Print("GetApplicationData0:" + (DateTime.Now - dateTime).TotalSeconds.ToString());
                while (resultGetName.Read())
                {
                    using (SqlConnection con = new SqlConnection(Properties.Settings.Default.APCSProDB))
                    {
                        con.Open();
                        SqlCommand command = con.CreateCommand();
                        command.CommandText = "select top 30 [applications].[id],[applications].[name],[applications].[version],[applications].[update_at]" +
                                    "from [cellcon].[applications]" +
                                    "where[name] = @app_name " +
                                    "order by[applications].[update_at] desc";
                        command.Parameters.Add("@app_name", SqlDbType.VarChar).Value = resultGetName["name"].ToString();
                        var result = command.ExecuteReader();
                       // Debug.Print("GetApplicationData1:" + (DateTime.Now - dateTime).TotalSeconds.ToString());
                        while (result.Read())
                        {
                            ApplicationData applicationData = new ApplicationData
                            {
                                ApplictionName = result["name"].ToString(),
                                ApplictionVersion = result["version"].ToString(),
                                ApplicationId = int.Parse(result["id"].ToString())
                            };
                            List<FileData> fileDatas = new List<FileData>();
                            using (SqlConnection con2 = new SqlConnection(Properties.Settings.Default.APCSProDB))
                            {
                                con2.Open();
                                SqlCommand command2 = con2.CreateCommand();
                                command2.CommandText = "select app.id as app_id,app.[name] as [app_name],app.[version] as app_version " +
                                " ,app.update_at as app_update_at,  [file].id as [file_id], " +
                                " [file].directory as file_directory,[file].[name] as [file_name]," +
                                " [file].update_at as file_update_at,[file].[version] as file_version " +
                                " ,[file].binary_id as file_binary_id " +
                                " from  cellcon.applications as app " +
                                " inner join cellcon.applications_file as app_file on app_file.application_id = app.id " +
                                " inner join cellcon.files as [file] on[file].id = app_file.[file_id] " +
                                " where app.id = @app_id";
                                command2.Parameters.AddWithValue(@"app_id", applicationData.ApplicationId);
                                var result2 = command2.ExecuteReader();
                             //   Debug.Print("GetApplicationData2:" + (DateTime.Now - dateTime).TotalSeconds.ToString());
                                while (result2.Read())
                                {
                                    FileData fileData = new FileData
                                    {
                                        FileId = (int)result2["file_id"],
                                        Name = (string)result2["file_name"],
                                        Directory = (string)result2["file_directory"],
                                        FileVersion = (string)result2["file_version"]
                                    };
                                    fileDatas.Add(fileData);
                                }
                            }
                            applicationData.FileDataList = fileDatas;
                            app_Data.Add(applicationData);
                        }

                    }
                }
            }
           
            Debug.Print("GetApplicationData:" + (DateTime.Now - dateTime).TotalSeconds.ToString());
            return app_Data;
        }
        private List<CellconData> GetCellconData()
        {
            List<CellconData> cellconDataList = new List<CellconData>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.APCSProDB))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();

                // Must assign both transaction object and connection
                // to Command object for a pending local transaction
                command.Connection = conn;

                try
                {
                    command.CommandText = "select  [id],[name],[version] from [cellcon].[application_sets]";
                    //command.Parameters.AddWithValue("@file", fileData.Data);
                    var result = command.ExecuteReader();
                    while (result.Read())
                    {
                        CellconData cellconData = new CellconData();
                        cellconData.CellconId = int.Parse(result["id"].ToString());
                        cellconData.CellconName = result["name"].ToString();
                        cellconData.CellconVersion = result["version"].ToString();
                        cellconDataList.Add(cellconData);
                    }
                    //fileData.BinaryId = int.Parse(fileId.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
            return cellconDataList;
        }
        #endregion
    }
}
