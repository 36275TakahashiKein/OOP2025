﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public static class InchConverter {
       
        //定数
        private const double ratio = 0.0254;

        //メートルからインチを求める
        public static double FromMeter(double meter) {
            return meter / ratio;
        }

        //インチからメートルを求める
        public static double ToInch(double inch) {
            return inch * ratio;
        }

    }
}
