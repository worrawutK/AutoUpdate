using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoUpdateProLibrary.Model
{
    public class ApplicationCellcon
    {
        public List<ApplicationData> ApplicationDatas { get; set; }
        public ApplicationCellcon()
        {
            if (ApplicationDatas == null)
            {
                ApplicationDatas = new List<ApplicationData>();
            }
        }
    }
}
