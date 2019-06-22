using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoUpdateProLibrary.Model;
namespace AutoUpdateProLibrary
{
    public interface IControllerService
    {

        List<FileData> GetFilesData(string cell_Ip);
        List<FileData> LoadFile(string path);
        SaveFileResult SaveFile(List<FileData> fileDatas,string path,string fileName);
        CheckUpdateResult CheckUpdate(List<FileData> newFileDatas, List<FileData> oldFileDatas);
        UpdateResult StartProgram(List<FileData> fileDatas);
        UpdateProgramResult UpdateProgram(List<FileData> newFileDatas);

        bool SaveHistoryToDb(int? machineId,int? applicationSetId);
    }
   
}