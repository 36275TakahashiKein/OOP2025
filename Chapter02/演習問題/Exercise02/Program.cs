using DistanceConverter;
using System;
using System.Diagnostics.Metrics;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            //Console.Write("はじめ:");
            //int start = int.Parse(Console.ReadLine());
            //Console.Write("おわり:");
            //int end = int.Parse(Console.ReadLine());
            //PrintInchToMeterList(start, end);
            //PrintMeterToInchlist(start, end);
            Console.Write("変換前の値（ヤード）：");
            int yard = int.Parse(Console.ReadLine());
            PrintYardToMeterList(yard);
            //Console.Write("変換前の値（メートル）：");
            //int meter = int.Parse(Console.ReadLine());
            //PrintMeterToYardlist(meter);
        }

        //ヤードからメートルへと対応表を出力。
        static void PrintYardToMeterList(int yard) {
            double meter = YardConverter.ToYard(yard);
            Console.WriteLine($"{yard}yd ={meter: 0.0000}m");
        }

        //メートルからヤードへと対応表を出力。
        static void PrintMeterToYardlist(int meter) {
            double yard = YardConverter.FromMeter(meter);
            Console.WriteLine($"{meter}m ={yard: 0.0000}yd");
        }

        //インチからメートルへと対応表を出力。
        static void PrintInchToMeterList(int start, int end) {
            for (int inch = start; inch <= end; inch++) {
                double meter = InchConverter.ToInch(inch);
                Console.WriteLine($"{inch}inch ={meter: 0.0000}m");
            }
        }

        //メートルからインチへと対応表を出力。
        static void PrintMeterToInchlist(int start, int end) {
            for (int meter = start; meter <= end; meter++) {
                double inch = InchConverter.FromMeter(meter);
                Console.WriteLine($"{meter}m ={inch: 0.0000}inch");
            }
        }
    }
}
