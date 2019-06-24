using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Timers;
using AutoUpdateProLibrary.Model;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace AutoUpdateProLibrary
{
    public class Controller
    {
        protected IControllerService c_ControllerService;
        public IControllerService ControllerService
        {
            get { return c_ControllerService; }
            set
            {
                c_ControllerService = value;
            }
        }
        private List<FileData> c_FileDatas;
        private readonly string c_CellIp;
        public Controller()
        {
            ControllerService = CellControllerFactory.CreateInterface();
            c_CellIp = AppSettingHelper.GetAppSettingsValue("CellConIp");
            c_FileDatas = new List<FileData>();
        }
        public UpdateFileResult UpdateFile()
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                string path = Directory.GetCurrentDirectory();// @"";
                string fileName = "ProgramData.xml";
                string pathBackpup = Path.Combine(Directory.GetCurrentDirectory(), "Backup");
                c_FileDatas = c_ControllerService.LoadFile(Path.Combine(path, fileName));


                List<FileDataInfo> newFileInfo = c_ControllerService.GetFilesInfo(c_CellIp);

                //ตรวจสอบโปรแกรมของแต่ละเครื่องว่าเหมือนกันหรือไม่ กรณี 1:N
                var datas = newFileInfo.Select(x => new { x.ApplicationSetId,x.MachineId }).Distinct().ToList();
                var application = datas.Select(x => new { x.ApplicationSetId }).Distinct().ToList();
                if (application.Count > 1)
                {
                    return new UpdateFileResult(MethodBase.GetCurrentMethod().Name, "โปรแกรม Machine ไม่ตรงกัน กรุณาติดต่อ System เพื่อเช็คโปรแกรมของ Machine  \nCellconIP:" + AppSettingHelper.GetAppSettingsValue("CellConIp"));
                }else if (datas.Count == 0)
                {
                    return new UpdateFileResult(MethodBase.GetCurrentMethod().Name, "Cellcon Ip:" + c_CellIp + " ยังไม่ได้ถูก Set Machine ไว้ กรุณาติดต่อ System ");
                }
                ////เลือกใช้โปรแกรมของ Machine เดียว *โปรแกรมแต่ละเครื่องเหมือนกัน
                //var programMachine = newFileInfo.Select(x => x.MachineId).Distinct().ToList();
                //var programCellcon = newFileInfo.Where(x => x.MachineId == programMachine[0]).ToList();

                CheckUpdateResult checkUpdateResult = c_ControllerService.CheckUpdate(newFileInfo, c_FileDatas);
                if (!checkUpdateResult.IsUpdate)
                {
                    if (c_FileDatas == null)
                    {
                        return new UpdateFileResult(MethodBase.GetCurrentMethod().Name, checkUpdateResult.Cause);
                    }
                    //Start Program
                    c_ControllerService.StartProgram(c_FileDatas);
                    if (checkUpdateResult.IsAlarm)
                    {
                        return new UpdateFileResult(MethodBase.GetCurrentMethod().Name, checkUpdateResult.Cause);
                    }
                    Debug.Print("Not Update:" + (DateTime.Now - dateTime).ToString());
                    return new UpdateFileResult(MethodBase.GetCurrentMethod().Name);
                }

                Debug.Print("Before GetFiles:" + (DateTime.Now - dateTime).ToString());
                List<FileData> newFileData = c_ControllerService.GetFiles((application.FirstOrDefault()).ApplicationSetId);
                Debug.Print("After GetFiles:" + (DateTime.Now - dateTime).ToString());
                //Backup Old File
                if (!(c_FileDatas == null || c_FileDatas.Count == 0))
                {
                    SaveFileResult saveFileResult = c_ControllerService.SaveFile(c_FileDatas, pathBackpup, fileName);
                    if (!saveFileResult.IsPass)
                    {
                        return new UpdateFileResult(MethodBase.GetCurrentMethod().Name, saveFileResult.Cause);
                    }
                }
                c_FileDatas = newFileData;
                //Coppy new file to old file (Replete)
                Debug.Print("Before UpdateProgram:" + (DateTime.Now - dateTime).ToString());
                UpdateProgramResult updateProgramResult = c_ControllerService.UpdateProgram(c_FileDatas);
                Debug.Print("After UpdateProgram:" + (DateTime.Now - dateTime).ToString());
                if (!updateProgramResult.IsPass)
                {
                    return new UpdateFileResult(MethodBase.GetCurrentMethod().Name, updateProgramResult.Cause);
                }
                //save history to DbApcsPro
                foreach (var item in datas)
                {
                    c_ControllerService.SaveHistoryToDb(item.MachineId,item.ApplicationSetId);
                }
               


                c_ControllerService.SaveFile(c_FileDatas, path, fileName);

                //Start Program
                UpdateResult updateResult = c_ControllerService.StartProgram(c_FileDatas);
                Debug.Print("Update:" + (DateTime.Now - dateTime).ToString());
                return new UpdateFileResult(MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                return new UpdateFileResult(MethodBase.GetCurrentMethod().Name, ex.Message.ToString());
            }
            
        }
        
        //private List<Model.ApplicationCellcon> GetFile(string path)
        //{
          
        //    var pathFiles = Directory.GetFileSystemEntries(path);
        //    foreach (string pathFile in pathFiles)
        //    {
        //        string name = Path.GetFileName(pathFile).Trim();
        //        DateTime modifiedDate = File.GetLastWriteTime(pathFile);
        //        if (Path.GetExtension(pathFile) == "")
        //        {
        //            GetFile(pathFile);
        //        }

        //    }
        //    return null;
        //}


    }
}
