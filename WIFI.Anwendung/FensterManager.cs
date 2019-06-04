using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung
{
    /// <summary>
    /// Stellt einen Dienst zum Verwalten der
    /// Größen und Positionen der Anwendungsfenster bereit.
    /// </summary>
    /// <remarks>Die Manager müssen "stabil, robust" implementiert
    /// werden. Hier dürfen keine Ausnahmen auftreten!</remarks>
    public class FensterManager : Anwendungsobjekt
    {
        /// <summary>
        /// Gibt Informationen über die Bildschirmumgebung zurück.
        /// </summary>
        /// <param name="nIndex">Code der benötigten Information</param>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        /// <summary>
        /// Für GetSystemMetrics zum Abrufen
        /// der aktuellen Monitoranzahl.
        /// </summary>
        private const int SM_CMONITORS = 80;

        /// <summary>
        /// Interne Feld für die Eigenschaft.
        /// </summary>
        private Controller.FensterXmlController _Controller = null;

        /// <summary>
        /// Ruft den Dienst zum Schreiben und Lesen
        /// der Fensterdaten aus einer Xml Datei ab.
        /// </summary>
        private Controller.FensterXmlController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller 
                        = this.AppKontext.Erzeuge<WIFI.Anwendung.Controller.FensterXmlController>();
                }
                return this._Controller;
            }
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        private Daten.FensterListe _Liste = null;

        /// <summary>
        /// Ruft die Liste mit den 
        /// verwalteten Fenstern ab.
        /// </summary>
        /// <remarks>Beim ersten Benutzen wird
        /// versucht, die Liste aus dem Standardpfad
        /// wiederherzustellen.</remarks>
        protected Daten.FensterListe Liste
        {
            get
            {
                if (this._Liste == null)
                {
                    try
                    {
                        this._Liste = this.Controller.Lesen(this.StandardPfad);
                    }
                    catch (System.Exception ex)
                    {
                        //Vermutlich ein neuer Benutzer
                        this.OnFehlerAufgetreten(new FehlerAufgetretenEventArgs(ex));
                        this._Liste = new Daten.FensterListe();
                    }
                }

                return this._Liste;
            }
        }

        /// <summary>
        /// Speichert die Fensterdaten als Xml Datei.
        /// </summary>
        /// <remarks>Es wird der StandardPfad benutzt.</remarks>
        public void Speichern()
        {
            //Wo darf eine Anwendung speichern?

            //AUF KEINEN FALL IM ANWENDUNGSVERZEICHNIS!!!!
            //Ungefragt nur im AppData des Benutzerprofils
            //(in der Infrastruktur Anwendungskontext enthalten)

            //Wir befinden uns hier im Manager. 
            //Die zweite Ebene des mehrschichten Modells.
            //Dem Manager ist egal, wie Daten als Xml gespeichert werden.

            //this.Controller.Speichern(this.StandardPfad, this.Liste);
            //                     ^-> kritisch, weil im Kommentar
            //                         Ausnahmen angeführt sind

            //Deshalb
            try
            {
                this.Controller.Speichern(this.StandardPfad, this.Liste);
            }
            catch (System.Exception ex)
            {
                //Was tun im Fehlerfall?
                //
                //==============================================
                //AUF KEINEN FALL MIT DEM BENUTZER REDEN!!!!!!!!
                //==============================================
                //Keine Messageboxes oder dergleichen
                //
                //Wir wissen ja hier im Firmen-Framework nicht
                //wer uns benutzt. Könnte ja auch ein Windows Dienst
                //sein, der ohne angemeldetem Benutzer läuft.

                //Also, was tun?

                //1. Weiter abstürzen. Mit einer verbesserten
                //   Exception
                /*
                throw new System.Exception("Hier ein bessere Meldung", ex);
                //^-> nach dem throw WIRD NICHTS MEHR AUSGEFÜHRT!
                //    Mit eine Ausnahme des finally-Zweigs
                //Weil hier ein Manager implementiert wird, nicht schlau
                */

                //2. Einen Windows Protokolleintrag erstellen
                //System.Diagnostics.EventLog.WriteEntry("Fenster konnten...
                //                              ^-> benötigt eine Quelle
                //System.Diagnostics.EventLog.CreateEventSource(...)
                //                              ^-> funktioniert nur mit
                //                                  Administratoren-Rechten
                //                                      ^-> Trainer macht das nur
                //                                          mehr bei Windows Diensten

                //3. Ein eigenes Protokoll
                //      (im Teil 2)

                //4. State of the art
                //   => Liebe Objektbenutzer, kümmert euch selber um das Problem
                //      Den Objektbenutzern die Möglichkeit geben,
                //      hier eine eigene Methode "anzuhängen"
                //
                //      Diese Technik heißt...
                //          Ein Ereignis auslösen
                this.OnFehlerAufgetreten(new FehlerAufgetretenEventArgs(ex));

            }
            finally
            {
                //Wird mit und ohne Fehler IMMER ausgeführt.
                //Zum Zusammenräumen.
                //Vor allem dazu da, dass Code läuft,
                //wenn im catch ein weiter Abstürzen ist (throw)
            }
        }

        /// <summary>
        /// Ruft den vollständigen Pfad der Datei,
        /// die zum Speichern der Fensterpositionen
        /// benutzt wird, ab.
        /// </summary>
        public string StandardPfad
        {
            get
            {
                //HIER NICHT CACHEN, DAMIT
                //EIN FEHLENDES VERZEICHNIS 
                //IMMER ERSTELLT WIRD!
                return System.IO.Path.Combine(
                    this.AppKontext.AnwendungsdatenPfadLokal, 
                    "Fensterpositionen.xml");
            }
        }

        /// <summary>
        /// Fügt das Fenster der Liste des Managers hinzu.
        /// </summary>
        /// <param name="fenster">Informationen zum Fenster</param>
        /// <remarks>Der Fenstername wird als Schlüssel zum Wiederfinden benutzt.</remarks>
        public void Hinterlegen(Daten.Fenster fenster)
        {

            //Die Monitorkonfiguration unterscheiden...
            fenster.Name += this.MonitorSchlüssel;

            //Gibt's das Fenster schon?
            var f = this.Liste.Suchen(fenster.Name);

            if (f == null)
            {
                this.Liste.Add(fenster);
            }
            else
            {
                //Daten aktualisieren...
                f.Zustand = fenster.Zustand;

                f.Links = fenster.Links ?? f.Links;
                f.Oben = fenster.Oben ?? f.Oben;
                f.Breite = fenster.Breite ?? f.Breite;
                f.Höhe = fenster.Höhe ?? f.Höhe;

                //Weil Daten.Fenster eine Klasse, 
                //also Verweistyp, werden nur Speicheradressen
                //auf dasselbe Objekt benutzt. Ein
                //erneutes Hinzufügen darf nicht gemacht werden
            }
            
        }

        /// <summary>
        /// Gibt das Objekt mit den Positionsdaten für ein Fenster zurück.
        /// </summary>
        /// <param name="fensterName">Name des Fensters, dessen Positionsdaten benötigt werden.</param>
        /// <returns>Null, falls das Fenster nicht existiert.</returns>
        public Daten.Fenster Abrufen(string fensterName)
        {
            return this.Liste.Suchen(fensterName + this.MonitorSchlüssel);
        }

        /// <summary>
        /// Ruft einen Schlüssel zum Unterscheiden
        /// der Monitorkonfiguration ab.
        /// </summary>
        /// <remarks>Eine Änderung der Auflösung wird nicht berücksichtigt.</remarks>
        protected string MonitorSchlüssel
        {
            get
            {
                //Wird nicht gecacht, weil
                //Bildschirme dynamisch angeschlossen
                //und abgesteckt werden können

                return $"_M{FensterManager.GetSystemMetrics(SM_CMONITORS)}";

            }
        }
    }
}
