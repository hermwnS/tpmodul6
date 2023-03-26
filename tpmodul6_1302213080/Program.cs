using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    internal class SayaTubeVideo
    {
        private int PlayCount;
        private string title;
        private int id;

        public SayaTubeVideo(string title)
        {
            Contract.Requires(title != null, "Judul video harus diisi");
            Contract.Requires(title.Length <= 100, "Judul video maksimal panjangnya 100 karakter");

            this.id = new Random().Next(10000, 99999);
            this.title = title;
            this.PlayCount = 0;
        }
        public static void IncreasePlayCount(int count)
        {
            Contract.Requires(count >= 0 && count <= 10000000, "Input penambahan play count maksimalnya 10.000.000 per panggilan method");

            try
            {
                checked
                {
                    PlayCount += count;
                }
            }
            catch (OverflowException oe)
            {
                Console.WriteLine("Error : " + oe.Message);
            }
        }

        public static void PrintVideoDetails() 
        {
            Console.WriteLine("Id : " + id);
            Console.WriteLine("Title : " + title);
            Console.WriteLine("Play count : " + PlayCount);
        }
    }
    private static void Main(string[] args)
    {
        try
        {
            SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract - Hermawan Saputra");

            video.IncreasePlayCount(-1);
            video.IncreasePlayCount(10000001);

            for (int i = 0; i < 10000000; i++)
            {
                video.IncreasePlayCount(1);
            }

            video.PrintVideoDetails();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error : " + e.Message);
        }

    }
}