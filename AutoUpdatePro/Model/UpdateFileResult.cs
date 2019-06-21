using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public UpdateFileResult(string functionName,string cause)
        {
            this.IsPass = false;
            this.Cause = cause;
            Log.WriteMessage(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "|" + functionName + "|" + cause);
        }
        public UpdateFileResult(string functionName)
            :this(functionName,"OK")
        {
            this.IsPass = true;
        }
    }
}
