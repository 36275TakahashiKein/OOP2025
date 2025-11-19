using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    internal class LineOutputService : ITextFileService {
        //P362 問題15.3
        private int _count;
        public void Initialize(string fname) {
            _count = 0;
        }

        public void Execute(string line) {
            _count++;
            if (_count < 20) {
                Console.WriteLine(line);
            }
        }
      
        public void Terminate() { }
    }
}
