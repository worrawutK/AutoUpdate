using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdateSetting.Model
{
    public class CellconData
    {
        public int CellconId { get; set; }
        public string CellconName { get; set; }
        public string CellconVersion { get; set; }
        public bool CellconSelect { get; set; }

        public List<ApplicationData> ApplicationDataList { get; set; }
    }
}
