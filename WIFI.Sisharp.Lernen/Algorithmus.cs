using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Lernen
{ //<- Hier beginnt die Namespace - Gültigkeit
    
    /// <summary>
    /// Stellt für jeden Algorithmen 
    /// Baustein ein Beispiel bereit.
    /// </summary>
    internal class Algorithmus : Entwicklungsbasis
    { //<- Hier beginnt die Gültigkeit der Klasse

        /// <summary>
        /// Gibt das obligatorische 
        /// "Hallo Welt!" auf dem Bildschirm aus.
        /// </summary>
        public void ZeigeSequenz()
        { //<- Gültigkeitsbereich von ZeigeSequenz

            //Für das Protokoll...
            Algorithmus.Ausgeben("ZeigeSequenz startet...", debug: true);
            //                   |-----------------------|
            //                      Text-Konstanten unter 
            //                      Anführungszeichen.
            //                      KEINE solchen KONSTANTEN FÜR
            //                      BENUTZER. Warum? Weil man diese
            //                      Anwendung nicht "globalisieren", d.h.
            //                      in andere Benutzersprachen übersetzen kann
            //=> Ab C# Teil 1 kommen diese Texte aus Ressource-Dateien

            // Speicher reservieren für "Hallo Welt!"
            string ObligatorischerText = "Hallo objektorientierte Welt!";
            //                                                          ^-> jede Anweisung muss in C#
            //                                                              mit Strichpunkt beendet werden.
            //                         ^-> Operator für die Wertzuweisung
            //          ^-> der Name vom reservierten Speicher (Variable)
            //              Keine Leer- und Sonderzeichen. Keine Ziffer am Anfang.
            //-> der Typ. "string" C# Alias auf Sytem.String

            // Den Speicherinhalt für den Benutzer ausgeben
            //Algorithmus.Ausgeben(ObligatorischerText, debug: false);
            //                      |------------------------------|
            //                          ohne Überladung, muss immer alles
            //                          angegeben werden

            //Überladung nur wegen des Komforts beim benutzen
            Algorithmus.Ausgeben(ObligatorischerText);

            //Für das Protokoll...
            Algorithmus.Ausgeben("ZeigeSequenz beendet.", debug: true);

        } //<- Ende der Gültigkeit von ZeigeSequenz

        /// <summary>
        /// Ermittelt eine zufällige Ganzzahl
        /// zwischen 1 und 100 und gibt zu dieser
        /// aus, ob die Zahl kleiner 50 oder
        /// größer gleich 50 ist.
        /// </summary>
        public void ZeigeBinär()
        {

            //Änderungen
            // 20181130 Falls die Zahl die Grenze, wird nicht
            //          mehr "oder größer" gemeldet

            Algorithmus.Ausgeben("ZeigeBinär startet...", debug: true);

            //Speicher reservieren
            //-> kann sich nicht ändern: Konstanten
            const int Untergrenze = 1;
            const int Obergrenze = 100;
            const int Grenze = 50;

            //--- später aus Ressource-Dateien
            const string HinweisKleiner = "Die Zahl {0} ist kleiner der Grenze {1}!";
            //                                       ^-> Parameter für die foramtierte Ausgabe
            //                                           Das gesamte .Net ist nullbasierend.

            //20181130
            //const string HinweisGrößerGleich = "Die Zahl {0} ist größer oder gleich der Grenze {1}!";
            const string HinweisGrößer = "Die Zahl {0} ist größer der Grenze {1}!";
            const string HinweisGleich = "Die Zahl {0} ist die Grenze!";

            //-> kann sich ändern: Variablen
            //Zufällige Zahl berechnen
            int Zufallszahl = this.Zufallsgenerator.Next(Untergrenze, Obergrenze + 1);
            //                                                        |-- exklusiv
            //                                           |-- inklusiv
            //                                       ^-> überladene Methode vom Random-Objekt
            //                          ^-> Eigenschaft, geerbt von der Entwicklungsbasis,
            //                              die ein eindeutiges Random-Objekt verwaltet

            //Falls diese kleiner der Grenze
            if (Zufallszahl < Grenze)
            {
                //Ja nicht so...
                //Algorithmus.Ausgeben("Die Zahl " + Zufallszahl...)
                //                     |------------- KEINE Textverkettungen
                //                      Warum?
                //                          - Langsam
                //                          Hauptgrund:
                //                          - Solche Anwendungen können nicht "lokalisiert",
                //                            d.h. in andere Benutzersprachen übersetzt werden!
                //                          - Diese Texte kommen aus übersetzten Ressource-Dateien
                //                            (ab Teil 1)

                Algorithmus.Ausgeben(string.Format(HinweisKleiner, Zufallszahl, Grenze));
                //                                                  {0}          {1}
                //                                      ^-> Muster mit Parametern
                //                             ^-> .Net Textformatierung
            }

            //20181130
            else if (Zufallszahl == Grenze)
            {
                Algorithmus.Ausgeben(string.Format(HinweisGleich, Zufallszahl));
            }
            //---

            else
            {
                //20181130
                //Algorithmus.Ausgeben(string.Format(HinweisGrößerGleich, Zufallszahl, Grenze));
                Algorithmus.Ausgeben(string.Format(HinweisGrößer, Zufallszahl, Grenze));
            }

            Algorithmus.Ausgeben("ZeigeBinär beendet.", debug: true);
        }

        /// <summary>
        /// Ermittelt eine Begrüßung zu einer
        /// zufälligen Stunde.
        /// </summary>
        public void ZeigeFall()
        {
            Algorithmus.Ausgeben("ZeigeFall startet...", debug: true);

            //Ausgabemuster
            const string Hinweis = "{0} Es ist {1} Uhr...";

            //Zufällige Stunde
            var ZufälligeStunde = this.Zufallsgenerator.Next(24);

            //In das Ausgabemuster die zufällige Stunde
            //und den Begrüßungstext für diese einsetzen
            //und ausgeben
            
            Algorithmus.Ausgeben(string.Format(Hinweis, Algorithmus.ErmittleBegrüßung(ZufälligeStunde), ZufälligeStunde));
            //                   Anweisungen werden von "innen" nach "außen"  <--------------||-----------> aufgelöst

            Algorithmus.Ausgeben("ZeigeFall beendet.", debug: true);
        }

        /// <summary>
        /// Testet ErmittleBegrüßung für jede
        /// mögliche Stunden zwischen 0 und 23.
        /// </summary>
        public void ZeigeZählen()
        {
            Algorithmus.Ausgeben("ZeigeZählen startet...", debug: true);

            //Ausgabemuster
            const string Hinweis = "{0} Es ist {1} Uhr...";

            /*
            //Idee: => Scheiße, eine Sequenz
            Algorithmus.Ausgeben(string.Format(Hinweis, Algorithmus.ErmittleBegrüßung(0), 0));
            Algorithmus.Ausgeben(string.Format(Hinweis, Algorithmus.ErmittleBegrüßung(1), 1));
            Algorithmus.Ausgeben(string.Format(Hinweis, Algorithmus.ErmittleBegrüßung(2), 2));
            Algorithmus.Ausgeben(string.Format(Hinweis, Algorithmus.ErmittleBegrüßung(3), 3));
            //...
            Algorithmus.Ausgeben(string.Format(Hinweis, Algorithmus.ErmittleBegrüßung(23), 23));
            //                                                                         ^-> der einzige Unterschied
            //                                                                             diese Zahl heißt "Index"
            */
            //Lösung: eine Schleife
            // 3. Die Anzahl ist nicht bekannt, aber mind. 1x
            //      Die Durchlaufschleife (do) -> hier nicht
            // 2. Die Anzahl ist vollkommen unbekannt, unter Umständen nie
            //      Die Abweiseschleife (while) -> hier nicht
            // 1. Die Anzahl der Wiederholung ist vor dem
            //    Schleifentritt bekannt
            //
            //  => Die Zählschleife (for)
            //      für unsere Aufgabe

            for (int i = 0; i < 24; i++)
            {
                Algorithmus.Ausgeben(string.Format(Hinweis, Algorithmus.ErmittleBegrüßung(i), i));
            }

            Algorithmus.Ausgeben("ZeigeZählen beendet.", debug: true);
        }

        /// <summary>
        /// Gibt den Inhalt einer 
        /// unformatierten Textdatei aus.
        /// </summary>
        /// <remarks>Die Datei muss "Wörter.txt" heißen
        /// und im Anwendungsverzeichnis liegen.</remarks>
        public void ZeigeAbweisen()
        {
            Algorithmus.Ausgeben("ZeigeAbweisen startet...", debug: true);

            Algorithmus.Ausgeben($"Startverzeichnis: {this.Anwendungsverzeichnis}", AusgabeModus.Debug);

            //Zum Testen vom eigenen Ereignis,
            //in 20 % der Aufrufe einen falschen Namen angeben
            string Dateiname = this.Zufallsgenerator.Next(100) < 80 ? "Wörter.txt" : "Wörter.Gibts.Ned";
            var Pfad = System.IO.Path.Combine(this.Anwendungsverzeichnis, Dateiname);
            //                          ^-> benutzt unter Windows einen Backslash
            //                              Einen Schrägstrich in Linux

            /*
            //Wird ein Objekt nicht sofort benötigt:
            //(1) Variable für die Objektadresse
            Textdatei Datei = null;

            //(2) Objekt initialisieren
            Datei = new Textdatei();
            */
            //Es kann aber sein, dass ein Objekt sofort 
            //benötigt wird. In diesem Fall (1) und (2)
            //als ein Schritt...
            var Datei = new Textdatei();

            //(3) Objekt benutzen

            //Für das Ereignis LeseFehlerAufgetreten
            //einen Ereignisbehandler anhängen
            Datei.LeseFehlerAufgetreten += FehlerMelden;
            
            Datei.Pfad = Pfad;
            Algorithmus.Ausgeben(
                Datei.HoleFließtext(
                    (int)(System.Console.WindowWidth * this.Zufallsgenerator.Next(33, 67) / 100.0f)
                    //                                                                          ^-> damit 100 nicht als Ganzzahl
                    //                                                                              interpretiert wird
                    //-> "Typ-Bestätigung (Casten)". HoleFließtext möchte eine Ganzzahl
                    //   Die Berechnung liefert aber System.Single (float in C#)
                    //   Der Kompiler meldet, wir verlieren Genauigkeit.
                    //   Mit dem Casten wird dem Kompiler bestätigt,
                    //   dass wir das wissen (und uns hier wurscht ist, weil
                    //   keine halben Zeichen in der Konsole existieren)
                    ));
            

            //(4) Objekt für die Vernichtung freigeben
            //Datei.Dis...
            //-> Keine Dispose() Methode zum Zusammenräumen
            Datei = null;
            //Wer räumt das Objekt aus dem Speicher?
            //=> Der Garbage Collector

            Algorithmus.Ausgeben("ZeigeAbweisen beendet.", debug: true);
        }

        /// <summary>
        /// Teilt dem Benutzer in der Konsole mit, dass ein Problem 
        /// aufgetreten ist.
        /// </summary>
        /// <param name="sender">Immer das 1. Argument. Von welchem Objekt
        /// wird der Behandler aufgerufen.</param>
        /// <param name="e">Immer das 2. Argument. Die Ereignisdaten.
        /// Falls der Typ System.EventArgs keine Zusatzinformation.
        /// Hier Zusatzinformation, weil nicht System.EventArgs.</param>
        /// <remarks>Hier handelt es sich um einen Ereignisbehandler.</remarks>
        private void FehlerMelden(object sender, FehlerAufgetretenEventArgs e)
        {
            Algorithmus.Ausgeben(
                $"TEST eines eigenen Ereignisses in 20 % der Aufrufe:\r\n\r\nFehlerursache: {e.Ursache.Message}",
                AusgabeModus.Fehler);
        }

        /// <summary>
        /// Zeigt einen Lotto Quicktipp 
        /// für Österreich an.
        /// </summary>
        public void ZeigeDurchlaufen()
        {
            Algorithmus.Ausgeben("ZeigeDurchlaufen startet...", debug: true);

            var Lotto = new Lotto();
            //  ^-> macht Microsoft liebend gerne,
            //      die Objektvariable genauso zu nennen,
            //      wie die Klasse

            //Land zufällig einstellen
            Lotto.Land 
                = (LottoLänder)this.Zufallsgenerator
                    .Next(System.Enum.GetValues(typeof(LottoLänder)).Length);

            //Reihenfolge zufällig einstellen...
            //Lotto.Sortiert = this.Zufallsgenerator.Next(2) == 1 ? true : false;
            //                 |---------------------------------|
            //                      ist schon true oder false
            Lotto.Sortiert = this.Zufallsgenerator.Next(2) == 1;


            //Das zufällige Land und die Zahlen
            //eines Quicktipps ausgeben.
            var Text = new System.Text.StringBuilder();

            Text.AppendLine($"Lotto Quicktipp {Lotto.Land}: {Lotto.AnzahlZahlen} aus {Lotto.HöchsteZahl}");

            //Die Anzahl der Zahlen ist bekannt, deshalb...
            //Zählschleife. Weil jede Zahl des Datenfelds
            //benötigt wird, die Spezialzählschleife...
            foreach(int Zahl in Lotto.BerechneQuicktipp())
            {
                Text.Append(Zahl.ToString().PadLeft(3));
            }

            Text.AppendLine();

            //Noch einen Hinweis, ob die Zahlen
            //in gezogener oder in aufsteigender Reihenfolge sind
            Text.AppendLine($"(In {(Lotto.Sortiert ? "aufsteigend" : "gezogener")} Reihenfolge)");
            //                                     ^-> Fragezeichen-Doppelpunkt
            //                                        entspricht der WENN-Funktion in Excel
            //                                        eine Binärentscheidung in einer Anweisung
            //                     |--------------------------------------------|
            //                          runde Klammern zur Unterstützung
            //                          der Syntaxprüfung vom Kompiler

            Algorithmus.Ausgeben(Text.ToString());

            //Lotto.dispose... Nicht vorhanden, falls ein 
            //                 Objekt ein Dispose() hat,
            //                 IMMER aufrufen, wenn das Objekt
            //                 nicht mehr benötigt wird
            Lotto = null;

            Algorithmus.Ausgeben("ZeigeDurchlaufen beendet.", debug: true);
        }

        /// <summary>
        /// Gibt passend zur Stunde einen Begrüßungstext zurück.
        /// </summary>
        /// <param name="zuStunde">Ein Wert zwischen 0 und 23.</param>
        /// <remarks>Zwischen 5 und 10 "Guten Morgen!", zwischen 11 und 14 "Mahlzeit!",
        /// zwischen 18 und 22 "Guten Abend!" und sonst "Grüß Gott!"</remarks>
        public static string ErmittleBegrüßung(int zuStunde)
        {

            //Kommt später aus lokalisierten Ressourcen...
            const string GrußAmMorgen = "Guten Morgen!";
            const string GrußZuNMittag = "Mahlzeit!";
            const string GrußAmAbend = "Guten Abend!";
            const string StandardGruß = "Grüß Gott!";
            //--------

            //Jammerei:
            //string Ergebnis = StandardGruß;
            // ^-> muss ich hier "string" schreiben?
            //     Der Kompiler weiß ja eh auf Grund der Zuweisung
            //     vom System.String StandardGruß, dass das
            //     ein Text ist
            //Microsoft hat sich 2005 erbarmt
            var Ergebnis = StandardGruß;
            //-> "Lieber Kompiler, such dir den Typ selber
            //   Funktioniert aber nur, wenn der Typ bestimmbar ist,
            //   also NICHT MIT "null" (Keine Speicheradresse)

            //Wir könnten die vier Fälle mit
            //drei Binärentscheidungen lösen...
            //if (zuStunde >= 5 && zuStunde <= 10) ...

            //Aber:
            //=> Eleganer

            //DIE FALLENTSCHEIUNG
            /*
            //bis C# 2016 (wie in C/C++, ...)
            switch (zuStunde)
            {
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    Ergebnis = GrußAmMorgen;
                    break;
                //...
            }
            */
            //Voi cool seit C# 2016, Version 7
            switch (zuStunde)
            {
                case var s when s >= 5 && s <= 10:
                    //      ^-> seit 2016, neues Kontextschlüsselwort beim switch
                    //          zum Ausformulieren einer Bedingung
                    Ergebnis = GrußAmMorgen;
                    break;
                case var s when s >= 11 && s <= 14:
                    Ergebnis = GrußZuNMittag;
                    break;
                case var s when s >= 18 && s <= 22:
                    Ergebnis = GrußAmAbend;
                    break;

                /*
                //Bereits oben so initialisiert
                default:
                    Ergebnis = StandardGruß;
                    break;
                */
            }

            return Ergebnis;
        }

    } //<- Ende Gültigkeit der Klasse
} //<- Ende Gültigkeit des Namespace
//     ^-> JA NICHT DIESE KOMMENTARE SCHREIBEN!
//         Wer das braucht, muss BASIC programmieren
//         Dort hiese es "End Namespace"
