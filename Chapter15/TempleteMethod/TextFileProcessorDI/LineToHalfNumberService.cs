using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    internal class LineToHalfNumberService : ITextFileService {
        private int _count;
        public void Initialize(string fname) {
            _count = 0;
        }

        public void Execute(string line) {
            _count++;
            if (_count < 20) {
                string converted = line
                    .Replace('０', '0')
                    .Replace('１', '1')
                    .Replace('２', '2')
                    .Replace('３', '3')
                    .Replace('４', '4')
                    .Replace('５', '5')
                    .Replace('６', '6')
                    .Replace('７', '7')
                    .Replace('８', '8')
                    .Replace('９', '9');
                Console.WriteLine(converted);
            }
        }

        public void Terminate() { }
    }
}
