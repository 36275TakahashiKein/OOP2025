﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorChecker {
    public struct myColor {
        public Color Color { get; set; }
        public string Name { get; set; }
        public override string ToString() {
            return base.ToString();
        }
    }
}
