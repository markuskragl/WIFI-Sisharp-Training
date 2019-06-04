using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung
{
    /// <summary>
    /// Stellt einen Dienst zum Verwalten der Anwendungssprachen bereit.
    /// </summary>
    public class SprachenManager : WIFI.Anwendung.Anwendungsobjekt
    {
        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private WIFI.Anwendung.Controller.SprachenXmlController _Controller = null;
        //                                  ^-> sollte ein andere Technik zum
        //                                      Speichern der Sprachen benutzt werden,
        //                                      muss nur hier der Typ des Controllers
        //                                      geändert werden, z. B. SprachenSqlController (Datenbank)
        //                                      oder SprachenJsonController ...
        //                                      Der Rest vom SprachenManager bleibt unverändert.


        //public WIFI.Anwendung...
        //^-> nicht erlaubt, weil der Controller "internal" ist
        //    und wir eine Sicherheitsverletzung machen würden

        /// <summary>
        /// Ruft den Dienst zum Verwalten der
        /// externen Sprachen ab.
        /// </summary>
        private WIFI.Anwendung.Controller.SprachenXmlController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller 
                        = this.AppKontext.Erzeuge<WIFI.Anwendung.Controller.SprachenXmlController>();
                    //              ^-> vom Anwendungsobjekt geerbt
                }

                return this._Controller;
            }
        }

        //private WIFI.Anwendung.Daten.Sprache
        //                                ^-> ein Element

        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        private WIFI.Anwendung.Daten.Sprache[] _Liste = null;
        //                                   ^-> jetzt ein statisches C# Array,
        //                                       das später im Umfang nicht 
        //                                       mehr geändert werden kann
        //                                       (eckige Klammern)

        /// <summary>
        /// Ruft die unterstützten Sprachen der Anwendung ab.
        /// </summary>
        public WIFI.Anwendung.Daten.Sprache[] Liste
        {

            //Änderungen
            //20190117  Die Sprachen werden jetzt sortiert nach Name geliefert.

            get
            {
                if (this._Liste == null)
                {
                    /*
                     * 20190119
                    this._Liste = this.Controller.HoleStandardsprachen().ToArray();
                    //                 ^-> hier mit der Eigenschaft und
                    //                     nicht mit dem Feld arbeiten.
                    //                     Die Eigenschaft stellt sicher,
                    //                     dass der Controller ungleich null ist.
                    */

                    this._Liste = (from s in this.Controller.HoleStandardsprachen()
                                   orderby s.Name
                                   select s).ToArray();
                }

                return this._Liste;
            }
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        private Daten.Sprache _AktuelleSprache = null;

        /// <summary>
        /// Ruft die derzeitige Anwendungssprache
        /// ab oder legt diese fest.
        /// </summary>
        /// <remarks>Als Standard wird die erste Sprache
        /// der Liste benutzt.</remarks>
        public Daten.Sprache AktuelleSprache
        {
            get
            {
                if (this._AktuelleSprache == null)
                {
                    this._AktuelleSprache = this.Liste[0];
                }

                return this._AktuelleSprache;
            }
            set
            {
                this._AktuelleSprache = value;
            }
        }

        /// <summary>
        /// Setzt die aktuelle Sprache auf die
        /// Sprache mit dem angegeben Code.
        /// </summary>
        /// <param name="code">Microsoft Kürzel der Sprache,
        /// die zur aktuellen Sprache werden soll.</param>
        /// <remarks>Wird die Sprache nicht gefunden,
        /// wird die erste Sprache der Liste benutzt.
        /// Die Groß-/Kleinschreibung beim Suchen wird
        /// nicht berücksichtigt.</remarks>
        public void Festlegen(string code)
        {
            //                      |------------------------- nur ein LINQ Abfrage --------------------------------------|
            this.AktuelleSprache = (from s in this.Liste where string.Compare(s.Code, code, ignoreCase: true) == 0 select s).FirstOrDefault();
            //                                                                                                                  ^-> muss "materialisiert" werden
            //Sollte die Abfrage die Sprache nicht finden,
            //liefert FirstOrDefault() null
            //Wird das nächste Mal die aktuelle Sprache
            //abgerufen, wird im Getter automatisch
            //wieder die erste Sprache der Liste eingestellt
        }

        /// <summary>
        /// Stellt sicher, dass aktuelle Daten geliefert werden.
        /// </summary>
        public void Aktualisieren()
        {
            //Den Cache wegschmeißen...
            this._Liste = null;

        }
    }
}
