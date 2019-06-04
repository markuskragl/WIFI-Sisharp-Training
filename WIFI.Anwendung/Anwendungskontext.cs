using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Zum Aktivieren der eigenen Erweiterungsmethoden
using WIFI.Anwendung.Erweiterungen;

namespace WIFI.Anwendung
{
    /// <summary>
    /// Stellt die Infrastruktur für eine WIFI Anwendung bereit.
    /// </summary>
    /// <remarks>Hier handelt es sich um Xml-Dokumentationskommentar.</remarks>
    public class Anwendungskontext : System.Object
    //                             ^-> Operator für die Vererbung in C#
    //                                 .Net unterstützt NUR DIE EINFACHVERERBUNG
    //-> "public" ist ein Modifzierer. Gegenteil "internal" bei Klassen
    {
        //Grundprinzip der objektorientierten Programmierung:
        //=> D A T E N K A P S E L U N G

        //Alle Variablen auf Klassenebene werden als
        //-> Felder
        //bezeichnung und sind 
        //-> IMMER PRIVAT!!!

        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        /// <remarks>Wird zum Cachen benötigt.</remarks>
        private FensterManager _Fenster = null;
        //                                  ^-> keine Speicheradresse
        //                              ^-> Operator für die Wertzuweisung
        //          ^-> "Klasse" -> Verweistyp
        //-> "private" Modifizierer als Gegentei von public
        //   "internal" bei Klassen

        /// <summary>
        /// Ruft den Dienst zum Verwalten der 
        /// Anwendungsfenster ab.
        /// </summary>
        /// <remarks>Weil "oder legt fest" fehlt,
        /// ist die Eigenschaft schreibgeschützt,
        /// d.h. es nur der Getter ohne Setter 
        /// zu implementieren.</remarks>
        public FensterManager Fenster
        //                           ^-> nie eine runde Klammer
        //                       ^-> weil "Subtantiv", eine
        //                           Eigenschaft. "Verben" wären eine Methode
        {
            get
            {
                //Wie eine Funktionsmethode
                /*
                return this._Fenster;
                */
                //-> Hier wäre der Rückgabewert null
                //   Mit "null" kann niemand arbeiten
                //=> Absturz

                //Tipp: Eigenschaften soll NIE null liefern

                if (this._Fenster == null )
                //                ^-> Operator für logisches Gleich
                //  ^-> "Zeiger" auf das aktuelle Objekt
                {

                    //Verzögerte Initialisierung
                    /*
                    this._Fenster = new FensterManager();
                    //                                 ^-> Schnittstelle vom Konstruktor
                    //               ^-> ruft den Konstruktor auf,
                    //                   stellt das Objekt irgendwo in den Speicher
                    //                   und gibt die Startadresse zurück
                    //      ^-> im eigenen Feld wird die
                    //          Startspeicheradresse hinterlegt
                    //          (Verweisdatentyp)

                    this._Fenster.AppKontext = this;
                    //                          ^-> die aktuelle Infrastruktur
                    //              ^-> die Infrastruktur muss eingestellt werden
                    */
                    //Alle Anwendungsobjekte mit der Objektfabrik erzeugen!
                    this._Fenster = this.Erzeuge<FensterManager>();
                }

                return this._Fenster;
            }
        }

        //Wir wollen eine "Objektfabrik" zum Initialiseren
        //von Anwendungsobjekten

        //Nicht möglich:
        /*
        public FensterManager Erzeuge() { return null; }
        public SprachenManager Erzeuge() { return null; }
        //...
        */
        //Lösung:
        //=> eine universelle Methode ohne Datentyp
        //   Erst beim Benutzen soll der Typ angeben werden
        //=> eine generische Methode

        /// <summary>
        /// Gibt ein initialisiertes Anwendungsobjekt zurück.
        /// </summary>
        /// <typeparam name="T">Der Anwendungstyp, der benötigt wird.</typeparam>
        /// <returns>Ein Objekt, wo die AppKontext Eigenschaft
        /// bereits voreingestellt ist und weitere Vorbereitungen getroffen wurden.</returns>
        //public T Erzeuge<T>() where T : Anwendungsobjekt, new()
        //                                                  ^-> wir benötigten einen öffentlichen
        //                                                      parameterlosen Konstruktor
        //                      ^-> bei uns ist nicht jeder Typ erlaubt
        //                          wegen der AppKontext-Eigenschaft
        //                          muss es eine Erweiterung von Anwendungsobjekt sein
        public virtual T Erzeuge<T>() where T : IAppKontext, new()
        //                                  ^-> wenn wir uns nur auf ein Interface
        //                                      beschränken, werden wir flexibler,
        //                                      weil nicht alle Typen Anwendungsobjekt erweitern,
        //                                      aber viele Typen IAppKontext implementieren können
        {
            var Ergebnis = new T();
            //              ^-> nur möglich, weil T auf new() eingeschränkt wurde

            //Die Infrastruktur übergeben
            Ergebnis.AppKontext = this;
            //          ^-> nur möglich, weil T ein Anwendungsobjekt sein muss
            
            //TODO:
            //=> Eine zentrale Fehlerbehandlung anhängen (demnächst)
            //=> Protokolleinträge (im Teil 2)

            return Ergebnis;
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        private WIFI.Anwendung.SprachenManager _Sprachen = null;

        /// <summary>
        /// Ruft den Dienst zum Verwalten der
        /// Anwendungssprachen ab.
        /// </summary>
        public WIFI.Anwendung.SprachenManager Sprachen
        {
            get
            {

                if (this._Sprachen == null)
                {
                    this._Sprachen = this.Erzeuge<WIFI.Anwendung.SprachenManager>();
                }

                return this._Sprachen;
            }
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        private string _AnwendungsdatenPfadLokal = null;

        /// <summary>
        /// Ruft das lokale Datenverzeichnis für
        /// die Anwendung im Benutzerprofil ab.
        /// </summary>
        /// <remarks>Es ist sichergestellt, dass das 
        /// Verzeichnis exisitert.</remarks>
        public string AnwendungsdatenPfadLokal
        {
            get
            {
                if (this._AnwendungsdatenPfadLokal == null)
                {
                    this._AnwendungsdatenPfadLokal
                        = System.IO.Path.Combine(
                            System.Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData),
                            this.HoleFirmenname(),
                            this.HoleProdukt(),
                            this.HoleVersion()
                    );
                }

                //Anwendungen müssen sich "selber heilen"
                //Bewusst nicht gecachet!
                //Deshalb vor der Rückgabe sicherstellen,
                //dass das Verzeichnis existiert...
                System.IO.Directory.CreateDirectory(this._AnwendungsdatenPfadLokal);

                return this._AnwendungsdatenPfadLokal;
            }
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        private string _AnwendungsdatenPfad = null;

        /// <summary>
        /// Ruft das Datenverzeichnis für
        /// die Anwendung im Benutzerprofil ab.
        /// </summary>
        /// <remarks>Es ist sichergestellt, dass das 
        /// Verzeichnis exisitert.</remarks>
        public string AnwendungsdatenPfad
        {
            get
            {
                if (this._AnwendungsdatenPfad == null)
                {
                    this._AnwendungsdatenPfad
                        = System.IO.Path.Combine(
                            System.Environment.GetFolderPath(
                                Environment.SpecialFolder.ApplicationData),
                            this.HoleFirmenname(),
                            this.HoleProdukt(),
                            this.HoleVersion()
                    );
                }

                //Anwendungen müssen sich "selber heilen"
                //Bewusst nicht gecachet!!!
                //Deshalb vor der Rückgabe sicherstellen,
                //dass das Verzeichnis existiert...
                System.IO.Directory.CreateDirectory(this._AnwendungsdatenPfad);

                return this._AnwendungsdatenPfad;
            }
        }

        /// <summary>
        /// Beendet den Infrastrukturdienst.
        /// </summary>
        /// <remarks>Hier werden z. B. Fensterpositionen gespeichert.</remarks>
        public virtual void Herunterfahren()
        {
            //Hier nicht mit der Eigenschaft arbeiten,
            //weil diese den FensterManager produziert, falls
            //er nicht vorhanden. Zu diesem Zeitpunkt wird
            //der aber nicht mehr neu benötigt
            if (this._Fenster != null)
            {
                this.Fenster.Speichern();
            }
        
            //Hier weitere Aufgaben
            //hinzufügen, die beim Beenden
            //ausgeführt werden sollen.
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        /// <remarks>Die Anwendung kann nur genau 
        /// eine Anwendungsverzeichnis besitzen, deshalb "statisch".</remarks>
        private static string _Anwendungspfad = null;

        /// <summary>
        /// Ruft das Verzeichnis ab, aus dem die Anwendung gestartet wurde.
        /// </summary>
        public string Anwendungspfad
        {
            get
            {

                if (Anwendungskontext._Anwendungspfad == null)
                {
                    Anwendungskontext._Anwendungspfad
                        = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                }

                return Anwendungskontext._Anwendungspfad;
            }
        }

    }
}
