namespace LinqSample {
    internal class Program {
        static void Main(string[] args) {

            //簡単に配列に1～10を入れれる。
            var numbers = Enumerable.Range(1, 10);

            //合計値を出力
            Console.WriteLine(numbers.Sum());

            //偶数の合計値を出力
            Console.WriteLine(numbers.
               Where(numbers => numbers % 2 == 0).Sum());

            //平均値を出力
            Console.WriteLine(numbers.Average());

            foreach (var num in numbers) {
                Console.WriteLine(num);
            }


        }
    }
}
