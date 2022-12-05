using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ConsoleApp44
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add(Type.Missing);

            //создать отчет по проектам
            WorkerProjects.Report(wb);

            string date = DateTime.Now.Date.ToShortDateString();

            wb.SaveAs(@"C:\Отчет " + date + ".xlsx", Type.Missing,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange,
            Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            wb.Close();
            app.Quit();
        }
    }
}
