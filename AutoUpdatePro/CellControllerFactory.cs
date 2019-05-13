using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoUpdateProLibrary.Control;
namespace AutoUpdateProLibrary
{
    class CellControllerFactory
    {
        //internal static Controller Create()
        //{
        //    //ex: "WBData" + "ProductionDatamapper"
        //    //string className = AppSettingHelper.GetAppSettingsValue("CellControllerClass");
        //    //return (Controller)Activator.CreateInstance("AutoUpdatePro",
        //    //    "AutoUpdatePro." + className).Unwrap();
        //    return new Controller();
        //}
        internal static IControllerService CreateInterface()
        {
            //ex: "WBData" + "ProductionDatamapper"
            string className = AppSettingHelper.GetAppSettingsValue("ControllerService");
            return (IControllerService)Activator.CreateInstance("AutoUpdateProLibrary",
                "AutoUpdateProLibrary.Control." + className).Unwrap();
        }
    }
}
