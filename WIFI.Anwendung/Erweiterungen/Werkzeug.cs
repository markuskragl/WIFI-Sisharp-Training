using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung.Erweiterungen
{
    /// <summary>
    /// Stellt diverse Erweiterungsmethoden bereit.
    /// </summary>
    public static class Werkzeug
    {
        /// <summary>
        /// Prüft, ob im Pfad ein Unterordner für die
        /// aktuelle Kultur existiert und hängt diesen
        /// an den Pfad an und gibt das Ergebnis zurück.
        /// </summary>
        /// <param name="pfad">Verzeichnis, in dem geprüft 
        /// werden soll, ob ein lokalisierter Unterordner existiert.</param>
        /// <remarks>Es kann nicht davon ausgegangen werden,
        /// dass der Pfad existiert.</remarks>
        public static string HoleLokalisiertenPfad(this string pfad)
        {
            var AktuelleKultur = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;

            while (!System.IO.Directory.Exists(System.IO.Path.Combine(pfad, AktuelleKultur)) && AktuelleKultur != string.Empty)
            {
                //Fallback Lokalisierung
                var LetzterBindestrich = AktuelleKultur.LastIndexOf('-');

                if (LetzterBindestrich > -1)
                {
                    AktuelleKultur = AktuelleKultur.Substring(0, LetzterBindestrich);
                }
                else
                {
                    AktuelleKultur = string.Empty;
                }
            }

            return System.IO.Path.Combine(pfad, AktuelleKultur);
        }
    }
}
