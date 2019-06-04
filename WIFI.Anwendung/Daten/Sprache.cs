using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung.Daten
{

    /// <summary>
    /// Stellt eine Liste von Anwendungssprachen bereit.
    /// </summary>
    public class SpracheListe : System.Collections.Generic.List<Sprache>
    {
        /// <summary>
        /// Gibt die Sprache mit dem Microsoft Code zurück.
        /// </summary>
        /// <param name="code">Microsoft Code der Sprache, die gesucht wird.</param>
        /// <returns>Null, falls die Sprache nicht vorhanden ist.</returns>
        /// <remarks>Die Groß-/Kleinschreibung wird ignoriert.</remarks>
        public Sprache Suchen(string code)
        {
            //Hier wird die Groß-/Kleinschreibung berücksichtigt!
            //return this.Find(s => s.Code == code);
            //                 |------------------|
            //                  Predicate-Delegate erfordert Boolean

            //return this.Find(s => string.Compare(s.Code, code, ignoreCase: true));
            //                                  ^-> liefert Integer

            return this.Find(s => string.Compare(s.Code, code, ignoreCase: true) == 0);
            //                    |-------------------------------------------------|
            //                          jetzt haben wir unser Boolean
        }
    }

    /// <summary>
    /// Stellt Information über eine
    /// Anwendungssprache bereit.
    /// </summary>
    /// <remarks>Eine Liste aller Codes 
    /// ist unter https://msdn.microsoft.com/en-us/library/cc233982.aspx zu finden.</remarks>
    public class Sprache : System.Object
    {

        //public System.String 
        //                ^-> keine .Net Sprache hat eigene Datentypen
        

        /// <summary>
        /// Ruft den Microsoft Schlüssel der 
        /// Sprache ab oder legt diesen fest.
        /// </summary>
        /// <remarks>Standardwert ist null.</remarks>
        public string Code { get; set; }
        //                 |-----------|->implizite Schreibweise, wo sich
        //                                der Kompiler das Feld selber erstellt,
        //                                wenn man's nicht braucht
        //      ^-> .Net Sprachen haben "Abkürzungen" (Aliases)
        //          auf die .Net Typen
        //Möchte man hier einen anderen Standardwert,
        //müsste man einen eigenen Konstruktor für
        //die Initialisierung bauen.

        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        private string _Name = string.Empty;
        //                   ^-> Tipp: Texte immer initialisieren
        //         ^-> Verweistyp, mit Standard null

        /// <summary>
        /// Ruft die lesbare Bezeichnung der
        /// Sprache ab oder legt diese fest.
        /// </summary>
        /// <remarks>Standardwert: ein Leerstring</remarks>
        public string Name
        {
            get
            {
                //Wie eine Funktionsmethode...
                return this._Name;
                //-> für die Rückgabe einer Funktion
            }
            set
            {
                //Wie eine void Methode mit einem Parameter
                this._Name = value;
                //             ^-> der vom Kompiler benutzte
                //                 Parametername für die Zugriffsmethode
                //                 zum Einstellen.

                //Außerdem müsste hier für
                //Windows Presentation Foundation (WPF)
                //das Ereignis "PropertyChanged" ausgelöst werden.

            }
        }

        /// <summary>
        /// Gibt eine Zeichenfolge zurück, die diese Sprache darstellt.
        /// </summary>
        /// <remarks>Nie auf das ToString() verlassen. Wird von
        /// fast allen Klassen überschrieben. Nur bei Werttypen
        /// bekommt man die Zahl als Text.</remarks>
        public override string ToString()
        //      ^-> C# Schlüsselwort zum Überschreiben von geerbten Mitgliedern
        //          ("sich hinwegsetzen"). override zeigt alle Basismitglieder,
        //          die "virtual" modifiziert sind
        {
            //return base.ToString();
            return $"{this.GetType().Name}(Code=\"{this.Code}\", Name=\"{this.Name}\")";
            //                                  ^-> C# unterstützt sämtliche
            //                                         Escape Sequenzen
            //                ^-> Einstiegsmethode für die Reflection,
            //                    d.h. zur Laufzeit Information über
            //                         ein Objekt ermitteln
            //     ^-> implizite Textersetzung seit 2016
        }

    }
}
