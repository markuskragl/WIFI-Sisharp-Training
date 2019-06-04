using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Lernen
{

    /// <summary>
    /// Stellt die Methode dar, die das FehlerAufgetreten Ereignis behandelt.
    /// </summary>
    /// <param name="sender">Immer der erste Parameter</param>
    /// <param name="e">Der zweite steht für "Ereignisdaten".</param>
    /// <remarks>Der 2. Schritt bei eigenen
    /// Ereignissen mit Daten. Sonst System.EventHandler</remarks>
    public delegate void FehlerAufgetretenEventHandler(object sender, FehlerAufgetretenEventArgs e);
    //              |-----------------------------------------------------------------------------|
    //                                  Signatur der Methode, die erlaubt ist.
    //
    //          ^-> Funktionszeiger von C#,
    //              aber "Typsicher"

    /// <summary>
    /// Stellt die Daten für das 
    /// FehlerAufgetreten Ereignis bereit.
    /// </summary>
    /// <remarks>Der 1. Schritt bei eigenen
    /// Ereignissen mit Daten. Sonst System.EventArgs.</remarks>
    public class FehlerAufgetretenEventArgs : System.EventArgs
    //           |----------------|   ^-> muss auf EventArgs enden 
    //                                    und System.EventArgs erweitern
    //            Name vom Ereignis
    {

        /// <summary>
        /// Internes Feld für die Eigenschaft.
        /// </summary>
        private System.Exception _Ursache = null;

        /// <summary>
        /// Ruft den Grund der Ausnahme ab.
        /// </summary>
        public System.Exception Ursache
        {
            get
            {
                return this._Ursache;
            }
        }

        /// <summary>
        /// Initialisiert ein neues FehlerAufgetretenEventArgs Objekt.
        /// </summary>
        /// <param name="ursache">Die Ausnahme, mit der
        /// der Fehler aufgetreten ist.</param>
        public FehlerAufgetretenEventArgs(System.Exception ursache)
        {
            this._Ursache = ursache;
        }
    }
}
