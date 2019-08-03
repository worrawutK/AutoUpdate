using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdateSetting.Model
{
    public class ProgramData
    {
        //Cellcon
        public int Cell_Id { get; set; }
        public string Cell_Name { get; set; }
        public string Cell_Version { get; set; }
        public DateTime? Cell_Update_At { get; set; }

        //Application
        public int App_Id { get; set; }
        public string App_Name { get; set; }
        public string App_Version { get; set; }
        public DateTime? App_Update_At { get; set; }

        //File
        public int File_Id { get; set; }
        public string File_Directory { get; set; }
        public string File_Name { get; set; }
        public DateTime? File_Update_At { get; set; }
        public string File_Version { get; set; }
        public int File_Binary_Id { get; set; }

    }
}
