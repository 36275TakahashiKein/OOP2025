using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;

namespace LineCounter {
    internal class LineCounterProcessor : TextProcessor {
        private int _count = 0;
        private string lolo;

        protected override void Initialize(string fname) {
            _count = 0;
            Console.WriteLine("任意の文字");
            lolo = Console.ReadLine();
        }

        protected override void Execute(string line) {

            if (line.Contains(lolo)) _count++;
        }

        protected override void Terminate() => Console.WriteLine("{0} 行", _count);

    }
}
