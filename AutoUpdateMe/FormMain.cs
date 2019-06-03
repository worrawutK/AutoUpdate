using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using Rohm.Common.Logging;
namespace AutoUpdateMe
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        //private void CreateXml()
        //{
        //    Config config = new Config();
        //    //string localPath = AppSettingHelper.GetAppSettingsValue("LocalPath");
        //    //if (localPath == "NULL")
        //    //{
        //    //    localPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        //    //}
        //    //config.LocalPath = localPath;
        //    config.RemotePath = AppSettingHelper.GetAppSettingsValue("RemotePath");

        //    WriteDataToXmlFile(config, Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Config.xml"));
        //}
        private void WriteDataToXmlFile(object data, string xmlPath)
        {
            string path = Path.GetDirectoryName(xmlPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (StreamWriter sw = new StreamWriter(xmlPath, false))
            {
                var bs = new XmlSerializer(data.GetType());
                bs.Serialize(sw, data);
            }
        }
        private T LoadXmlToObject<T>(string xmlPath)
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
    
        private void CoppyFile(List<FileInfo> fileInfos)
        {
            foreach (var fileInfo in fileInfos)
            {
                File.Copy(fileInfo.FullName, Path.Combine(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Application.ExecutablePath)), fileInfo.Name),true);
            }
        }
        private List<FileInfo> GetFilesInfo(string path)
        {
            var files = Directory.GetFiles(path);

            List<FileInfo> fileInfos = new List<FileInfo>();
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                fileInfos.Add(fileInfo);
            }
            return fileInfos;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            backgroundWorker1.RunWorkerAsync();
        }
        private new void Update()
        {
            Logger logger = new Logger("1.0.0.0", "AutoUpdateMe");
            try
            {
                Config config = new Config();
                config = LoadXmlToObject<Config>(Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Config.xml"));
                if (!Directory.Exists(config.RemotePath))
                {
                    //save log

                    logger.ConnectionLogger.Write(0, "Directory.Exists", "", "", "", 0, "Directory.Exists", config.RemotePath, "");
                    return;
                }

                List<FileInfo> fileInfosLocal = GetFilesInfo(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Application.ExecutablePath)));
                List<FileInfo> fileInfosRemote = GetFilesInfo(config.RemotePath);
                List<FileInfo> fileDatas = new List<FileInfo>();
                foreach (FileInfo fileInfo in fileInfosRemote)
                {
                    if (fileInfosLocal.Where(x => x.Name == fileInfo.Name && x.LastWriteTime != fileInfo.LastWriteTime).Any())
                    {
                        fileDatas.Add(fileInfo);
                    }
                }
                CoppyFile(fileDatas);
            }
            catch (Exception ex)
            {
                logger.ConnectionLogger.Write(0, "AutoUpdateMe", "", "", "", 0, "Exception", ex.Message.ToString(), "");
            }
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);
            Update();
       
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
