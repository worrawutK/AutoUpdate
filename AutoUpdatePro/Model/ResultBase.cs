using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoUpdateProLibrary.Model
{
    public class ResultBase
    {
        public bool IsPass { get;internal set; }
        public string Cause { get;internal set; }
        public ResultBase(bool isPass,string cause)
        {
            this.IsPass = isPass;
            this.Cause = cause;
        }
    }
}
