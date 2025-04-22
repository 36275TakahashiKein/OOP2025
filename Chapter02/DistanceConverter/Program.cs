using System.Diagnostics.Metrics;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;

namespace DistanceConverter {
    internal class Program {
        //あああ
        static void Main(string[] args) {

            int start = int.Parse(args[1]);
            int end = int.Parse(args[2]);

            if (args[0] == "-tom") {
                PrintFeelToMeterList(start, end);
            } else {
                PrintMeterToFeelList(start, end);
            }
        }

        static double FeetToMeter(int feet) {
            return feet * 0.3048;
        }

        static double MeterToFeet(int meter) {
            return meter / 0.3048;
        }

        //フィートからメートルへと対応表を出力
        static void PrintFeelToMeterList(int start, int end) {
            for (int feet = start; feet <= end; feet++) {
                double meter = FeetToMeter(feet);
                Console.WriteLine($"{feet}ft ={meter: 0.0000}m");
            }
        }

        //メートルからフィートへと対応表を出力
        static void PrintMeterToFeelList(int start, int end) {
            for (int meter = start; meter <= end; meter++) {
                double feet = MeterToFeet(meter);
                Console.WriteLine($"{meter}ft ={feet: 0.0000}m");
            }
        }

    }
}


