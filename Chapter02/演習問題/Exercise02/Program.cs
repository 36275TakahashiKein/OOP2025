using DistanceConverter;
using System;
using System.Diagnostics.Metrics;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Console.Write("はじめ:");
            int start = int.Parse(Console.ReadLine());
            Console.Write("おわり:");
            int end = int.Parse(Console.ReadLine());
            PrintInchToMeterList(start, end);
            PrintMeterToInchlist(start, end);
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
