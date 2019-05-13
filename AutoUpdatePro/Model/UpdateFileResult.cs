using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rohm.Common.Logging;
namespace AutoUpdateProLibrary.Model
{
    public class UpdateFileResult
    {
        public bool IsPass { get;internal set; }
        public string Cause { get; internal set; }
        //public UpdateFileResult(string cause,Logger log, string functionName, string subFunctionName)
        //    :this(false,cause,log, functionName, subFunctionName)
        //{
          
        //}
        //public UpdateFileResult(Logger log, string functionName, string subFunctionName)
        //    :this(true,"", log, functionName, subFunctionName)
        //{

        //}
        public UpdateFileResult(bool isPass,string cause,Logger log, string functionName, string subFunctionName)
        {
            this.IsPass = isPass;
            this.Cause = cause;
            string typeState = "Error";
            if (IsPass)
            {
                typeState = "Normal";
            }
            log.OperationLogger.Write(0, functionName, typeState, "", "", 0, subFunctionName, cause, "");
        }
    }
}
