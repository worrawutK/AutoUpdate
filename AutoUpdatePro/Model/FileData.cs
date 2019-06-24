using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoUpdateProLibrary.Model
{
    public class FileData
    {
        //public int MachineId { get; set; }
        //public string MachineIpAddress { get; set; }
        //public string MachineName { get; set; }


        public int ApplicationSetId { get; set; }
        public string ApplicationSetName { get; set; }
        public string ApplicationSetVersion { get; set; }

        public int ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationVersion { get; set; }


        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FileDirectory { get; set; }
        public string FileVersion { get; set; }
        public byte[] FileBinary { get; set; }


        private DateTime? c_ModifyDate;

        public DateTime? ModifyDate
        {
            get { return c_ModifyDate; }
            set { c_ModifyDate = value; }
        }

    }
}
