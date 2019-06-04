using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Lernen
{
    /// <summary>
    /// Stellt einen Dienst zum Lesen einer
    /// unformatierten Textdatei und zum
    /// Ausgeben des Inhalts bereit.
    /// </summary>
    internal class Textdatei : Entwicklungsbasis
    {
        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        private string _Pfad = string.Empty;
        //                      ^-> eine String - Variable, wenn nicht ausdrücklich
        //                          auf "null" geprüft wird, immer bewusst initialisieren
        //                          "string.Empty" ist G'schwollen für "" (Leertext)
        //         ^-> "class", also Verweistyp, Standard "null"
        //             mit "null" (keine Speicheradresse) kann
        //             niemand arbeiten.

        /// <summary>
        /// Ruft den vollständigen Dateinamen 
        /// ab oder legt diesen fest.
        /// </summary>
        public string Pfad
        {
            get
            {
                return this._Pfad;
            }
            set
            {
                this._Pfad = value;
                Textdatei.Ausgeben(
                    $"Textdatei.Pfad=\"{this._Pfad}\" initialisiert...", 
                    AusgabeModus.Debug);

                if (this._Zeilen != null)
                {
                    this._Zeilen = null;
                    Textdatei.Ausgeben(
                        "Textdatei hat den alten Zeilencache geleert...",
                        AusgabeModus.Debug);
                }
            }
        }

        /// <summary>
        /// Gibt den Inhalt der Datei im Pfad als Fließtext 
        /// linksbündig mit einer bestimmten Breite zurück.
        /// </summary>
        /// <param name="maxZeilenlänge">Die Anzahl der Zeichen, die
        /// maximal in einer Zeile enthalten sein dürfen.</param>
        public string HoleFließtext(int maxZeilenlänge)
        {

            var Text = new System.Text.StringBuilder();
            var AktuelleLänge = 0;

            //Im Gegensatz zum Lesen ist hier die Anzahl bekannt...
            //-> Zählschleife
            //   Wo befinden sich die Daten?
            //      -> In einem Array (Datenfeld, Liste)

            /*
            for (int i = 0; i < this.Zeilen.Count; i++)
            {
                // this.Zeilen[i] verarbeiten
            }
            */

            //Falls jedes Element eines Array benötigt wird,
            //=> Spezialzählschleife

            foreach (string Wort in this.Zeilen)
            {
                //Hat das Wort noch Platz bei der max. Zeilenlänge?
                //Wenn nicht, eine neue Zeile beginnen
                if (AktuelleLänge + Wort.Length > maxZeilenlänge)
                {
                    Text.AppendLine();
                    AktuelleLänge = 0;
                }

                //Wort mit einem Leerzeichen schreiben...
                Text.Append(Wort + " ");

                //Hier wird der Inhalt einer Variable verändert
                //und das Ergebnis wieder in der Variable gespeichert
                //Folgende Schreibweise ist "alt"
                /*
                AktuelleLänge = AktuelleLänge + Wort.Length + 1;
                */
                //Seit C# gibt's etwas Neues
                AktuelleLänge += Wort.Length + 1;
                //                             ^-> wegen dem Leer
            }

            return Text.ToString().Trim();
        }

        /// <summary>
        /// Liest den Inhalt der unformatierten
        /// Textdatei beschrieben im Pfad.
        /// </summary>
        protected void Lesen()
        {
            Textdatei.Ausgeben("Textdatei.Lesen startet...", AusgabeModus.Debug);

            try
            {
                //Datei öffnen
                //var Leser = new System.IO.StreamReader(this.Pfad);
                //                              sympathischer Konstruktor, hat
                //                              aber den falschen Zeichensatz, Ä, Ö, ... fehlen
                var Leser = new System.IO.StreamReader(this.Pfad, System.Text.Encoding.Default);
                //                                                               ^-> .Net kann jeden Zeichensatz darstellen
                //                                                                   System.Text.Encoding unbedingt merken
                //                              ^-> weil der StreamReader-Konstruktor
                //                                  Ausnahmen auslöst (steht im Tool-Tipp Kommentar!), 
                //                                  eine Fehlerbehandlung notwendig

                //Mit einer Abweiseschleife, solange wir nicht am Ende sind
                while (!Leser.EndOfStream)
                {
                    this.Zeilen.Add(Leser.ReadLine().Trim());
                }

                //Datei schließen
                Leser.Close();  //Es gibt Objekte, wo neben dem Dispose() auch
                                //eine Close() Methode vorhanden ist.
                                //In diesem Fall genügt, eine der beiden
                                //Methoden aufzurufen
                                //Leser.Dispose();
                Leser = null;
            }
            catch (System.Exception ex)
            {
                //Was tun im Fehlerfall?

                //Wir sind einer Klasse und haben beim
                //Tippen der Klasse keine Ahnung, wer, wo 
                //ein Objekt unserer Klasse benutzt.
                //
                //D E S H A L B :
                //====> NIE MIT DEM BENUTZER REDEN!
                //      (Keine Messageboxes oder Sonstiges)
                //
                //Also, was tun?
                //-> eine Möglichkeit:
                //   Weiter abstürzen
                //throw new System.Exception("Bessere Meldung");

                //-> andere Möglichkeit:
                //   Windows Protokolleinträge
                //System.Diagnostics.EventLog.WriteEntry(....
                //                      ^-> das benötigt eine Quelle
                //System.Diagnostics.EventLog.CreateEventSource(....
                //                                  ^-> nur mit Adminrechten möglich
                //=> Der Trainer hat das aufgegeben, weil
                //   Administratoren kein Verständig dafür haben

                //-> eigenes Protokoll (im Teil 2)
                //

                //=> State of the Art
                //
                //-> Lieber Objektbenutzer, kümmere dich selber um das Problem
                //=> Ein Ereignis auslösen

                this.OnLeseFehlerAufgetreten(new FehlerAufgetretenEventArgs(ex));

            }

            Textdatei.Ausgeben("Textdatei.Lesen beendet.", AusgabeModus.Debug);
        }

        /// <summary>
        /// Internes Feld für den Cache des Dateiinhalts.
        /// </summary>
        private System.Collections.ArrayList _Zeilen = null;

        /// <summary>
        /// Ruft den gecachten Inhalt der Datei ab.
        /// </summary>
        protected System.Collections.ArrayList Zeilen
        {
            get
            {
                if (this._Zeilen == null)
                {
                    this._Zeilen = new System.Collections.ArrayList();
                    Textdatei.Ausgeben(
                        "Textdatei hat den Cache für den Inhalt erstellt...", 
                        AusgabeModus.Debug);

                    this.Lesen();

                }

                return this._Zeilen;
            }
        }

        //Mit einem Ereignis mitteilen, dass
        //beim Lesen ein Problem war

        /// <summary>
        /// Wird ausgelöst, wenn beim Lesen ein Problem war.
        /// </summary>
        /// <remarks>Der 3. Schritt (oder 1. bei System.EventHandler)
        /// ist die Deklaration des Ereignisses.</remarks>
        public event FehlerAufgetretenEventHandler LeseFehlerAufgetreten;
        //           |------ Technisch notwendig
        //     ^-> nur damit das Klassendiagramm einen
        //         Blitz anzeigt

        /// <summary>
        /// Löst das Ereignis LeseFehlerAufgetreten aus.
        /// </summary>
        /// <remarks>Der 4. (oder 2. Schritt). Die 
        /// Methode zum Aufrufen des angehängten Ereignisbehandlers.</remarks>
        protected void OnLeseFehlerAufgetreten(FehlerAufgetretenEventArgs e)
        //             ^-> um nicht in Benennungsnotstand zu kommen,
        //                 beginnen Ereignisauslöser mit "On" + Ereignisname
        //-> dürfen nicht im Objekt sichtbar sein
        //   beim Erweitern der Klasse aber nutzbar
        {
            if (this.LeseFehlerAufgetreten != null)
            {
                this.LeseFehlerAufgetreten(this, e);
            }
        }
    }
}
