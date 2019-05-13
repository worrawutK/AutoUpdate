using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdateSetting.Model
{
    public class MachineData
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public bool MachineSelect { get; set; }
        public int CellconId { get; set; }
        public string CellconName { get; set; }
        public string CellconVersion { get; set; }
        public int ApplicationSetId { get; set; }
    }
}
