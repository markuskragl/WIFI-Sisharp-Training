using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Z_NL_Training.Zusatzinformation
{
    class Program
    {
        static void Main(string[] args)
        {
            var Xml = new System.Xml.XmlDocument();
            List<string> list = new List<string>();
            Xml.LoadXml(Properties.Resources.XMLFile1);

            var comp = System.Reflection.Assembly.GetEntryAssembly()
                .GetCustomAttributes(typeof(System.Reflection.AssemblyCompanyAttribute), false);

            Console.WriteLine(Xml.DocumentElement.ChildNodes.Item(1).Attributes["code"].Value);
            Console.WriteLine(((System.Reflection.AssemblyCompanyAttribute)comp[0]).Company);
            Console.Read();
        }
    }
}
