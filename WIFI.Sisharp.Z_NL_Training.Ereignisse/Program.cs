using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI.Sisharp.Z_NL_Training.Ereignisse
{

    public delegate void VideoUploadedEventHandler();


    class Program
    {
        static void Main(string[] args)
        {
            Uploader videouploader = new Uploader();
            Nachricthen benachrichtiger = new Nachricthen();

            videouploader.VideoUploaded += benachrichtiger.VideoUploaded;
            videouploader.VideoUpload();

            Console.Read();



        }
    }

    public class Uploader
    {
        // Event
        public event VideoUploadedEventHandler VideoUploaded;

        // Methode
        public void VideoUpload()
        {
            Console.WriteLine("Das Video wird hochgeladen");
            VideoUploaded();
        }

    }

    public class Nachricthen
    {
        public void VideoUploaded()
        {
            Console.WriteLine("Das Video wurde hochgeladen");
        }
    }


}
