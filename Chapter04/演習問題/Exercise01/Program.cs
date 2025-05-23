
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
                "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
                "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);
        }

        //foreach文
        private static void Exercise1(List<string> langs) {
            foreach (var item in langs) {
                if (item.Contains('S')) {
                    Console.WriteLine(item);
                }
            }

            //for文
            for (int i = 0; i < langs.Count; i++) {
                Console.WriteLine(langs[i]);
                if (langs[i].Contains('S'))
                    Console.WriteLine(langs[i]);
            }

            //while文
            int index = 0;
            while(index < langs.Count) {
                if (langs[index].Contains('S'))
                    Console.WriteLine(langs[index]);
                index++;
            }

        }


        private static void Exercise2(List<string> langs) {
            Console.WriteLine();
            var result = langs.Where(s => s.Contains('S'));
            foreach (var lang in result) {
                Console.WriteLine(lang);
            }
        }

        private static void Exercise3(List<string> langs) {
            throw new NotImplementedException();
        }
    }
}
