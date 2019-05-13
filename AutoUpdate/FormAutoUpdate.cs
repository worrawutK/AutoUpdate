using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AutoUpdate
{
    public partial class FormAutoUpdate : Form
    {
        public SynchronizationContext _SynchronizationContext;
        public FormAutoUpdate()
        {
            InitializeComponent();
            c_DataSetDB = new DataSetDB();
            c_ProgramCellconAdapters = new DataSetDBTableAdapters.ProgramCellconTableAdapter();
            c_ProgramTableAll = new DataSetDB.ProgramCellconDataTable();
        }
        private DataSetDB c_DataSetDB;
        private DataSetDB.ProgramCellconDataTable c_ProgramTableAll;
        private DataSetDBTableAdapters.ProgramCellconTableAdapter c_ProgramCellconAdapters;

        private void FormAutoUpdate_Load(object sender, EventArgs e)
        {
            _SynchronizationContext = SynchronizationContext.Current;
            Thread thread1 = new Thread(UpdateProgram);
            
            thread1.Start();
            return;
            
        }
        private void CloseProgram(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                DialogResult result = MessageBox.Show(message + " ต้องการโหลดใหม่อีกครั้ง?","",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Thread thread1 = new Thread(UpdateProgram);
                    thread1.Start();
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            this.Close();
        }
        private void UpdateProgram()
        {
            Thread.Sleep(4000);
            string con = AppSettingHelper.GetConnectionStringValue("AutoUpdate.Properties.Settings.DbConnectionString");
            string ip = con.Split(';')[0].Split('=')[1];
            Ping ping = new Ping();
            PingReply reply = ping.Send(ip, 1000);
            if (reply.Status != IPStatus.Success)
            {
                _SynchronizationContext.Post(x => CloseProgram("ไม่สามารถเชื่อมต่อ Server ได้"), null);
                return;
            }         

            if (!bool.Parse(AppSettingHelper.GetAppSettingsValue("IsAutoUpdate")))
            {
                //ปิดการอัพเดท
                return;
            }
            //Get Paht Program
            c_ProgramTableAll = c_ProgramCellconAdapters.GetData(AppSettingHelper.GetAppSettingsValue("MCType"));

            //Select coulum => ProgramName,PahtLocal,PahtRemote,IsActive
            var programTable = c_ProgramTableAll.Select(x => new { x.ProgramName, x.PahtLocal, x.PahtRemote, x.IsActive }).Distinct();


            foreach (var program in programTable)
            {
                //Check Paht Exists
                if (!Directory.Exists(program.PahtLocal))
                {
                    Directory.CreateDirectory(program.PahtLocal);
                }

                //get file
                List<FileInfo> fileLocal = GetFile(program.PahtLocal);
                List<FileInfo> fileRemote = GetFile(program.PahtRemote);
             
                //var programTableAll = c_ProgramTableAll.Where(y => y.ProgramName == program.ProgramName.Trim())
                //    .Where(x => fileRemote.Select(r => r.FileName).Contains(x.FileName.Trim())).ToList();
                
                var programTableAll = from fileAll in c_ProgramTableAll
                                      join fileR in fileRemote 
                                      on fileAll.FileName.Trim() equals fileR.FileName.Trim()
                                      where fileAll.ProgramName == program.ProgramName
                                      select fileAll;

                foreach (var item in programTableAll)
                {
                    //Path.GetDirectoryName(Application.ExecutablePath)
                    if (fileLocal.Where(l => l.FileName == item.FileName).Select(ls => ls.ModifiedDate) != fileRemote.Where(r => r.FileName == item.FileName).Select(rs => rs.ModifiedDate))
                    {
                         File.Copy(Path.Combine(item.PahtRemote, item.FileName), Path.Combine(item.PahtLocal, item.FileName), true);                        
                    }

                }
                if (program.IsActive)
                {

                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(Path.Combine(program.PahtLocal, program.ProgramName));
                    //Process.Start(Path.Combine(program.PahtLocal, program.ProgramName));
                    ProcessStartInfo processStartInfo = new ProcessStartInfo()
                    {
                        FileName = fileInfo.FullName,
                        WorkingDirectory = fileInfo.DirectoryName
                    };
                    Process.Start(processStartInfo);
                }
            }
            _SynchronizationContext.Post(x => CloseProgram(""), null);
            //timer1.Start();
        }
     
        private List<FileInfo> GetFile(string path)
        {
            List<FileInfo> files = new List<FileInfo>();
            
            var pathFiles = Directory.GetFileSystemEntries(path);
           // var xxx = Directory.GetFileSystemEntries(path);
            foreach (string pathFile in pathFiles)
            {
                FileInfo file = new FileInfo();
                file.FileName = Path.GetFileName(pathFile).Trim();
                file.ModifiedDate = File.GetLastWriteTime(pathFile);
                files.Add(file);
            }
            return files;
        }

    }
    //public class ProgramInfo
    //{
    //    public string ProgramName { get; set; }
    //    public string PahtLocal { get; set; }
    //    public string PahtRemote { get; set; }
    //    public List<FileInfo> LocalFileInfoList { get; set; }
    //    public List<FileInfo> RemoteFileInfoList { get; set; }
    //}
    public class FileInfo
    {
        public string FileName { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
