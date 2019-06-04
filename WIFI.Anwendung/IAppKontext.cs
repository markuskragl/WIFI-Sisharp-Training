using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung
{
    /// <summary>
    /// Bestätigt, dass das Objekt die Infrastruktur bereitstellt.
    /// </summary>
    /// <remarks>Per Definitionen gibt es in einem Interface
    /// keine Zugriffsmodifizierer. Sonst macht das keinen Sinn.
    /// Die angeführten Mitglieder sind automatisch public.</remarks>
    public interface IAppKontext
    //               ^-> Alle Interfaces (Schnittstellen) müssen
    //                   mit einem großen "i" beginnen
    {
        /// <summary>
        /// Ruft das Infrastruktur Objekt ab oder liegt dieses fest.
        /// </summary>
        /// <remarks>In einem Interface sind nur die Signaturen
        /// der Eigenschaften, Methoden und Ereignissen. Keine Implementierung!</remarks>
        Anwendungskontext AppKontext { get; set; }
    }
}
