using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Lernen
{
    /// <summary>
    /// Stellt Zeichen zum Erstellen von Rahmen bereit.
    /// </summary>
    public static class Rahmen : System.Object
    //      ^-> wird eine Klasse statisch deklariert,
    //          kann kein Objekt erstellt werden und
    //          müssen alle Mitglieder ebenfalls statisch sein
    {
        /// <summary>
        /// Ruft das Zeichen für die linke obere Ecke ab.
        /// </summary>
        public static char LinksOben
        {
            get
            {
                return '\u250C';
            }
        }

        /// <summary>
        /// Ruft das Zeichen für die rechte obere Ecke ab.
        /// </summary>
        public static char RechtsOben
        {
            get
            {
                return '\u2510';
            }
        }

        /// <summary>
        /// Ruft das Zeichen für die linke untere Ecke ab.
        /// </summary>
        public static char LinksUnten
        {
            get
            {
                return '\u2514';
            }
        }

        /// <summary>
        /// Ruft das Zeichen für die rechte untere Ecke ab.
        /// </summary>
        public static char RechtsUnten
        {
            get
            {
                return '\u2518';
            }
        }

        /// <summary>
        /// Ruft das Zeichen für eine waagrechte Linie ab.
        /// </summary>
        public static char Horizontal
        {
            get
            {
                return '\u2500';
            }
        }

        /// <summary>
        /// Ruft das Zeichen für eine senkrechte Linie ab.
        /// </summary>
        public static char Vertikal
        {
            get
            {
                return '\u2502';
            }
        }

    }
}
