using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung.Daten
{

    /// <summary>
    /// Stellt eine Liste von Anwendungsfenstern bereit.
    /// </summary>
    /// <remarks>Hier wird eine generische Liste vom .Net
    /// für "Fenster"-Objekte "typisiert.</remarks>
    public class FensterListe : System.Collections.Generic.List<Fenster>
    //                          |--------------------------------------|
    //                              nicht direkt in einer Methode
    //                              sondern immer in einer eigenen 
    //                              Klasse kapseln
    {

        /// <summary>
        /// Gibt das Fenster mit dem gesuchten Namen zurück.
        /// </summary>
        /// <param name="name">Bezeichnung des Fensters.</param>
        /// <returns>Null, falls das Fenster nicht exisitert.</returns>
        /// <remarks>Demonstriert den Einsatz anonymer Methoden.</remarks>
        public Fenster Suchen(string name)
        {
            //Ohne der neuen Technik:
            //-> 1. den Parameter "name" in ein Feld umfüllen müssen
            //   2. eine private Metode vom Typ Boolean PrüfeFenster(Fenster f)
            //      implementieren müssen. In dieser Methode return f.Name == FeldName
            //   3. die eigene Prüfmethode dem Delegaten zuweisen 
            //
            // Seit 2005 voi cool: Anonym
            //
            //                   Ausdrucksbaum
            //              |-------------------|
            return this.Find(f => f.Name == name);
            //                    |-------------|
            //                          Rumpf der anonymen Methode
            //                 ^-> Lambda-Operator "Geht nach"
            //               ^-> "Lambda", hier als "Fenster" gelesen
        }

    }


    /// <summary>
    /// Stellt Information über ein Anwendungsfenster bereit.
    /// </summary>
    /// <remarks>Hier handelt es sich um ein Datentransferobjekt.</remarks>
    public class Fenster
    //                   ^-> falls nicht angegeben, wird
    //                       implizit System.Object erweitert
    {

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private string _Name = string.Empty; //G'schwollen für "", ein Leertext
        //                              ^-> damit nicht null geliefert wird
        //          ^-> als "class" implementiert,
        //              also "Verweistyp"

        /// <summary>
        /// Ruft die Bezeichnung des Fensters
        /// ab oder legt diese fest.
        /// </summary>
        /// <remarks>Wird als Schlüssel zum Wiederfinden benutzt.</remarks>
        public string Name
        {
            get
            {
                return this._Name;
                //            ^-> Wegen der Feldinitialisierung mit
                //                einem Leerstring ist sichergestellt,
                //                dass nicht null geliefert wird.
            }
            set
            {
                this._Name = value;
            }
        }

        //Jammerei,
        //Muss wirklich immer ein Feld gemacht werden?
        //Das könnte sich eh der Compiler machen
        /*
        //Erbarmen 2002

        private int _Zustand;
        //      ^-> als "struct" implementiert
        //          Standardwert 0 (Zahl Null)
        */
        
        // Implizite Eigenschaftendeklaration, wo
        // sich der Compiler das Feld selber macht
        // Hier vertretbar, weil nicht null geliefert wird.

        /// <summary>
        /// Ruft den Zustand des Fensters ab
        /// oder legt diesen fest.
        /// </summary>
        public int Zustand { get; set; }


        //Weil bei Minimiert bzw. Maximiert
        //oder einem neuen Fenster keine
        //Daten für Links, ... vorhanden sind,
        //gibt's ein Problem mit folgender Deklaration...

        //public int Links { get; set; }
        //        ^-> Werttyp, Standard 0 (Zahl Null)

        //Lösung: nullable

        //public System.Nullable<int> Links { get; set; }
        //       |-------------------|
        //         Geht das nicht kürzer?

        /// <summary>
        /// Ruft die linke Fensterposition ab 
        /// oder legt diese fest.
        /// </summary>
        /// <remarks>Standardwert null</remarks>
        public int? Links { get; set; }
        //        ^-> Fragezeichen Suffix. Kurzform für "Nullable"
        //            Ein Werttyp, dessen Standardeinstellung null ist

        /// <summary>
        /// Ruft die obere Fensterposition ab
        /// oder legt diese fest.
        /// </summary>
        /// <remarks>Standardwert null</remarks>
        public int? Oben { get; set; }

        /// <summary>
        /// Ruft die Breite des Fensters ab
        /// oder legt diese fest.
        /// </summary>
        /// <remarks>Standardwert null</remarks>
        public int? Breite { get; set; }

        /// <summary>
        /// Ruft die Höhe des Fensters ab
        /// oder legt diese fest.
        /// </summary>
        /// <remarks>Standardwert null</remarks>
        public int? Höhe { get; set; }

        /// <summary>
        /// Gibt eine Zeichenfolge zurück, die dieses Fenster beschreibt.
        /// </summary>
        public override string ToString()
        {
            return $"{this.GetType().Name}(Name=\"{this.Name}\")";
        }
    }
}
