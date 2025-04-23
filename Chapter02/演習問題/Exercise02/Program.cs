using DistanceConverter;
using System;
using System.Diagnostics.Metrics;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("１か２入力。（１＝ヤード→メートル、２＝メートル→ヤード）");
            int start = int.Parse(Console.ReadLine());
            if (start == 1) {
                Console.Write("変換前の値（ヤード）：");
                int yard = int.Parse(Console.ReadLine());
                PrintYardToMeterList(yard);
            } else if (start == 2) {
                Console.Write("変換前の値（メートル）：");
                int meter = int.Parse(Console.ReadLine());
                PrintMeterToYardList(meter);
            } else {
                Console.WriteLine("Error");
            }
        }

        //ヤードからメートルへと対応表を出力。
        static void PrintYardToMeterList(int yard) {
            double meter = YardConverter.ToYard(yard);
            Console.WriteLine($"変換後（メートル）： + {meter: 0.0000}");
        }


        //メートルからヤードへと対応表を出力。
        static void PrintMeterToYardList(int meter) {
            double yard = YardConverter.FromMeter(meter);
            Console.WriteLine($"変換後（ヤード）： + {yard: 0.0000}");
        }
    }
}
