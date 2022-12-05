using ConsoleApp44.Entities;
using ConsoleApp44.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ConsoleApp44.Workers
{
    //Для составления отчета о плагинах

    internal class PluginsList
    {
        public List<PluginInstalled> plugins { get; set; }
    }

    internal class PluginReport
    {
        public static List<PluginInstalled> GetItemsApi(string type)
        {
            string initialResponse = "";

            string baseUrl = "/api/plugins/" + type;

            initialResponse = Request.ExecuteRequestGet(baseUrl);

            var items = JsonSerializer.Deserialize<PluginsList>(initialResponse);

            return items.plugins;
        }

        public static void ReportInstalled(Excel.Workbook wb)
        {
            Excel._Worksheet ws1 = (Excel._Worksheet)wb.ActiveSheet;
            ws1.Name = "Плагины";
            ws1.Columns.ColumnWidth = 25;

            int col = 1;
            //пишем названия
            foreach (var prop in typeof(PluginInstalled).GetProperties())
            {
                ws1.Cells[1, col++] = prop.Name;
            }

            int str = 2;

            foreach (var state in GetItemsApi("installed"))
            {
                col = 1;
                foreach (var sProp in state.GetType().GetProperties())
                {
                    if (sProp.GetValue(state) != null)
                        ws1.Cells[str, col] = sProp.GetValue(state).ToString();
                    col++;
                }
                str++;
            }
        }

        public static void ReportAvailable(Excel.Workbook wb)
        {
            Excel._Worksheet ws1 = (Excel._Worksheet)wb.ActiveSheet;
            ws1.Name = "Плагины";
            ws1.Columns.ColumnWidth = 25;

            int col = 1;

            //пишем названия
            foreach (var prop in typeof(PluginAvailable).GetProperties())
            {
                ws1.Cells[1, col++] = prop.Name;
            }

            int str = 2;

            foreach (var state in GetItemsApi("available"))
            {
                col = 1;
                foreach (var sProp in state.GetType().GetProperties())
                {
                    if (sProp.GetValue(state) != null)
                        ws1.Cells[str, col] = sProp.GetValue(state).ToString();
                    col++;
                }
                str++;
            }

        }


        public static PluginPendingList GetItemsPending()
        {
            string initialResponse = "";
            string baseUrl = "/api/plugins/pending";

            initialResponse = Request.ExecuteRequestGet(baseUrl);

            var items = JsonSerializer.Deserialize<PluginPendingList>(initialResponse);

            var result = new List<PluginPending>();

            return items;
        }


        public static void ReportPending(Excel.Workbook wb)
        {
            Excel._Worksheet ws1 = (Excel._Worksheet)wb.ActiveSheet;
            ws1.Name = "Плагины";
            ws1.Columns.ColumnWidth = 25;

            Console.WriteLine("Создали лист");

            int col = 1;
            //пишем названия
            foreach (var prop in typeof(PluginAvailable).GetProperties())
            {
                ws1.Cells[1, col++] = prop.Name;
            }

            int str = 2;


            foreach (var state in GetItemsPending().installing)
            {
                col = 2;
                foreach (var sProp in state.GetType().GetProperties())
                {
                    if (sProp.GetValue(state) != null)
                        ws1.Cells[str, col] = sProp.GetValue(state).ToString();
                    col++;
                }

                ws1.Cells[str, 1] = "installing";

                str++;
            }


            foreach (var state in GetItemsPending().updating)
            {
                col = 2;
                foreach (var sProp in state.GetType().GetProperties())
                {
                    if (sProp.GetValue(state) != null)
                        ws1.Cells[str, col] = sProp.GetValue(state).ToString();
                    col++;
                }

                ws1.Cells[str, 1] = "updating";

                str++;
            }

            foreach (var state in GetItemsPending().removing)
            {
                col = 2;
                foreach (var sProp in state.GetType().GetProperties())
                {
                    if (sProp.GetValue(state) != null)
                        ws1.Cells[str, col] = sProp.GetValue(state).ToString();
                    col++;
                }

                ws1.Cells[str, 1] = "removing";

                str++;
            }
        }
    }
}
