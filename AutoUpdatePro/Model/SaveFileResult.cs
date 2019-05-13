using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoUpdateProLibrary.Model
{
    public class SaveFileResult
    {
        public bool IsPass { get;internal set; }
        public string Cause { get;internal set; }
        public string SubFunctionName { get;internal set; }

        public SaveFileResult(bool isPass,string cause,string subFunctionName)
        {
            this.IsPass = isPass;
            this.Cause = cause;
            this.SubFunctionName = subFunctionName;

        }
    }
}
