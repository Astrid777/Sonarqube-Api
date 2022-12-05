using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp44
{
    //описание плагинов

    //доступные плагины
    internal class PluginAvailable
    {
        public string key { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string license { get; set; }
        public string organizationName { get; set; }
        public string organizationUrl { get; set; }
        public string termsAndConditionsUrl { get; set; }
        public bool editionBundled { get; set; }
        public object release { get; set; }
        public object update { get; set; }

    }

    //доступные для обновления
    internal class PluginUpdates
    {
        public string key { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string license { get; set; }
        public string organizationName { get; set; }
        public string organizationUrl { get; set; }
        public string termsAndConditionsUrl { get; set; }
        public bool editionBundled { get; set; }
        public object release { get; set; }
        public object update { get; set; }
    }


    internal class PluginPendingList
    {
        public List<PluginPending> installing { get; set; }
        public List<PluginPending> updating { get; set; }
        public List<PluginPending> removing { get; set; }

    }

    //плагины, ожидающие установки
    internal class PluginPending
    {
        public string key { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string version { get; set; }
        public string category { get; set; }
        public string license { get; set; }
        public string organizationName { get; set; }
        public string organizationUrl { get; set; }
        public string homepageUrl { get; set; }
        public string issueTrackerUrl { get; set; }
        public string implementationBuild { get; set; }
    }

    //установленные плагины
    internal class PluginInstalled
    {
        public string key { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string version { get; set; }
        public string license { get; set; }
        public string organizationName { get; set; }
        public string organizationUrl { get; set; }
        public bool editionBundled { get; set; }
        public string homepageUrl { get; set; }
        public string issueTrackerUrl { get; set; }
        public string implementationBuild { get; set; }
        public string filename { get; set; }
        public string hash { get; set; }
        public bool sonarLintSupported { get; set; }
        public object updatedAt { get; set; }
    }
}
