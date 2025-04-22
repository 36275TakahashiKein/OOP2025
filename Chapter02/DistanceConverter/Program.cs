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

       

        //フィートからメートルへと対応表を出力。
        static void PrintFeelToMeterList(int start, int end) {
            FeetConverter converter = new FeetConverter();
            for (int feet = start; feet <= end; feet++) {
                double meter = converter.ToMeter(feet);
                Console.WriteLine($"{feet}ft ={meter: 0.0000}m");
            }
        }

        //メートルからフィートへと対応表を出力
        static void PrintMeterToFeelList(int start, int end) {
            FeetConverter converter = new FeetConverter();
            for (int meter = start; meter <= end; meter++) {
                double feet = converter.FromMeter(meter);
                Console.WriteLine($"{meter}ft ={feet: 0.0000}m");
            }
        }

    }
}


