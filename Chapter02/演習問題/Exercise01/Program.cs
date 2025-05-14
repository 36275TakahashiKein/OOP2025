using System.Reflection;

namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {

            //Listの作成
            List<(string Title, string ArtistName, int Length)> songs = new List<(string, string, int)> { };

            Console.WriteLine("****曲の登録****");
            while (true) {

                //曲のタイトルを入力させる
                Console.Write("曲名：");
                string title = Console.ReadLine();

                //入力終了の場合
                if (title.Equals("end",StringComparison.OrdinalIgnoreCase)) {
                    break;
                }

                //アーティスト名を入力させる。
                Console.Write("アーティスト名：");
                string artistName = Console.ReadLine();

                //演奏時間を入力させる
                Console.Write("演奏時間(秒)：");
                int length = int.Parse(Console.ReadLine());

                //Song song = new Song(title,artistName,length);
                Song song = new Song() {
                    Title = title,
                    ArtistName = artistName,
                    Length = length
                };

                //Listに格納
                songs.Add((title, artistName, length));
            }
            //繰り返し終了

            //出力する
            printSongs(songs);
        }


        private static void printSongs(List<(string Title, string ArtistName, int Length)> songs) {
            foreach (var song in songs) {
                var timespan = TimeSpan.FromSeconds(song.Length);
                Console.WriteLine($"{song.Title}, {song.ArtistName}, {timespan.Minutes:D1}:{timespan.Seconds:D2}");
            }
        }

        //2.1.4
        //private static void printSongs(Song[] songs) {

        //    //TimeSpan構造体を使った場合
        //    foreach (var song in songs) {
        //        var timespan = TimeSpan.FromSeconds(song.Length);
        //        Console.WriteLine($"{song.Title},{song.ArtistName},{timespan.Minutes}:{timespan.Seconds}");
        //    }

        //foreach (var song in songs) {
        //    Console.WriteLine(@"{0},{1} {2:m\:ss}",
        //    song.Title, song.ArtistName, TimeSpan.FromSeconds(song.Length));
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

