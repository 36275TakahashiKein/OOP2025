using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
    internal class LineCounterProcessor : TextProcessor {
        private int _count = 0;
        private string? _lolo;

        protected override void Initialize(string fname) {
            _count = 0;
            Console.WriteLine("任意の文字");
            _lolo = Console.ReadLine();
        }

        protected override void Execute(string line) {

            if (line.Contains(_lolo)) _count++;
        }

        protected override void Terminate() => Console.WriteLine(_lolo + "{0} 行", _count);

    }
}
