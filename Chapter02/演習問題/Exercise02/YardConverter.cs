using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02
{
    class YardConverter
    {

        //定数
        private const double ratio = 0.9144;

        //ヤードからメートルを求める
        public static double ToYard(double yard) {
            return yard * ratio;
        }

        //メートルからヤードを求める
        public static double FromMeter(double meter) {
            return meter / ratio;
        }











    }
}
