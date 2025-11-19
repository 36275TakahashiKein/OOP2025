namespace TextFileProcessorDI {
    internal class Program {
        static void Main(string[] args) {
            var service = new LineToHalfNumberService();
            var processor = new TextFileProcessor(service);
            Console.Write("パスの入力");

            processor.Run(Console.ReadLine());
            //processor.Run("C:\\Users\\infosys\\source\\repos\\OOP2025\\Chapter13\\Section01\\Library.cs");
        }
    }
}
