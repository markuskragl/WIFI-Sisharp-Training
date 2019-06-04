using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Anwendung.Controller
{

    //Neue Version: Erweitern einer generischen Klasse
    //20190117

    /// <summary>
    /// Stellt einen Dienst zum Speichern und Lesen
    /// von Fensterpositionen in und aus einer 
    /// Xml-Datei bereit.
    /// </summary>
    internal class FensterXmlController : Generisch.XmlController<Daten.FensterListe>
    {

    }

    ///// <summary>
    ///// Stellt einen Dienst zum Speichern und Lesen
    ///// von Fensterpositionen in und aus einer 
    ///// Xml-Datei bereit.
    ///// </summary>
    ///// <remarks>Controller sollen "schlank" implementiert
    ///// werden, damit diese einfach durch eine andere 
    ///// Technologie ausgetauscht werden können.
    ///// Deshalb werden hier Ausnahmen ausgelöst.
    ///// Hier wird die Xml Serialisierung benutzt.</remarks>
    //internal class FensterXmlController : Anwendungsobjekt
    //{

    //    /// <summary>
    //    /// Schreibt die Daten im Xml Format
    //    /// in die angegebene Datei.
    //    /// </summary>
    //    /// <param name="pfad">Vollständiger Name der Datei,
    //    /// die benutzt werden soll.</param>
    //    /// <param name="daten">Die Liste mit den Informationen,
    //    /// die als Xml gespeichert werden sollen.</param>
    //    /// <exception cref="System.Exception">Wird ausgelöst,
    //    /// wenn das Speichern nicht erfolgreich war.</exception>
    //    public void Speichern(string pfad, WIFI.Anwendung.Daten.FensterListe daten)
    //    //                             ^-> nur bei Parametern wird Camel-Notation benutzt!
    //    //             ^-> überall Pascal-Notation
    //    {

    //        //var Schreiber = new System.IO.StreamWriter(pfad);
    //        //Schreiber.Dispose...
    //        //              ^-> immer wenn vorhanden, darf auf den Aufruf
    //        //                  am Ende nicht vergessen werden

    //        //Seit 2002 eine Anweisung, die "Dispose()" implizit aufruft
    //        //-> Was benötigt man für Erweiterungsmethoden? using-Direktive
    //        //-> using gibt's auch als Anweisung, wenn Dispose() mitaufgerufen werden soll...
    //        using (var Schreiber = new System.IO.StreamWriter(pfad))
    //        {
    //            var Serialisierer = new System.Xml.Serialization.XmlSerializer(daten.GetType());
    //            Serialisierer.Serialize(Schreiber, daten);

    //        } //<- hier wird Schreiber.Dispose() implizit aufgerufen
    //    }

    //    /// <summary>
    //    /// Gibt die Daten aus der Xml Datei zurück.
    //    /// </summary>
    //    /// <param name="pfad">Vollständiger Name der Datei,
    //    /// die benutzt werden soll.</param>
    //    /// <exception cref="System.Exception">Wird ausgelöst, wenn
    //    /// das Lesen nicht erfolgreich ist.</exception>
    //    public WIFI.Anwendung.Daten.FensterListe Lesen(string pfad)
    //    {
    //        //Ist kritisch, weil unter Umständen
    //        //gibt es die Datei bei einem neuen Benutzer nicht.

    //        //=> Was passiert bei "kritischem" Code?
    //        //   Die Anwendung stürzt ab.

    //        WIFI.Anwendung.Daten.FensterListe Ergebnis = null;

    //        using (var Leser = new System.IO.StreamReader(pfad))
    //        {
    //            var Serialisierer = new System.Xml.Serialization.XmlSerializer(typeof(WIFI.Anwendung.Daten.FensterListe));
    //            Ergebnis = (WIFI.Anwendung.Daten.FensterListe)Serialisierer.Deserialize(Leser);
    //        }

    //        return Ergebnis;
    //    }

    //}
}
