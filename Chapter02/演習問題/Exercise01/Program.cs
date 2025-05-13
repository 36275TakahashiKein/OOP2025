namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {
            //2.1.3
            var songs = new Song[] {
                new Song("Let it be", "The Beatles", 243),
                new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
                new Song("Close To You", "Carpenters", 276),
                new Song("Honesty", "Billy Joel", 231),
                new Song("I Will Always Love You", "Whitney Houston", 273),
            };
            printSongs(songs);

        }

        //2.1.4
        private static void printSongs(Song[] songs) {

            //TimeSpan構造体を使った場合
            foreach (var song in songs) {
                var timespan = TimeSpan.FromSeconds(song.Length);
                Console.WriteLine($"{song.Title},{song.ArtistName},{timespan.Minutes}:{timespan.Seconds}");
            }

            foreach (var song in songs) {
                Console.WriteLine(@"{0},{1} {2:m\:ss}",
                song.Title ,song.ArtistName ,TimeSpan.FromSeconds(song.Length));
                //foreach (var song in songs) {
                //    var minitue = song.Length / 60;
                //    var seconds = song.Length % 60;
                //    Console.WriteLine($"{song.Title},{song.ArtistName},{minitue}:{seconds:00}");
                //}
                //for (var i = 0; i < songs.Length; i++) {
                //    TimeSpan duration = TimeSpan.FromSeconds(songs[i].Length);
                //    Console.WriteLine($"{songs[i].Title}{songs[i].ArtistName}:{duration.Minutes:D1}:{duration.Seconds:D2}");
                //}
            }
    }
}
