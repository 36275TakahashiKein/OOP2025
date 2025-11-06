using Section01;
using System.Diagnostics;
namespace Section05 {
    internal class Program {
        static void Main(string[] args) {
            Code14_20.Run2();
            /*Console.WriteLine("並列処理あり");
            Parallel.For(0,5,i => {
                Console.WriteLine($"処理{i}開始");
                Thread.Sleep(1000);
                Console.WriteLine($"処理{i}終了");
            
            });

            Console.WriteLine("並列処理なし");
            for (int i = 0; i < 5; i++) {
                Console.WriteLine($"処理{i}開始");
                Thread.Sleep(1000);
                Console.WriteLine($"処理{i}終了");
            }*/
        }

        public class Code14_20 {

            public static async Task Run() {
                var sw = Stopwatch.StartNew();
                var task1 = Task.Run(() => Get5000thPrime());
                var task2 = Task.Run(() => Get6000thPrime());
                var prime1 = await task1;
                var prime2 = await task2;
                sw.Stop();
                Console.WriteLine(prime1);
                Console.WriteLine(prime2);
                Console.WriteLine($"実行時間: {sw.ElapsedMilliseconds}ミリ秒");
            }

            public static void Run2() {
                var sw = Stopwatch.StartNew();
                var prime1 = Get5000thPrime();
                var prime2 = Get6000thPrime();
                sw.Stop();
                Console.WriteLine(prime1);
                Console.WriteLine(prime2);
                Console.WriteLine($"実行時間: {sw.ElapsedMilliseconds}ミリ秒");
            }
            // 5000番目の素数を求める
            private static int Get5000thPrime() {
                return GetPrimes().Skip(4999).First();
            }

            // 6000番目の素数を求める
            private static int Get6000thPrime() {
                return GetPrimes().Skip(5999).First();
            }

            // 上記2つのメソッドから呼び出される下位メソッド
            // あえて効率の悪いアルゴリズムで記述している
            public static IEnumerable<int> GetPrimes() {
                for (int i = 2; i < int.MaxValue; i++) {
                    bool isPrime = true;
                    for (int j = 2; j < i; j++) {
                        if (i % j == 0) {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime)
                        yield return i;
                }
            }
        }

    }
}

