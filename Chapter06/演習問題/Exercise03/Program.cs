﻿
namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            #region
            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);
            #endregion

        }

        private static void Exercise1(string text) {
            string[] word = text.Split();
            Console.Write("空白数：");
            Console.WriteLine(word.Length - 1);
            }
   

        private static void Exercise2(string text) {
            Console.WriteLine(text.Replace("big", "small")); 
        }

        private static void Exercise3(string text) {
            
        }

        private static void Exercise4(string text) {
            string[] word = text.Split();
            Console.WriteLine(word.Length);
        }

        private static void Exercise5(string text) {
           
            
        }
    }
}
