using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICaller
{
    public class ConfigReader
    {
        public string test {  get; set; }
        public string fichero { get; set; }
        public string ficheroPizza {  get; set; }

        public ConfigReader() {
            test = ConfigurationManager.AppSettings["test"];
            //fichero = ConfigurationManager.AppSettings["ficheroXML"];
            ficheroPizza = ConfigurationManager.AppSettings["ficheroPizza"];
        }
    }
}
