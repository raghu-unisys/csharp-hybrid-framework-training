using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unisys.OpenEMRAutomation
{
    public class DemoTest
    {
        [Test]
        public void ReadExcelTest()
        {
            XLWorkbook book = new XLWorkbook(@"C:\Users\RRaghuna\OneDrive - Unisys\Documents\~The Docs\Trainings\SeleniumC#Training\AutomationSolution\OpenEMRAutomation\TestData\open_emr_data.xlsx");
            // getting the sheet in the excel document
            var sheet = book.Worksheet("ValidLoginTest");
            // getting the range of sheets
            var range = sheet.RangeUsed();
            int rowCount = range.RowCount();
            int columnCount = range.ColumnCount();

            Console.WriteLine(rowCount + " " + columnCount);

            // getting the element in a cell
            string cellValue = range.Cell(1, 1).GetString();
            Console.WriteLine(cellValue);

            object[] allDataSet = new object[rowCount];
            // printing the values of all the cells. The creating the object for data source
            for (int i = 1; i <= rowCount; i++)
            {
                object[] data = new object[columnCount];
                for (int j = 1; j <= columnCount; j++)
                {
                    Console.Write(range.Cell(i, j).GetString() + "\t");
                    data[j - 1] = range.Cell(i, j).GetString();
                }
                Console.WriteLine();
                allDataSet[i - 2] = data;
            }

            book.Dispose();
        }
    }
}
