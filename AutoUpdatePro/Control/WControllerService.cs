﻿using AutoUpdateProLibrary.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace AutoUpdateProLibrary.Control
{
    public class WControllerService : IControllerService
    {
        public List<FileDataInfo> GetFilesInfo(string cell_Ip)
        {
            try
            {
                List<FileDataInfo> fileDatasList = new List<FileDataInfo>();
                //string cell_Ip = AppSettingHelper.GetAppSettingsValue("CellConIp");
                //GetFile from database
                SqlConnection conn = new SqlConnection(AppSettingHelper.GetConnectionStringValue("ApcsProConnectionString"));
                conn.Open();

                SqlCommand command = new SqlCommand(
                    "select  machines.name as machine_no,machines.id as machine_id,machines.cell_ip," + //mc.machine
                    "application_sets.id as application_set_id ,application_sets.name as application_set_name ,application_sets.version as application_set_version," + //cellcon.application_sets
                    "applications.id as application_id , applications.name as application_name ,applications.version as application_version," + //cellcon.applications
                    "files.id as file_id,files.name as file_name ,files.version as file_version, files.directory as file_directory,files.binary_id" + //cellcon.files
                    " from mc.machines" +
                    " inner join cellcon.application_sets on application_sets.id = machines.application_set_id" + //cellcon.application_sets
                    " inner join cellcon.application_application_sets on application_application_sets.application_set_id = application_sets.id" +  //cellcon.application_sets + cellcon.applications
                    " inner join cellcon.applications on applications.id = application_application_sets.application_id" + //cellcon.applications
                    " inner join cellcon.applications_file on applications_file.application_id = applications.id" + //cellcon.applications + cellcon.files
                    " inner join cellcon.files on files.id = applications_file.file_id" + //cellcon.files
                    " where machines.cell_ip = @MachineIp"
                    , conn);
                command.Parameters.AddWithValue("@MachineIp", cell_Ip);
                // int result = command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FileDataInfo fileData = new FileDataInfo
                        {
                            MachineName = reader["machine_no"].ToString(),
                            MachineIpAddress = reader["cell_ip"].ToString(),
                            MachineId = int.Parse(reader["machine_id"].ToString()),

                            ApplicationSetId = int.Parse(reader["application_set_id"].ToString()),
                            ApplicationSetName = reader["application_set_name"].ToString(),
                            ApplicationSetVersion = reader["application_set_version"].ToString(),

                            ApplicationId = int.Parse(reader["application_id"].ToString()),
                            ApplicationName = reader["application_name"].ToString(),
                            ApplicationVersion = reader["application_version"].ToString(),

                            FileId = int.Parse(reader["file_id"].ToString()),
                            FileName = reader["file_name"].ToString(),
                            FileVersion = reader["file_version"].ToString(),
                            FileDirectory = reader["file_directory"].ToString(),
                            //FileBinary = (byte[])reader["data"]
                        };

                        fileDatasList.Add(fileData);
                    }
                    //if (reader.Read())
                    //{

                    //}
                }

                conn.Close();
                return fileDatasList;
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }
        public List<FileData> GetFiles(int app_Id)
        {
            List<FileData> fileDatasList = new List<FileData>();
            //string cell_Ip = AppSettingHelper.GetAppSettingsValue("CellConIp");
            //GetFile from database
            SqlConnection conn = new SqlConnection(AppSettingHelper.GetConnectionStringValue("ApcsProConnectionString"));
            conn.Open();

            SqlCommand command = new SqlCommand(
                " select application_sets.id as application_set_id " +
                ", application_sets.name as application_set_name, application_sets.version as application_set_version," +
                " applications.id as application_id, applications.name as application_name, applications.version as application_version," +
                " files.id as file_id, files.name as file_name, files.version as file_version, files.directory as file_directory, files.binary_id" +
                ", APCSProDBFil_files.data" +
                " from cellcon.application_sets" +
                " inner join cellcon.application_application_sets on application_application_sets.application_set_id = application_sets.id" +
                " inner join cellcon.applications on applications.id = application_application_sets.application_id" +
                " inner join cellcon.applications_file on applications_file.application_id = applications.id" +
                " inner join cellcon.files on files.id = applications_file.file_id" +
                " inner join APCSProDBFile.dbo.files as APCSProDBFil_files on APCSProDBFil_files.id = APCSProDB.cellcon.files.binary_id" +
                " where application_sets.id = @ApplicationSetId "
                , conn);
            command.Parameters.AddWithValue("@ApplicationSetId", app_Id);
            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    FileData fileData = new FileData
                    {
                        //MachineName = reader["machine_no"].ToString(),
                        //MachineIpAddress = reader["cell_ip"].ToString(),
                        //MachineId = int.Parse(reader["machine_id"].ToString()),

                        ApplicationSetId = int.Parse(reader["application_set_id"].ToString()),
                        ApplicationSetName = reader["application_set_name"].ToString(),
                        ApplicationSetVersion = reader["application_set_version"].ToString(),

                        ApplicationId = int.Parse(reader["application_id"].ToString()),
                        ApplicationName = reader["application_name"].ToString(),
                        ApplicationVersion = reader["application_version"].ToString(),

                        FileId = int.Parse(reader["file_id"].ToString()),
                        FileName = reader["file_name"].ToString(),
                        FileVersion = reader["file_version"].ToString(),
                        FileDirectory = reader["file_directory"].ToString(),
                        FileBinary = (byte[])reader["data"]
                    };

                    fileDatasList.Add(fileData);
                }
                //if (reader.Read())
                //{

                //}
            }

            conn.Close();
            return fileDatasList;
        }
        #region ConvetDataType
        private ResultBase ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                var path = System.IO.Path.GetDirectoryName(fileName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //FileMode.Append Overriable
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return new ResultBase(true, "");
                }
            }
            catch (Exception ex)
            {
                return new ResultBase(false, string.Format("Exception caught in process: {0}", ex));
            }
        }
        public byte[] FileToByteArray(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName,
                                           FileMode.Open,
                                           FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }
        #endregion

        public UpdateResult StartProgram(List<FileData> fileDatas)
        {
            try
            {
                //var machineList = fileDatas.Select(y => new { y.MachineId }).Distinct().ToList();
                //machineList.Where(m => m.MachineId == x.MachineId).Any()
                var exeFile = fileDatas.Where(x =>
                x.FileName.Contains(".exe") &&
                !x.FileName.Contains(".config")
                ).Select(v => new { v.FileName , v.FileDirectory}).Distinct().ToList();
                foreach (var file in exeFile)
                {
                    Process[] processes = Process.GetProcessesByName(file.FileName.Replace(".exe", ""));
                    if (processes.Count() == 0)
                    {
                        Process.Start(Path.Combine(file.FileDirectory, file.FileName));
                        //if (WriteBatFile(Path.Combine(file.FileDirectory, file.FileName.Replace(".exe", ".bat")), Path.Combine(file.FileDirectory, file.FileName)))
                        //{
                        //    Process.Start(Path.Combine(file.FileDirectory, file.FileName.Replace(".exe", ".bat")));
                        //}

                        
                    }
                   
                }
                return new UpdateResult(true, "");
            }
            catch (Exception ex)
            {
                return new UpdateResult(false, ex.Message.ToString());
            }
       

        }

        //private bool WriteBatFile(string path,string pathProgram)
        //{
        //    string writePath = "";
        //    try
        //    {
               
        //        foreach (var item in pathProgram.Split(Path.DirectorySeparatorChar))
        //        {
        //            string combine = @"\";
        //            if (string.IsNullOrEmpty(writePath))
        //            {
        //                combine = "";
        //            }
        //            if (item.Contains(" "))
        //            {
        //                writePath = writePath + combine + @"""" + item + @"""";
        //            }
        //            else
        //            {
        //                writePath = writePath + combine + item;
        //            }
        //        }
        //        writePath = "start " + writePath;
        //        StreamWriter w = new StreamWriter(path);
        //        w.WriteLine("echo off");
        //        w.WriteLine(writePath);
        //        w.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        public UpdateProgramResult UpdateProgram(List<FileData> fileDatas)
        {
            Log.WriteMessage("1");
            int i = 0;
            var fileList = fileDatas.Select(x => new { x.FileName ,x.FileBinary,x.FileDirectory }).Distinct().ToList();
            foreach (FileData fileData in fileDatas)
            {
                i++;
              
                if (fileData.FileName.Contains(".exe") && !fileData.FileName.Contains(".config"))
                {
                   // FileInfo fi = new FileInfo(Path.Combine(fileData.FileDirectory, fileData.FileName));
                   // FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(fileData.FileDirectory, fileData.FileName));
                   //var versionInfo = FileVersionInfo.GetVersionInfo(Path.Combine(fileData.FileDirectory, fileData.FileName));
                peocessCheck:
                   
                    Process[] processes = Process.GetProcessesByName(fileData.FileName.Replace(".exe", ""));
                    if (processes.Count() >= 1)
                    {
                        Log.WriteMessage("4[" + i + "]");
                        foreach (var process in processes)
                        {
                            Log.WriteMessage("5[" + i + "]");
                            process.Kill();
                            System.Threading.Thread.Sleep(500);
                            Log.WriteMessage("6[" + i + "]");
                        }
                        goto peocessCheck;
                    }
                }
              //  File.Copy(Path.Combine(fileData.FileDirectory, fileData.FileName), Path.Combine(fileData.FileDirectory, fileData.FileName));
            }
           
            foreach (FileData fileData in fileDatas)
            {
                ResultBase result = ByteArrayToFile(Path.Combine(fileData.FileDirectory, fileData.FileName), fileData.FileBinary);
                if (!result.IsPass)
                {
                    return new UpdateProgramResult(false, result.Cause, MethodBase.GetCurrentMethod().Name);
                }
            }
         
            // File.Copy(Path.Combine("path1", "path2"), Path.Combine("path1", "path2"), true);

            return new UpdateProgramResult(true,"",MethodBase.GetCurrentMethod().Name);
        }

        public CheckUpdateResult CheckUpdate(List<FileDataInfo> newFileDatas, List<FileData> oldFileDatas)
        {
            if (oldFileDatas == null || oldFileDatas.Count == 0)
            {
                return new CheckUpdateResult(MethodBase.GetCurrentMethod().Name);
            }
            else
            {
                if (oldFileDatas.Where(x => newFileDatas.Where(y => y.ApplicationSetId != x.ApplicationSetId).Any()).Any())
                {
                    return new CheckUpdateResult(MethodBase.GetCurrentMethod().Name);
                }
            }
            ResultBase isUpdate = CheckCellconVersion(newFileDatas[0].MachineIpAddress);
            if (isUpdate.IsPass)
            {
                return new CheckUpdateResult(MethodBase.GetCurrentMethod().Name);
            }
            return new CheckUpdateResult("ไม่มีการอัพเดทโปรแกรม",false, MethodBase.GetCurrentMethod().Name);
        }
        public ResultBase CheckCellconVersion(string cell_ip)
        {
            bool isUpdate = false;
            DataTable dataTable = new DataTable();
            List<string> machineList = new List<string>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(AppSettingHelper.GetConnectionStringValue("ApcsProConnectionString"));
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " select mc.[machines].[name]  from mc.machines where machines.cell_ip = @cell_ip";
                cmd.Parameters.Add("@cell_ip", SqlDbType.VarChar).Value = cell_ip;
                cmd.Connection.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.HasRows)
                    {
                        dataTable.Load(rd);
                    }
                }
                cmd.Connection.Close();

                foreach (DataRow item in dataTable.Rows)
                {
                    if (item["name"] != DBNull.Value)
                        machineList.Add((string)item["name"]);
                }
            }

            foreach (string mcNo in machineList)
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(AppSettingHelper.GetConnectionStringValue("ApcsProConnectionString"));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "StoredProcedureDB.[cellcon].[sp_get_version]";
                    cmd.Parameters.Add("@mcNo", SqlDbType.VarChar).Value = mcNo;
                    cmd.Connection.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            dataTable = new DataTable();
                            dataTable.Load(rd);
                        }
                    }
                    cmd.Connection.Close();
                    string autoUpdateVersion = "";
                    string processVersion = "";
                    string programeName = "";
                    foreach (DataRow item in dataTable.Rows)
                    {
                        if (item["autoupdate_version"] != DBNull.Value)
                            autoUpdateVersion = (string)item["autoupdate_version"];
                        if (item["process_version"] != DBNull.Value)
                            processVersion = (string)item["process_version"];
                        if (item["cellcon_program"] != DBNull.Value)
                            programeName = (string)item["cellcon_program"];
                    }
                    //if (string.IsNullOrEmpty(processVersion))
                    //{
                    //    //resultBase.Cause = "ยังไม่ได้ใช้งาน auto update กรุณาติดต่อ system";
                    //    resultBase.IsPass = true;
                    //    return resultBase;
                    //}
                    if (processVersion != autoUpdateVersion)
                    {
                        isUpdate = true;
                        //resultBase.IsPass = false;
                        //resultBase.Cause = "กรุณาปิด-เปิดโปรแกรม " + programeName + " ใหม่เพื่อทำการอัพเดทเวอร์ชั่น [" + processVersion + "=>" + autoUpdateVersion + "]";
                        //return resultBase;
                    }
                }
            }
            return new ResultBase(isUpdate,"");
        }
        #region Save and Load Data
        public List<FileData> LoadFile(string path)
        {
            return LoadDataFromXmlFile<List<FileData>>(path);
        }
        public SaveFileResult SaveFile(List<FileData> fileDatas, string path,string fileName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            WriteDataToXmlFile(fileDatas,Path.Combine(path,fileName));
            return new SaveFileResult(true,"",MethodBase.GetCurrentMethod().Name);
        }

        private void WriteDataToXmlFile(object data, string xmlPath)
        {
            using (StreamWriter sw = new StreamWriter(xmlPath, false))
            {
                var bs = new XmlSerializer(data.GetType());
                bs.Serialize(sw, data);
            }
        }
        private T LoadDataFromXmlFile<T>(string xmlPath)
        {
            if (!File.Exists(xmlPath))
            {
                return default(T);
            }

            using (StreamReader fs = new StreamReader(xmlPath))
            {
                var bs = new XmlSerializer(typeof(T));
                T data = (T)bs.Deserialize(fs);
                return data;
            }

        }

        public bool SaveHistoryToDb(int? machineId, int? applicationSetId)
        {
            using (SqlConnection conn = new SqlConnection(AppSettingHelper.GetConnectionStringValue("ApcsProConnectionString")))
            {
                conn.Open();
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
                        command.CommandText = "insert into [APCSProDB].[cellcon].[application_histories] ([machine_id],[application_set_id],[updated_at]) values (@machine_id,@application_set_id, GETDATE());";
                        command.Parameters.AddWithValue("@machine_id", machineId);
                        command.Parameters.AddWithValue("@application_set_id", applicationSetId);
                        var fileId = command.ExecuteScalar();
                        //fileData.BinaryId = int.Parse(fileId.ToString());

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

                        }
                    return false;
                    }
             
                conn.Close();
            }
            return true;
        }


        #endregion

    }
}
