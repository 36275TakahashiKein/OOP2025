using DistanceConverter;
using System;
using System.Diagnostics.Metrics;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("変換前の値（ヤード）：");
            int yard = int.Parse(Console.ReadLine());
            PrintYardToMeterList(yard);
        }

        //ヤードからメートルへと対応表を出力。
        static void PrintYardToMeterList(int yard) {
            double meter = YardConverter.ToYard(yard);
            Console.WriteLine($"{yard}yd ={meter: 0.0000}m");
        }
    }
}
