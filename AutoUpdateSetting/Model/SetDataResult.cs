using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdateSetting.Model
{
    public class SetDataResult
    {
        public bool IsPass { get;internal set; }
        public string Cause { get;internal set; }
        /// <summary>
        /// Is Pass
        /// </summary>
        public SetDataResult()
            :this(true,"")
        {

        }
        /// <summary>
        /// Not Pass
        /// </summary>
        /// <param name="cause"></param>
        public SetDataResult(string cause)
            :this(false,cause)
        {

        }
        private SetDataResult(bool isPass,string cause)
        {
            this.IsPass = isPass;
            this.Cause = cause;
            
        }
    }
}
