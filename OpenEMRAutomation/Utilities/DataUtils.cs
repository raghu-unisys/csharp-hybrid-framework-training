using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unisys.OpenEMRAutomation.Utilities
{
    public class DataUtils
    {
        // creaing a data source that we send to all the other test, we will create a 2D array
        public static object[] ValidLoginData()
        {
            object[] data1 = new object[4];
            data1[0] = "admin";
            data1[1] = "pass";
            data1[2] = "English (Indian)";
            data1[3] = "OpenEMR";

            object[] data2 = new object[4];
            data2[0] = "physician";
            data2[1] = "physician";
            data2[2] = "English (Indian)";
            data2[3] = "OpenEMR";

            object[] allDataSet = new object[2];
            allDataSet[0] = data1;
            allDataSet[1] = data2;

            return allDataSet;
        }


    }
}
