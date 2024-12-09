using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoUpdateProLibrary.Model;
namespace AutoUpdateProLibrary
{
    public interface IControllerService
    {

        List<FileDataInfo> GetFilesInfo(string cell_Ip);
        List<FileData> GetFiles(int app_Id);
        List<FileData> LoadFile(string path);
        SaveFileResult SaveFile(List<FileData> fileDatas,string path,string fileName);
        CheckUpdateResult CheckUpdate(List<FileDataInfo> newFileDatas, List<FileData> oldFileDatas);
        UpdateResult StartProgram(List<FileData> fileDatas);
        UpdateProgramResult UpdateProgram(List<FileData> newFileDatas);

        bool SaveHistoryToDb(int? machineId,int? applicationSetId);
    }
   
}