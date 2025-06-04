
using System.Diagnostics.Tracing;
using System.Text;

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

            Console.WriteLine("6.3.99");
            Exercise6(text);
            #endregion

        }

        private static void Exercise1(string text) {
            var spaces = text.Count(c => c == ' ');
            //var spaces = text.Count(char.IsWhiteSpace);
            Console.WriteLine("空白数:{0}", spaces);
            //string[] word = text.Split();
            //Console.Write("空白数：");
            //Console.WriteLine(word.Length - 1);
        }


        private static void Exercise2(string text) {
            Console.WriteLine(text.Replace("big", "small"));
        }

        private static void Exercise3(string text) {
            var array = text.Split(' ');
            //StringBuilderを利用
            var sb = new StringBuilder();
            foreach (var word in array) {
                sb.Append(word);
                sb.Append(' ');
            }

            var tex = sb.ToString().Trim();
            Console.WriteLine(tex + '.');
        }

        private static void Exercise4(string text) {
            var count = text.Split(' ').Length;
            Console.WriteLine("単語数:{0}", count);
        }

        private static void Exercise5(string text) {
            var words = text.Split(' ').Where(s => s.Length <= 4);
            foreach (var word in words)
                Console.WriteLine(word);
        }

        private static void Exercise6(string text) {
            var a = "abcdefghijklmnopqrstuvwxyz";
            var lowText = text.ToLower();
            var b = new int[a.Length];
            var count = 0;

            for (int i = 0; i < a.Length; i++) {
                count = 0;
                for (int x = 0; x < lowText.Length; x++) {
                    if (lowText[x] == a[i])
                        count = count + 1;
                }
                b[i] = count;
            }

            for (int i = 0; i < a.Length; i++) {
                Console.WriteLine($"{a[i]}:{b[i]}");
            }

        }
    }
}
