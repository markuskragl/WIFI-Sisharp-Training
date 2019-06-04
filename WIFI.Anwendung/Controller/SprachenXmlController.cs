using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung.Controller
{
    /// <summary>
    /// Stellt einen Dienst zum Lesen und Schreiben
    /// von Anwendungssprachen aus bzw. in eine Xml Datei bereit.
    /// </summary>
    //20190117
    //internal class SprachenXmlController : WIFI.Anwendung.Anwendungsobjekt
    internal class SprachenXmlController : Generisch.XmlController<Daten.SpracheListe>
    {
        
        /// <summary>
        /// Gibt die Sprachen aus den Ressourcen zurück.
        /// </summary>
        public WIFI.Anwendung.Daten.SpracheListe HoleStandardsprachen()
        {
            var Xml = new System.Xml.XmlDocument();
            var Ergebnis = new WIFI.Anwendung.Daten.SpracheListe();

            Xml.LoadXml(WIFI.Anwendung.Properties.Resources.Sprachen);

            foreach (System.Xml.XmlNode s in Xml.DocumentElement.ChildNodes)
            {
                //s.Attributes[0]
                //             ^-> Tipp, nicht mit Zahlen auf ein
                //                 Element zugreifen.
                //                 Warum? Weil sich die Reihenfolge der Daten ändern kann

                Ergebnis.Add(
                    new WIFI.Anwendung.Daten.Sprache
                    {
                        Code = s.Attributes["code"].Value,
                        Name = s.Attributes["name"].Value
                    }
                    );

            }

            return Ergebnis;
        }

    }
}
