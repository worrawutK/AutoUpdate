using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoUpdateProLibrary.Model
{
    public class ApplicationData
    {
        public List<FileData> FileDatas { get; set; }
        public ApplicationData()
        {
            if (FileDatas == null)
            {
                FileDatas = new List<FileData>();
            }
        }
    }
}
