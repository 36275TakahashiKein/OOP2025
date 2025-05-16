﻿namespace Section01 {
    internal class Program {

        static void Main(string[] args) {

            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4 };

            Console.WriteLine(Count(numbers, n => n >= 5 && n <10));

        }


        static int Count(int[] numbers, Func<int,bool> judge) {
            var count = 0;

            foreach (var n in numbers) {
                //引数で受け取ったメソッドを呼び出す
                if (judge(n) == true) {
                    count++;
                    Console.WriteLine(n);
                }

            }
            return count;
        }

    }
}
