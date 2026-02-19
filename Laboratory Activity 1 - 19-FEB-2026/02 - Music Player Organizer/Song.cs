using System;
using System.Linq;

namespace MusicPlayerOrganizer
{
    class Song
    {
        public string title;
        public string artist;
        public double duration;

        public Song() : this("Unknown", "Unknown") { }

        public Song(string title, string artist) : this(title, artist, 0.0) { }

        public Song(string title, string artist, double duration)
        {
            this.title = title;
            this.artist = artist;
            this.duration = duration;
        }

        public void DisplaySong()
        {
            Console.WriteLine($"{title,-20} {artist,-20} {duration:F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Songs to add: ");
            if (!int.TryParse(Console.ReadLine(), out int count)) count = 0;

            Song[] playlist = new Song[count];

            for (int i = 0; i < count; i++)
                {
                Console.WriteLine($"\nSong #{i + 1}");

                Console.Write("Title: ");
                string t = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(t)) t = "Unknown";

                Console.Write("Artist: ");
                string a = Console.ReadLine();            
                if (string.IsNullOrWhiteSpace(a)) a = "Unknown";

                Console.Write("Duration (minutes): ");
                string durationInput = Console.ReadLine();
                double d;
                if (!double.TryParse(durationInput, out d)) d = 0.00;

                playlist[i] = new Song(t, a, d);
                }

            Console.WriteLine("\n=== || MY PLAYLIST || ===");
            Console.WriteLine($"{"Title",-20} {"Artist",-20} {"Time",-10}");
            Console.WriteLine(new string('-', 50));

            double totalDuration = 0;
            foreach (var song in playlist)
            {
                song.DisplaySong();
                totalDuration += song.duration;
            }

            double average = count > 0 ? totalDuration / count : 0;

            Console.WriteLine($"\nTotal Duration: {totalDuration:F2} mins");
            Console.WriteLine($"Average Duration: {average:F2} mins");
        }
    }
}
