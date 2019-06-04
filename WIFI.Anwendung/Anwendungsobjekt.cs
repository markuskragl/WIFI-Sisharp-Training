using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung
{
    /// <summary>
    /// Unsterstützt sämtliche Objekte einer WIFI Anwendung.
    /// </summary>
    public abstract class Anwendungsobjekt : System.Object, IAppKontext
    //                                                          ^-> es können aber beliebig viele Interfaces implementiert werden
    //                                                 ^-> nur Einfachvererbung
    //      ^-> Modifizierer für "nicht fertig".
    //          Kann nicht instanziert werden.
    {
        /// <summary>
        /// Ruft das Infrastrukturobjekt ab oder legt dieses fest.
        /// </summary>
        /// <remarks>Bei Eigenschaften heißt der Kommentar
        /// immer "Ruft ab". Falls nicht schreibgeschützt
        /// steht auch noch "oder legt fest" dabei.</remarks>
        public Anwendungskontext AppKontext { get; set; }
        //                          ^-> Alle Eigenschaftennamen müssen ein Substantiv
        //                              und Pascal Notation aufweisen
        //-----------------------------------------------> implizite Eigenschaftendeklaration
        //                                                 (Hier wird das benötigte interne Feld
        //                                                  vom Compiler verwaltet)

        //Ereignisdeklaration, der 3. Schritt 
        //bei eigenen Ereignisdaten, sonst der 1. Schritt

        /// <summary>
        /// Wird ausgelöst, wenn eine Ausnahme 
        /// in der Anwendung aufgetreten ist.
        /// </summary>
        public event FehlerAufgetretenEventHandler FehlerAufgetreten;
        //              ^-> Delegate, der Methoden void Egal(object sender, FehlerAufgetretenEventArgs e) 
        //                            entgegen nimmt
        //           |----------------- technisch ausreichend
        //       ^-> Schlüsselwort event benötigt niemand
        //           nur, damit im Objektkalog ein Blitz angezeigt wird

        //Ereignisauslöser, der 4. Schritt
        //bei eigenen Ereignisdaten, sonst der 2. Schritt


        /// <summary>
        /// Löst das Ereignis FehlerAufgetreten aus.
        /// </summary>
        /// <param name="e">Das Objekt mit den Ereignisdaten</param>
        protected virtual void OnFehlerAufgetreten(FehlerAufgetretenEventArgs e)
        //                      ^-> müssen mit "On" im Namen beginnen
        //                  ^-> arbeiten ohne Rückgabe
        //          ^-> damit der Ereignisauslöser
        //              beim Überschreiben mit override
        //              vorgeschlagen wird
        //-> muss beim Erweitern nutzbar
        //   aber im Objekt unsichtbar sein
        {
            if (this.FehlerAufgetreten != null)
            {
                this.FehlerAufgetreten(this, e);
            }
        }

    }
}
