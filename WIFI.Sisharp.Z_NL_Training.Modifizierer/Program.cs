using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Z_NL_Training.Modifizierer
{
    class Program
    {
        static void Main(string[] args)
        {
            MeineKlasse MK = new MeineKlasse();

            MK.Eigenschaft1 = 5;

            MK.Eigenschaft4 = 4;

            

            var b = new MeineKlasse.UnterKlasse();

            var wert = b.TuIrgendwas(7);

            b.wert = 6;

            var wert2 = b.wert;

            b.wert = 7;

            var c = new MeineKlasse();

            Console.WriteLine(b.Eigenschaft5.ToString() + "\n" + c.Eigenschaft5.ToString());
            Console.ReadLine();


            var d = new UnterUnterKlasse();

            Console.WriteLine(d.Eigenschaft5);
            Console.ReadLine();

            b.Dispose();

            double wert15 = b.Eigenschaft1;

      
        }
    }

    public class MeineKlasse : IDisposable
    {
        public double Eigenschaft1 { get; set; }

        private int Eigenschaft2 { get; set; }

        protected int Eigenschaft3 { get; set; }

        internal int Eigenschaft4 { get; set; }

        public  int  TuIrgendwas(double wert)
        {
            int wert1 = default(int);

            wert1 = (int)wert;
            return wert1;
        }

        protected static  int TuAnderes()
        {
            return 10;
        }

        public virtual int Eigenschaft5
        {
            get
            {
                return 5;
            }
            set
            {

            }
        }


       

        int wert = default(int);

        public class UnterKlasse : MeineKlasse
        {
            private int _Zahl = 7;

            public sealed override int Eigenschaft5
            {
                get
                {
                    return 10;
                }
                set
                {

                }

            }


            
            

            public int wert = TuAnderes() ;

            

        }

        #region IDisposable Support
        private bool disposedValue = false; // Dient zur Erkennung redundanter Aufrufe.

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: verwalteten Zustand (verwaltete Objekte) entsorgen.
                }

                // TODO: nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer weiter unten überschreiben.
                // TODO: große Felder auf Null setzen.

                disposedValue = true;
            }
        }

        // TODO: Finalizer nur überschreiben, wenn Dispose(bool disposing) weiter oben Code für die Freigabe nicht verwalteter Ressourcen enthält.
        // ~MeineKlasse() {
        //   // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
        //   Dispose(false);
        // }

        // Dieser Code wird hinzugefügt, um das Dispose-Muster richtig zu implementieren.
        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
            Dispose(true);
            // TODO: Auskommentierung der folgenden Zeile aufheben, wenn der Finalizer weiter oben überschrieben wird.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class UnterUnterKlasse : MeineKlasse.UnterKlasse
    {
        public new int Eigenschaft5
        {
            get
            {
                return 5;


            }
            set
            {

            }
        }


        int wert333 = TuAnderes();
            
    }


}
