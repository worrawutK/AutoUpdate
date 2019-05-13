using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdateSetting.Model
{
    public class FileData:INotifyPropertyChanged
    {
      
        private int? c_BinaryId;

        public int? BinaryId
        {
            get { return c_BinaryId; }
            set { c_BinaryId = value; ReportPropertyChanged("BinaryId");}
        }
        private string c_Name;

        public string Name
        {
            get { return c_Name; }
            set { c_Name = value;ReportPropertyChanged("Name"); }
        }
        private string c_FileVersion;

        public string FileVersion
        {
            get { return c_FileVersion; }
            set { c_FileVersion = value;ReportPropertyChanged("FileVersion"); }
        }

        private string c_Directory;

        public string Directory
        {
            get { return c_Directory; }
            set { c_Directory = value; }
        }

        private byte[] c_Data;

        public byte[] Data
        {
            get { return c_Data; }
            set { c_Data = value; ReportPropertyChanged("Data"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void ReportPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private int c_FileId;

        public int FileId
        {
            get { return c_FileId; }
            set { c_FileId = value; }
        }

        private DateTime? c_Date;

        public DateTime? Date
        {
            get { return c_Date; }
            set { c_Date = value; }
        }

        public bool FileSelect { get; set; }
        public StatusFile Status { get; set; }

        public enum StatusFile
        {
            Local,
            Server
        }
        
    }

}
