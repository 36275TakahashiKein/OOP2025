using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    internal class LineToHalfNumberService : ITextFileService {
        private static Dictionary<char, char> _dictionary =
            new Dictionary<char, char>(){
            {'０','0'},{'１','1'},{'２','2'},{'３','3'},{'４','4'} ,
           {'５','5'},{'６','6'},{'７','7'},{'８','8'},{'９','9'}
            };
    private int _count;
    public void Initialize(string fname) {
        _count = 0;
    }

    public void Execute(string line) {
            var s = Regex.Replace(line,"[０-９]", c=> _dictionary[c.Value[0]].ToString());
            Console.WriteLine(s);
        /*模範①
         * string result = new string(
            line.Select(c => ('０' <= c && c <= '９') ? (char)(c - '０' + '0') : c).ToArray()
            );
        Console.WriteLine(result);*/
        /*_count++;
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
        }*/
    }

    public void Terminate() { }
}
}
