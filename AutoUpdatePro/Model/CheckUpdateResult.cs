using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoUpdateProLibrary
{
    public class CheckUpdateResult
    {
        public bool IsUpdate { get;internal set; }
        public string Cause { get;internal set; }
        public bool IsAlarm { get;internal set; }
        public string SubFunctionName { get;internal set; }
        private CheckUpdateResult(bool isUpdate,string cause,bool alarm,string functionName)
        {
            this.IsUpdate = isUpdate;
            this.Cause = cause;
            this.IsAlarm = alarm;
            this.SubFunctionName = functionName;
        } 
        /// <summary>
        /// Not Update
        /// </summary>
        /// <param name="cause"></param>
        /// <param name="alarm"></param>
        /// <param name="functionName"></param>
        public CheckUpdateResult(string cause,bool alarm,string functionName)
            :this(false,cause, alarm, functionName)
        {

        }
        /// <summary>
        /// IsUpdate
        /// </summary>
        /// <param name="functionName"></param>
        public CheckUpdateResult(string functionName)
            :this(true,"",false, functionName)
        {

        }
    }
}
