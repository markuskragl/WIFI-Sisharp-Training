using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung.Daten
{
    /// <summary>
    /// Untersützt alle Datenbank Anwendungsobjekte.
    /// </summary>
    public abstract class DatenAnwendungsobjekt : WIFI.Anwendung.Anwendungsobjekt
    {

        /// <summary>
        /// Ruft das Infrastrukturobjekt der Datenbankanwendung
        /// ab oder legt dieses fest.
        /// </summary>
        /// <remarks>Als Feld wird die Eigenschaft 
        /// der Basisklasse benutzt.</remarks>
        public new WIFI.Anwendung.Daten.DatenAnwendungskontext AppKontext
        {
            get
            {
                //Casten bei allen Typen, Ausnahmen möglich...
                //return (WIFI.Anwendung.Daten.DatenAnwendungskontext)base.AppKontext;

                //Nur bei Verweistypen ohne Ausnahme...
                return base.AppKontext as WIFI.Anwendung.Daten.DatenAnwendungskontext;
            }
            set
            {
                
                base.AppKontext = value;
            }
        }

    }
}
