using System.Globalization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var dateTime = DateTime.Now;
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);

        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            //2024/03/09 19:03
            //string.Formatを使った例
            var str = string.Format($"{dateTime:yyyy/MM/dd HH:mm}");
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            //2024年03月09日 19時03分09秒
            //DateTime.ToStringを使った例
            var str = dateTime.ToString($"{dateTime:yyyy年/MM月/dd日 HH時:mm分ss秒}");
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            //-----模範-----
            var birth = new DateTime(dateTime.Year,dateTime.Month,dateTime.Day);

            var datestr = dateTime.ToString("ggyy", culture);
            var dayOfWeek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);

            var str = string.Format($"{datestr}年{dateTime.Month,2}月{dateTime.Day,2}日({dayOfWeek})");
            Console.WriteLine(str);
            //-----模範-----


            //-----自-----
            //var str = birth.ToString("ggyy年M月d日", culture);
            //var shortDayOfWeek = culture.DateTimeFormat.GetShortestDayName(birth.DayOfWeek);

            ////Console.WriteLine(str + shortDayOfWeek + "曜日");
            //Console.WriteLine(str + birth.ToString("ddd曜日", culture));
            //-----自-----
        }
    }
}
