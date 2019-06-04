using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Lernen
{
    /// <summary>
    /// Listet die beim Lotto unterstützten Länder auf.
    /// </summary>
    public enum LottoLänder
    {
        Österreich,
        Deutschland,
        Italien
    }

    /// <summary>
    /// Stellt einen Dienst zum Berechnen
    /// von Quicktipps für diverse Länder bereit.
    /// </summary>
    public sealed class Lotto : Entwicklungsbasis
    //      ^-> Dieser Modifizierer verhindert, dass
    //          unsere Lotto Klasse als Basisklasse benutzt
    //          werden kann (sowie z. B. System.String)
    {

        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        private LottoLänder _Land = LottoLänder.Österreich;

        //Bitte nicht:
        //private LottoLänder _LottoLand = ...
        //                      ^-> NICHT im Namen einer Eigenschaft
        //                          den Namen der Klasse wiederholen!!!
        //                          Würde später blöd aussehen:
        //                          Lotto.LottoLand
        //                          Richtig: Lotto.Land

        /// <summary>
        /// Ruft das Land, in dem gespielt wird,
        /// ab oder legt dieses fest.
        /// </summary>
        /// <remarks>Standardwert Österreich</remarks>
        public LottoLänder Land
        {
            get
            {
                //Wie eine Funktionsmethode...
                return this._Land;
            }
            set
            {
                //Wie eine Methode, eine "void" Methode...
                //Jetzt muss man wissen, wie der Compiler
                //den Parameter in der Schnittstelle für
                //den neuen Wert nennt...
                //=> "value", der Name des Parameters vom Compiler

                this._Land = value;
            }
        }

        /// <summary>
        /// Ruft die größte Zahl beim Lotto
        /// für das eingestellte Land ab.
        /// </summary>
        public int HöchsteZahl
        {
            get
            {
                switch (this.Land)
                {
                    case LottoLänder.Deutschland:
                        return 49;
                        //-> weil nach return kein weiterer
                        //   Code ausgeführt wird, kann hier auf
                        //   break; verzichtet werden
                    case LottoLänder.Italien:
                        return 90;
                    case LottoLänder.Österreich:
                        return 45;

                    default:
                        return -1;
                }
            }
        }

        /// <summary>
        /// Ruft die Anzahl der Zahlen eines Lotto-Tipps 
        /// für das eingestellte Land ab.
        /// </summary>
        public int AnzahlZahlen
        {
            get
            {
                switch (this.Land)
                {
                    case LottoLänder.Deutschland:
                    case LottoLänder.Italien:
                    case LottoLänder.Österreich:
                        return 6;

                    default:
                        return -1;
                }
            }
        }

        //public void BerechneQuicktipp()
        //         ^-> Methode ohne Rückgabe

        //public int
        //        ^-> ist jetzt nur EINE ZAHL
        //            wir benötigten mehrere, ein Array

        /// <summary>
        /// Gibt die Zahlen eines Lotto Quicktipps
        /// für das eingestellte Land zurück.
        /// </summary>
        public int[] BerechneQuicktipp()
        //         ^-> C# nutzt für (statische) Datenfelder
        //             eckige Klammern
        {
            
            var Ergebnis = new int[this.AnzahlZahlen];
            //             |-------------------->
            //              Initialisierung eines statischen Arrays.
            //              Kann ab jetzt nicht mehr im Umfang verändert werden.
            
            int AktuelleAnzahl = 0;

            //Weil Random.Next(min, max)
            //max exklusiv hat
            int N = this.HöchsteZahl + 1;

            //In einer Durchlaufeschleife...
            do
            {
                //int NeueZahl = this.Zufallsgenerator.Next(1, this.HöchsteZahl + 1);
                //                                             |-------------------|
                //                                              nicht mehrmals in Schleifen berechnen
                //                                              (Strom sparen!!!)

                int NeueZahl = this.Zufallsgenerator.Next(1, N);
                var Gefunden = false;
                int i = 0;

                //Ab der zweiten Zahlen prüfen,
                //ob schon vorhanden...
                while (i < AktuelleAnzahl && !Gefunden)
                //                           ^-> Rufzeichen für Verneinung
                //                         ^-> "Logisches UND"
                //                             "Logisches ODER" wären || (zwei Pipes)
                {
                    //if (Ergebnis)
                    //         ^-> die "ganze" Liste

                    if (Ergebnis[i] == NeueZahl)
                    {
                        Gefunden = true;
                    }
                    else
                    {
                        //i = i + 1;
                        i++;
                    }
                }

                //Nur, falls die Zahl noch nicht
                //vorhanden ist, merken...

                if (!Gefunden)
                {
                    Ergebnis[AktuelleAnzahl] = NeueZahl;
                    AktuelleAnzahl++;
                }

                //bis die erfordliche Anzahl vorhanden ist...
            } while (AktuelleAnzahl < this.AnzahlZahlen);

            //Noch nachsehen, ob sortiert werden muss...
            if (this.Sortiert)
            {
                System.Array.Sort(Ergebnis);
            }

            return Ergebnis;
        }

        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        private bool _Sortiert = false;

        /// <summary>
        /// Ruft einen Wahrheitswert ab,
        /// ob BerechneQuicktipp die Zahlen
        /// sortiert zurückgeben soll, 
        /// oder legt diesen fest.
        /// </summary>
        /// <remarks>Standardwert False</remarks>
        public bool Sortiert
        {
            get
            {
                return this._Sortiert;
            }
            set
            {
                this._Sortiert = value;
            }
        }
    }
}
