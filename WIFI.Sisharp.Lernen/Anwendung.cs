using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Lernen
{
    /// <summary>
    /// Steuert die Anwendung zum Lernen der objektorientierten 
    /// Programmierung mit C# und dem .Net Framework.
    /// </summary>
    internal class Anwendung : Entwicklungsbasis
    {
        /// <summary>
        /// Stellt den Einstiegspunkt
        /// in eine .Net Anwendung bereit.
        /// </summary>
        private static void Main()
        //         ^-> MUSS UNBEDINGT statisch sein,
        //             d.h. der Klasse gehören und nicht
        //                  dem Objekt.
        //-> Modifizierer beim Main() egal
        {
            //In einer stastischen Methode können
            //nur andere Mitglieder direkt aufgerufen
            //werden, wenn diese ebenfalls statisch sind.

            Anwendung.ZeichneTitel();
            Anwendung.Begrüßen();
            Anwendung.ZeigeMenü();

            //Wo ist die ZeigeSequenz() Methode?
            //Algorithmus.ZeigeSe...
            //              eine nicht statische Methode,
            //              gehört einem Objekt
            //   ^-> eine Klasse (Bauplan)

            //=> Ein Objekt ist notwendig (in 99,999% der Fälle)
            //   (statisch ist ganz selten)

            //=== Standardablauf zum Benutzen einer Klasse als Objekt

            //(1) Speicher für die Objektadresse reservieren
            Algorithmus AlgoObjekt = null;

            //(2) Die Klasse initialisieren, das Objekt bauen
            AlgoObjekt = new Algorithmus();
            //                           ^-> Schnittstelle vom Konstruktor
            //            ^-> ruft den Konstruktor der Klasse auf,
            //                erstellt irgendwo im Speicher das Objekt
            //                und gibt die Start-Speicheradresse zurück
            //                (Verweistyp)
            //            ===========
            //            Das Initialisieren, das Bauen eines Objekts,
            //            ist extram langsam. Möglichst sparsam einsetzen.
            //            Erst dannn ein Objekt bauen, wenn klar ist,
            //            dass es wirklich benötigt wird und cachen.
            //            ===========
            //          ^-> Wertzuweisungsoperator zum Merken
            //-> der Speicheradresse in der AlgoObjekt-Variablen
            //   damit wir über diese mit Objekt arbeiten können

            //(3) Das Objekt benutzen
            //Die Benutzer sollen den Programm auswählen
            //AlgoObjekt.ZeigeSequenz();
            //AlgoObjekt.ZeigeFall();
            //AlgoObjekt.ZeigeBinär();
            ////Zum Testen vom eindeutigen Zufallsgenerator
            //AlgoObjekt.ZeigeBinär();
            //AlgoObjekt.ZeigeFall();
            //AlgoObjekt.ZeigeZählen();

            const string Prompt = "C#> ";
            //                        ^-> damit ein Abstand zur Eingabe ist
            string Programmpunkt = null;
            //          ^-> muss vor der Schleife deklariert werden
            //              weil mit der geschweiften Klammer eine
            //              neue Gültigkeit beginnt!

            do
            { //<- Hier beginnt die Gültigkeit

                Anwendung.Ausgeben(Prompt, AusgabeModus.NormalOhneVorschub);
                Programmpunkt = System.Console.ReadLine().Trim().ToLower();

                switch (Programmpunkt)
                {
                    case "hallo":
                    case "1":
                        AlgoObjekt.ZeigeSequenz();
                        break;
                    case "if":
                    case "2":
                        AlgoObjekt.ZeigeBinär();
                        break;
                    case "switch":
                    case "3":
                        AlgoObjekt.ZeigeFall();
                        break;
                    case "for":
                    case "foreach":
                    case "4":
                        AlgoObjekt.ZeigeZählen();
                        break;
                    case "while":
                    case "5":
                        AlgoObjekt.ZeigeAbweisen();
                        break;
                    case "do":
                    case "6":
                        AlgoObjekt.ZeigeDurchlaufen();
                        break;

                    case "?":
                        Anwendung.ZeigeMenü();

                        break;

                    case "9": 
                    case "":

                        //Leereingaben und Beenden mit 9 sollen
                        //zu keinem Fehler führen.

                        //Deshalb leerer Fall

                        break;

                    case "exit":
                        Programmpunkt = "9";
                        break;

                    default:
                        Anwendung.Ausgeben(
                            "Eingabe nicht erkannt! Fragezeichen ? für Hilfe tippen...", 
                            AusgabeModus.Fehler);
                        break;
                }

                //<- Hier endet die Gültigkeit
            } while (Programmpunkt != "9");

            //(4) Den benötigten Speicher wieder freigeben
            //    (Für die Freigabe kennzeichnen, auf Dispose prüfen)
            //AlgoObjekt.di... kein Dispose

            //Der Garbage Collection helfen...
            AlgoObjekt = null;

#if DEBUG

            //=> NUR ZU DEMO-ZWECKEN:
            //Speicher wird von der Garbage Collection freigegeben.
            //Diese Garbage Collection in Ruhe lassen!!!
            //-> manuelle Garbage Collection
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();


            //Damit das Konsolenfenster offen bleibt...
            Anwendung.Ausgeben("Die Eingabetaste zum Beenden tippen...", debug: true);
            System.Console.ReadLine();
#endif

        }

        /// <summary>
        /// Internes Feld für die gecachten Programmpunkte.
        /// </summary>
        private static string _MenüInhalt = null;

        /// <summary>
        /// Schreibt die Programmpunkte auf den Bildschirm.
        /// </summary>
        private static void ZeigeMenü()
        {
            Anwendung.Ausgeben("ZeigeMenü startet...", debug: true);

            if (Anwendung._MenüInhalt == null)
            {
                var Text = new System.Text.StringBuilder();

                Text.AppendLine("Algorithmen Bausteine:");
                Text.AppendLine();
                Text.AppendLine(" 1. Die Sequenz");
                Text.AppendLine(" 2. Die Binärentscheidung");
                Text.AppendLine(" 3. Die Fallentscheidung");
                Text.AppendLine(" 4. Die Zählschleife");
                Text.AppendLine(" 5. Die Abweiseschleife");
                Text.AppendLine(" 6. Die Durchlaufeschleife");
                Text.AppendLine();
                Text.AppendLine(" 9. Beenden");

                Anwendung._MenüInhalt = Text.ToString();
                Anwendung.Ausgeben("Die Anwendung hat die Programmpunkte gecacht...", AusgabeModus.Debug); ;

            }

            Anwendung.Ausgeben(Anwendung._MenüInhalt);

            Anwendung.Ausgeben("ZeigeMenü beendet.", debug: true);
        }

        /// <summary>
        /// Fragt die Benutzer nach den Namen
        /// und begrüßt sie passend zur aktuellen Stunde.
        /// </summary>
        private static void Begrüßen()
        {
            Anwendung.Ausgeben("Begrüßen startet...", debug: true);

            //Kommt später aus einer lokalisierten Ressource...
            const string Frage = "Wie heißen Sie? ";
            //                                   ^-> damit zur Antwort ein 
            //                                       Abstand ist.

            Anwendung.Ausgeben(Frage, AusgabeModus.NormalOhneVorschub);

            var Name = System.Console.ReadLine().Trim();
            //                                      ^-> damit überflüssige Leerzeichen
            //                                          vorne und hinten entfernt werden

            //Falls sich der Benutzer nicht
            //identifiziert, den Loginnamen benutzen...
            if (Name.Length == 0)
            {
                Name = System.Environment.UserName;
            }

            //Den Benutzer persönlich zur aktuellen Stunde begrüßen
            Anwendung.Ausgeben(Algorithmus.ErmittleBegrüßung(System.DateTime.Now.Hour).Replace("!", ", " + Name + "!"));
            //                                                    <----------- || ------------>
            //                                                      Anweisungen müssen von innen nach außen
            //                                                            "gelesen", aufgelöst werden

            Anwendung.Ausgeben("Begrüßen beendet.", debug: true);
        }

        /// <summary>
        /// Schreibt den Anwendungstitel in
        /// einem Rechteck auf den Bildschirm.
        /// </summary>
        private static void ZeichneTitel()
        {
            Anwendung.Ausgeben("ZeichneTitel startet...", debug: true);

            const string Titel = "Einführung in die objektorientierte Programmierung mit C# und .Net";
            const string TitelMuster = "{0}{1}{2}{3}{4}{3}{5}{1}{6}";

            var InnenBreite = System.Console.WindowWidth - 2;

            Anwendung.Ausgeben(
                string.Format(
                    TitelMuster,
                    Rahmen.LinksOben,                           // {0}
                    new string(Rahmen.Horizontal, InnenBreite), // {1}
                    Rahmen.RechtsOben,                          // {2}
                    Rahmen.Vertikal,                            // {3}
                    //der Text ist im Rahmen zentriert...
                    Titel.PadLeft((InnenBreite - Titel.Length) / 2 + Titel.Length)
                         .PadRight(InnenBreite),                // {4}
                    //---
                    Rahmen.LinksUnten,                          // {5}
                    Rahmen.RechtsUnten                          // {6}
                    ));

            Anwendung.Ausgeben("ZeichneTitel beendet.", debug: true);
        }
    }
}
