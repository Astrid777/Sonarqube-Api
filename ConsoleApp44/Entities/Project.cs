using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp44.Entities
{
    //выгрузить список проектов

    internal class ProjectsJson
    {
        public Paging paging { get; set; }

        public List<Project> components { get; set; }
    }

    public class Paging
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
    }

    public class Project
    {
        //организация, левая
        public string organization { get; set; }

        public string id { get; set; }

        public string key { get; set; }

        public string name { get; set; }

        //квалификатор
        public string qualifier { get; set; }
        //прозрачность
        public string visibility { get; set; }

        //последняя дата анализа
        public string lastAnalysisDate { get; set; }

        //[JsonPropertyName("revision")]
        //?
        public string revision { get; set; }
    }


}
