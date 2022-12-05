using ConsoleApp44.Entities;
using ConsoleApp44.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ConsoleApp44
{
    internal class WorkerProjects
    {
        public static List<Project> GetProjects()
        {
            string initialResponse = "";
            string baseUrl = "/api/projects/search";

            initialResponse = Request.ExecuteRequestGet(baseUrl);
            List<Project> ProjectsList = new List<Project>();

            ProjectsJson _projects = JsonSerializer.Deserialize<ProjectsJson>(initialResponse);

            int total = _projects.paging.total;
            int pages = (total / 500) + 1;

            for (int i = 1; i <= pages; i++)
            {
                string url = baseUrl + "?pageIndex=" + i + "&pageSize=500";
                string response = Request.ExecuteRequestGet(url);
                _projects = JsonSerializer.Deserialize<ProjectsJson>(response);

                ProjectsList.AddRange(_projects.components);
            }

            return ProjectsList;
        }


        public static void Report(Excel.Workbook wb)
        {
            Excel._Worksheet sheet1 = (Excel._Worksheet)wb.ActiveSheet;
            sheet1.Name = "Проекты";

            Console.WriteLine("Создали лист");

            sheet1.Columns["A:B"].ColumnWidth = 25;
            sheet1.Columns["C:C"].ColumnWidth = 15;
            sheet1.Columns["D:E"].ColumnWidth = 35;

            sheet1.Cells[1, 1] = "Имя";
            sheet1.Cells[1, 2] = "Ключ";
            sheet1.Cells[1, 3] = "Дата анализа";
            sheet1.Cells[1, 4] = "Идентификатор";
            sheet1.Cells[1, 5] = "Revision";

            int row = 2;

            foreach (var project in GetProjects())
            {
                sheet1.Cells[row, 1] = project.name;
                sheet1.Cells[row, 2] = project.key;

                if (project.lastAnalysisDate != null)
                    sheet1.Cells[row, 3] = project.lastAnalysisDate.Replace("T", " ").Replace("+0000", "");

                sheet1.Cells[row, 4] = project.id;
                sheet1.Cells[row, 5] = project.revision;

                row++;
            }

        }
    }
}
