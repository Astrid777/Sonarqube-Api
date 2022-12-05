using ConsoleApp44.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp44.Workers
{
    internal class WorkerIssues
    {
        public static List<Issue> GetIssues()
        {
            var dateToString = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");

            Console.WriteLine("Конфигурация");
            Console.WriteLine("Ищем до даты: " + dateToString);

            string initialResponse = "";
            string severities = "CRITICAL,BLOCKER";
            string additionalFields = "_all";

            string baseUrl = "/api/issues/search?ps=500&types=VULNERABILITY,SECURITY_HOTSPOT&additionalFields=_all&" + "severities=" + severities;
            //string baseUrl = "/api/issues/search?ps=500&types=VULNERABILITY,SECURITY_HOTSPOT&additionalFields=_all";

            string types = "VULNERABILITY";

            Console.WriteLine("Severities: " + severities);
            Console.WriteLine("Тип: " + types);

            List<Issue> IssueList = new List<Issue>();

            initialResponse = Request.ExecuteRequestGet(baseUrl);
            IssuesJson _issues = JsonSerializer.Deserialize<IssuesJson>(initialResponse);
            int total = _issues.total;
            int pages = (total / 500) + 1;

            for (int i = 1; i <= pages; i++)
            {
                string url = baseUrl + "&p=" + i;
                string response = Request.ExecuteRequestGet(url);
                _issues = JsonSerializer.Deserialize<IssuesJson>(response);
                IssueList.AddRange(_issues.issues);
            }
            Console.WriteLine("Уязвимостей нашлось всего = " + _issues.total);

            return IssueList;
        }
    }
}
