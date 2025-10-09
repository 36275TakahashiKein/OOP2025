﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    class DistanceUnit {
        public required string Name { get; set; }
        public double Coefficient { get; set; }
        public override string ToString() {
            return Name;
        }
    }
}
