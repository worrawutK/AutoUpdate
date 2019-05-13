using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdateSetting.Model
{
    public  class ApplicationData
    {
        public ApplicationData()
        {
           // FileDatas = new List<FileData>();
        }

        public List<FileData> FileDataList { get; set; }
        public string ApplictionName { get; set; }
        public string ApplictionVersion { get; set; }
        public int ApplicationId { get; set; }
        public bool ApplicationSelect { get; set; }

    }
}
