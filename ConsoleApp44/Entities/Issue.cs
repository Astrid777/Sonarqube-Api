using ConsoleApp44.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace ConsoleApp44
{
    //получить список уязвимостей
    internal class IssuesJson
    {
        public int total { get; set; } //кол-во объектов
        public int p { get; set; } //номер
        public int ps { get; set; } //кол-во объектов на стр

        public List<Issue> issues { get; set; }

        public string projectKey { get; set; }

        public string projectName { get; set; }

        public string Branch { get; set; }
    }

    public class Comment
    {
        public string key { get; set; }
        public string login { get; set; }
        public string htmlText { get; set; }
        public string markdown { get; set; }
        public bool updatable { get; set; }
        public string createdAt { get; set; }
    }

    public class Issue
    {
        public string key { get; set; }
        public string rule { get; set; }
        public string severity { get; set; }
        public string component { get; set; }
        public string project { get; set; }
        public int line { get; set; }
        //flows
        public string resolution { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string effort { get; set; }
        public string debt { get; set; }
        public string assignee { get; set; }
        public string author { get; set; }
        public List<string> tags { get; set; }
        public List<Comment> comments { get; set; }

        public string creationDate { get; set; }
        public string updateDate { get; set; }
        public string type { get; set; }
        public string organization { get; set; }
        public bool fromHotspot { get; set; }
    }

    //для запроса
    public class pageInfo
    {
        public string nameColumn { get; set; }
    }

    
    public class IssuesApi
    {
        
    }
}
