using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Z_NL_Training.Ereignisse2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Erstelle die Objekte
            Wort _word = new Wort();
            Benachrichtiger _benachrichtiger = new Benachrichtiger();

            // Abonniere das Event
            _word.WordChanged += _benachrichtiger.WordChanged;

            // Ändere das Wort
            _word.ChangeWord("Janek");
            _word.ChangeWord("Hendrik");

            Console.Read();

        }
    }

    public delegate void WordChangedEventHandler(object sender, WordChangedEventArgs e);

    public class Wort
    {
        private string MyWord;

        public void ChangeWord(string txt)
        {
            MyWord = txt;
            Console.WriteLine(MyWord);
            OnWordChanged();
        }

        public event WordChangedEventHandler WordChanged;

        protected virtual void OnWordChanged()
        {
            if(WordChanged != null)
            {
                WordChangedEventArgs args = new WordChangedEventArgs();
                args.Word = MyWord;

                WordChanged(this, args);
            }
        }

    }

    public class Benachrichtiger
    {
        public void WordChanged(object sender, WordChangedEventArgs e)
        {
            string newWord = e.Word;
            Console.WriteLine("Das neue Wort ist: " + newWord);
        }



    }
    /// <summary>
    /// Dient als Transportobjekt für das event
    /// </summary>
    public class WordChangedEventArgs : EventArgs
    {
        public string Word { get; set; }
    }
}
