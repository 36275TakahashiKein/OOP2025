using System.Text.RegularExpressions;
using System;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {

            var lines = File.ReadAllLines("sample.txt");

            var newlines = lines.Select(s => Regex.Replace(s, @"\bversion\s*=\s*""v4\.0""", @"version=""v5.0""", RegexOptions.IgnoreCase));

            File.WriteAllLines("sampleChange.txt", newlines);

            //これ以降は確認用
            var text = File.ReadAllText("sampleChange.txt");
            Console.WriteLine(text);
        }
    }
}
