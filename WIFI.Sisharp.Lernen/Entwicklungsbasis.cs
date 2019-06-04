using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Lernen
{

    /// <summary>
    /// Listet mögliche Ausgabevarianten auf.
    /// </summary>
    public enum AusgabeModus
    {
        Normal,
        NormalOhneVorschub,
        Debug,
        Fehler
    }

    /// <summary>
    /// Unterstützt sämtliche WIFI.Sisharp.Lernen Objekte.
    /// </summary>
    public abstract class Entwicklungsbasis : System.Object
    //                                      ^-> Vererbungsoperator, falls fehlt
    //                                          implizit System.Object
    //                                          Nur Einfachvererbung
    //         ^-> Modifizierer, der angibt,
    //             dass die Klasse nicht fertig
    //             ist und nur als Basisklasse
    //             benutzt werden kann
    //-> "public" ist das Gegenteil von "internal",
    //   d.h. die KLasse ist außerhalb der Assembly sichtbar
    //   (laut Analyse deshalb, weil Lotto im Teil 2 benötigt wird)
    {

        /// <summary>
        /// Schreibt den Text für den Benutzer
        /// normal auf den Bildschirm.
        /// </summary>
        /// <param name="text">Der Hinweis, der angezeigt werden soll.</param>
        /// <remarks>Hier handelt es sich um eine überladene Methode.</remarks>
        protected static void Ausgeben(System.String text)
        //                                            ^-> "Parameter"
        //                              |-----------| (Daten)Typ der Information im Paramter
        //                                            Keine .Net Sprache hat eigene Datentypen
        //                                            Alle Typen gehören .Net, z. B. System.String 
        //                                                                  für einen Text
        //                             |------------------|
        //                              Schnittstelle
        //                              damit eine Methode, weiß womit gearbeitet werden muss
        //              ^-> "void" für eine Methode, die arbeitet aber nichts zurückgibt
        //                    ^-> wäre "Sub" in BASIC
        //          ^-> "static" sagt, dass die Methode nicht dem
        //              Objekt gehört sondern der Klasse
        //              (Damit diese Ausgeben-Methode auch z. B. im Main() genutzt werden kann)
        //-> "protected" ist ein Mittelding zwischen
        //   "public" (überall sichtbar) und "private" (nur in dieser Klasse sichtbar)
        {
            //this.Aus...
            //      ^-> gibt's nicht
            // ^-> "this" ist der Zeige auf das aktuelle Objekt
            //     Ausgeben ist statisch, deshalb nur über die Klasse aufrufbar

            //Entwicklungsbasis.Ausgeben(text, false);
            //                                  ^-> warum hier "false". Damit's 
            //                                      lesbarer wird...
            //=> Benannte Parameter benutzen!!!
            Entwicklungsbasis.Ausgeben(text, debug: false);
            //                               |----| "benannter" Parameter

            //Bei benannten Parametern muss die Reihenfolge beim Beschicken
            //nicht eingehalten werden. Aber ab dem ersten benannten Parameter,
            //müssen die folgenden Parameternamen auch getippt werden.
            //Entwicklungsbasis.Ausgeben(debug: false, text: text);

            //HAUPTGRUNDSATZ DER KONVENTIONEN:
            //=> Die Lesbarkeit ist der Kürze vorzuziehen!
        }

        /// <summary>
        /// Schreibt den Text auf den Bildschirm.
        /// </summary>
        /// <param name="text">Der Hinweis, der angezeigt werden soll.</param>
        /// <param name="debug">False, falls der Text für den Benutzer ist. True, wenn
        /// der Text für Entwicklungszwecke in einer anderen Farbe sein soll.</param>
        /// <remarks>Hier handelt es sich um eine überladene Methode.</remarks>
        protected static void Ausgeben(string text, bool debug)
        //                                          ^-> "struct" (Werttyp, Standardwert 0)
        //                              ^-> "class" (Verweistyp, Standardwert null (nix)
        //Konvention für die Überladung: die Parameter, die alle Varianten besitzen
        //                               "vorne" anordnen, die Parameter, wo sich die
        //                               Überladungen unterscheiden, "hinten".
        {

            //In einer Binärentscheidung
            if (debug)
            {

                //nicht bei der Kundenversion ("Release")
#if DEBUG
                //Die Ausgabe für Entwicklungszwecke
                //(eine Sequenz)

                //(1) Die Schriftfarbe ändern
                System.Console.ForegroundColor = ConsoleColor.DarkGray;
                //
                //                  ^-> Beschreibt, Substantiv, Eigenschaft
                //                      ohne Klammer

                //(2) Den Text ausgeben
                System.Console.WriteLine(text);
                //                  ^-> Arbeitet, Verb, Methode
                //                      immer Klammer

                //(3) Die ursprüngliche Farbe wiederherstellen
                System.Console.ResetColor();

#endif

            }
            else
            {
                //Die Ausgabe für den Benutzer

                System.Console.WriteLine(text);

            }

        }



        /// <summary>
        /// Initialisiert ein neues Objekt.
        /// </summary>
        /// <remarks>Hier handelt es sich um den Konstruktor.
        /// Mit dem Konstruktor beginnt das Objekt zu leben.
        /// Wird mit dem "new" Schlüsselwort aufgerufen.</remarks>
        public Entwicklungsbasis()
        {
            //Neu seit C# 7 (2016): Einsetzen von Daten in einen Text ($)
            Entwicklungsbasis.Ausgeben($"Ein Objekt \"{this.GetType().Name}\" lebt...", debug: true);
            //                                                             ^-> eine Escape-Sequenz, damit
            //                                                                 das Anführungszeichen ausgegeben wird
            //                                          ^-> "this" ist das Schlüsselwort, um auf das
            //                                              aktuelle Objekt zuzugreifen.
            //                                              Benötigt man mehr Information zum aktuellen
            //                                              Objekt, die .Net Reflection benutzen.
            //                                              Zugriff auf die Reflection ist die von
            //                                              System.Object geerbte GetType-Methode
            //                                         ^-> {Variable} Ausdrucksform ist erst
            //                                             seit 2016 möglich
            //                          ^-> Dollar $ wird für {Variable}, die implizite Textersetzung,
            //                              benutzt. Wird vom Trainer nicht benutzt. Max. bei 
            //                              Protokolleinträgen, weil die TExte ja aus "lokalisierten" Ressourcedateien
            //                              Aber: Die Microsoft Beispiele nutzen mittlerweile alle diese
            //                                    Variante (weils in den Beispielen um nix geht)
        }

#if DEBUG
        //Weil der Zeitpunkt des Aufrufs
        //nicht bestimmt ist, wird der Desktruktor
        //nicht mehr implementiert und soll
        //nur zu Testzwecken vorhanden sein.


        /// <summary>
        /// Zerstört ein Objekt.
        /// </summary>
        /// <remarks>Hier handelt es sich um den Destruktor.
        /// Dieser kann nur mehr von der Garbage Collection
        /// aufgerufen werden und wird deshalb nicht mehr
        /// in der Realität implementiert. Objekte, die etwas
        /// zum Zusammenräumen haben, müssen eine 
        /// Dispose Methode bereitstellen.</remarks>
        ~Entwicklungsbasis()
        {
            Entwicklungsbasis.Ausgeben($"Ein Objekt \"{this.GetType().Name}\" ist tot.", debug: true);
        }

#endif

        //======= Klassenebene
        //Alle Deklarationen hier sind ...
        //==> IMMER privat!!!
        //und werden als...
        //==> Felder bezeichnet
        private static System.Random _Zufallsgenerator = null;
        //Grundprinzip der objektorientieren Programmierung:
        //=================================
        //D A T E N K A P S E L U N G ! ! !
        //=================================

        /// <summary>
        /// Ruft den anwendungsweiten Zufallsgenerator ab.
        /// </summary>
        /// <remarks>Jeder Eigenschaftenkommentar beginnt mit "Ruft ab",
        /// dann ist die Eigenschaft schreibgeschützt. Steht auch 
        /// "oder legt fest" dabei, kann die Eigenschaft auch geändert werden.</remarks>
        protected System.Random Zufallsgenerator
        {
            //immer:
            get
            { //<- Hier beginnt eine Gültigkeit
                //return ????
                //^-> C# Schlüsselwort, mit dem eine Eigenschaft
                //    oder eine Funktionsmethode einen Wert zurückgibt.

                //Was geben wir zurück?
                //=> auf keinen Fall:
                //return new System.Random();
                //       |------------> jedes Mal ein Neuer
                //
                //Wir müssen uns den Zufallsgenerator "merken"
                //Was gibt's GENAU EINMAL?
                //=> statische Deklarationen auf Klassenebene

                //Falls der Generator noch 
                //nicht existiert, erzeugen
                if (Entwicklungsbasis._Zufallsgenerator == null)
                {
                    Entwicklungsbasis._Zufallsgenerator = new System.Random();
                    Entwicklungsbasis.Ausgeben("Die Anwendung hat den Zufallsgenerator erzeugt...", debug: true);
                }

                return Entwicklungsbasis._Zufallsgenerator;
            }

            /*
            //nur bei "oder legt fest"
            set
            {

            }
            */
        }

        /// <summary>
        /// Schreibt den Text auf den Bildschirm.
        /// </summary>
        /// <param name="text">Der Hinweis, der ausgegeben werden soll.</param>
        /// <param name="modus">Steuert die Art der Ausgabe</param>
        protected static void Ausgeben(string text, AusgabeModus modus)
        {
            switch(modus)
            {
                case AusgabeModus.Debug:
                    Entwicklungsbasis.Ausgeben(text, debug: true);
                    break;
                case AusgabeModus.Fehler:
                    System.Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine(text);
                    System.Console.ResetColor();
                    break;
                case AusgabeModus.Normal:
                    Entwicklungsbasis.Ausgeben(text, debug: false);
                    break;
                case AusgabeModus.NormalOhneVorschub:
                    System.Console.Write(text);
                    break;

#if DEBUG
                default:
                    //Hier wird diese Ausgeben-Überladung
                    // R E K U R S I V (selber) aufgerufen
                    Entwicklungsbasis.Ausgeben(
                        $"FEHLER: AusgabeModus {modus} nicht vorgesehen!", 
                        AusgabeModus.Fehler);
                    //Falls rekursive Aufrufe irrtümlich passieren,
                    //stürzt die Anwendung mit "Stapelüberlauf (Stack Overflow)" ab.
                    break;
#endif
            }
        }

        /// <summary>
        /// Internes Feld für die gecachte Eigenschaft.
        /// </summary>
        private static string _Anwendungsverzeichnis = null;
        //      ^-> das Verzeichnis kann ohne dem Beenden
        //          der Anwendung nicht geändert werden

        /// <summary>
        /// Ruft das Verzeichnis ab, aus dem die
        /// aktuelle Anwendung gestartet wurde.
        /// </summary>
        public string Anwendungsverzeichnis
        {
            get
            {
                if (Entwicklungsbasis._Anwendungsverzeichnis == null)
                {
                    Entwicklungsbasis._Anwendungsverzeichnis
                        = System.IO.Path.GetDirectoryName(
                                System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                    Entwicklungsbasis.Ausgeben("Die Anwendung hat das Startverzeichnis ermittelt...", AusgabeModus.Debug);
                }

                return Entwicklungsbasis._Anwendungsverzeichnis;
            }
        }
    }
}
