using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung
{
    /// <summary>
    /// Stellt einen Dienst zum 
    /// Zurück- und Vorwärtswechseln bereit.
    /// </summary>
    public class Verlauf : System.Object
    {

        #region Ereignisse

        /// <summary>
        /// Wird ausgelöst, wenn kein Zurückgehen möglich ist
        /// </summary>
        public event System.EventHandler KeinZurück;

        /// <summary>
        /// Wird ausgelöst, wenn kein Vorwärtsgehen möglich ist
        /// </summary>
        public event System.EventHandler KeinVorwärts;

        /// <summary>
        /// Wird ausgelöst, wenn Zurückgehen möglich ist
        /// </summary>
        public event System.EventHandler ZurückMöglich;

        /// <summary>
        /// Wird ausgelöst, wenn Vorwärtsgehen möglich ist
        /// </summary>
        public event System.EventHandler VorwärtsMöglich;

        /// <summary>
        /// Löst das Ereignis KeinZurück aus.
        /// </summary>
        protected virtual void OnKeinZurück()
        {
            //Wegen des Multithreadings mit einer Kopie arbeiten,
            //damit der Garbage Collector das Behandlerobjekt nicht vernichtet...
            var BehandlerKopie = this.KeinZurück;

            if (BehandlerKopie != null)
            {
                BehandlerKopie(this, System.EventArgs.Empty);
            }
        }

        /// <summary>
        /// Löst das Ereignis KeinVorwärts aus.
        /// </summary>
        protected virtual void OnKeinVorwärts()
        {
            //Wegen des Multithreadings mit einer Kopie arbeiten,
            //damit der Garbage Collector das Behandlerobjekt nicht vernichtet...
            var BehandlerKopie = this.KeinVorwärts;

            if (BehandlerKopie != null)
            {
                BehandlerKopie(this, System.EventArgs.Empty);
            }
        }

        /// <summary>
        /// Löst das Ereignis ZurückMöglich aus.
        /// </summary>
        protected virtual void OnZurückMöglich()
        {
            //Wegen des Multithreadings mit einer Kopie arbeiten,
            //damit der Garbage Collector das Behandlerobjekt nicht vernichtet...
            var BehandlerKopie = this.ZurückMöglich;

            if (BehandlerKopie != null)
            {
                BehandlerKopie(this, System.EventArgs.Empty);
            }
        }

        /// <summary>
        /// Löst das Ereignis VorwärtsMöglich aus.
        /// </summary>
        protected virtual void OnVorwärtsMöglich()
        {
            //Wegen des Multithreadings mit einer Kopie arbeiten,
            //damit der Garbage Collector das Behandlerobjekt nicht vernichtet...
            var BehandlerKopie = this.VorwärtsMöglich;

            if (BehandlerKopie != null)
            {
                BehandlerKopie(this, System.EventArgs.Empty);
            }
        }

        #endregion Ereignisse

        #region Daten

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private System.Collections.Stack _ZurückPuffer = null;

        /// <summary>
        /// Internes Feld für die Eigenschaft
        /// </summary>
        private System.Collections.Stack _VorwärtsPuffer = null;

        /// <summary>
        /// Ruft die Liste mit den Objekten, zu denen
        /// Zurückgewechselt werden kann, ab.
        /// </summary>
        protected System.Collections.Stack ZurückPuffer
        {
            get
            {

                if (this._ZurückPuffer == null)
                {
                    this._ZurückPuffer = new System.Collections.Stack();
                }

                return this._ZurückPuffer;
            }
        }

        /// <summary>
        /// Ruft die Liste mit den Objekten, zu denen
        /// Vorwärtsgewechselt werden kann, ab.
        /// </summary>
        protected System.Collections.Stack VorwärtsPuffer
        {
            get
            {

                if (this._VorwärtsPuffer == null)
                {
                    this._VorwärtsPuffer = new System.Collections.Stack();
                }

                return this._VorwärtsPuffer;
            }
        }

        #endregion Daten

        /// <summary>
        /// Fügt dem Verlauf ein neues Objekt hinzu.
        /// </summary>
        /// <param name="element">Das Objekt, das dem
        /// Verlauf hinzugefügt werden soll.</param>
        /// <remarks>Der Vorwärtspuffer wird dabei geleert.
        /// Sollten im Zurückpuffer mehr als Element enthalten
        /// sein, wird das ZurückMöglich Ereignis ausgelöst.</remarks>
        public virtual void Hinterlegen(object element)
        {
            //Beim Hinzufügen eines neuen Objekts
            //den Vorwärtspuffer leeren
            this.OnKeinVorwärts();
            this.VorwärtsPuffer.Clear();

            //Das neue Objekt dem Zurückpuffer hinzufügen
            this.ZurückPuffer.Push(element);
            
            //Sollten mehr als ein Objekt im Zurück liegen,
            //dem Benutzerobjekt das mitteilen...
            if (this.ZurückPuffer.Count > 1)
            {
                this.OnZurückMöglich();
            }
        }

        /// <summary>
        /// Fügt das aktuelle Objekt des Zurückpuffers
        /// in den Vorwärtspuffer und gibt 
        /// das darunterliegende Objekt zurück.
        /// </summary>
        /// <remarks>Dabei wird das VorwärtsMöglich Ereignis
        /// ausgelöst. Sollte sich im Zurückpuffer nur mehr
        /// ein Objekt befinden, das KeinZurück Ereignis.</remarks>
        public virtual object HoleZurückObjekt()
        {
            this.VorwärtsPuffer.Push(this.ZurückPuffer.Pop());
            this.OnVorwärtsMöglich();

            if (this.ZurückPuffer.Count == 1)
            {
                this.OnKeinZurück();
            }

            return this.ZurückPuffer.Peek();

        }

        /// <summary>
        /// Stellt das oberste Element des Vorwärtspuffers
        /// in den Rückwärtspuffer und gibt es zurück.
        /// </summary>
        /// <remarks>Sollte der Vorwärtspuffer leer sein,
        /// wird das Ereignis KeinVorwärts ausgelöst. Sollten
        /// sich im Rückwärtspuffer mehr als ein Objekt
        /// befinden, wird ZurückMöglich ausgelöst.</remarks>
        public virtual object HoleVorwärtsObjekt()
        {

            this.ZurückPuffer.Push(this.VorwärtsPuffer.Pop());

            if (this.VorwärtsPuffer.Count == 0)
            {
                this.OnKeinVorwärts();
            }

            if (this.ZurückPuffer.Count > 1)
            {
                this.OnZurückMöglich();
            }

            return this.ZurückPuffer.Peek();
        }
    }
}
