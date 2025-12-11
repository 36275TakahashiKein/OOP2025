using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;
using System.Windows;

namespace UI00
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<LogItem> Logs { get; set; }
        public SeriesCollection PieSeries { get; set; }
        public SeriesCollection TimeSeries { get; set; }

        public ObservableCollection<StatusItem> StatusTable { get; set; }

        public string[] TimeLabels { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // ダミーログ
            Logs = new ObservableCollection<LogItem>
            {
                new LogItem { Time="11:20:01", Attack="SQLi", IP="192.168.1.10" },
                new LogItem { Time="11:21:10", Attack="XSS", IP="10.0.0.22" },
                new LogItem { Time="11:23:55", Attack="PortScan", IP="172.16.0.1" },
            };
            LogGrid.ItemsSource = Logs;

            // 円グラフ
            PieSeries = new SeriesCollection
            {
                new PieSeries{ Title="Safe", Values=new ChartValues<int>{69}, Fill = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#00FFB0") },
                new PieSeries{ Title="Warning", Values=new ChartValues<int>{19}, Fill = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#00C8FF") },
                new PieSeries{ Title="Alert", Values=new ChartValues<int>{13}, Fill = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#FF8A2B") }
            };

            // ステータス表
            StatusTable = new ObservableCollection<StatusItem>
            {
                new StatusItem("Safe", 69),
                new StatusItem("Warning", 19),
                new StatusItem("Alert", 13)
            };

            // 時系列グラフ
            TimeLabels = new[] { "11:00", "11:10", "11:20", "11:30", "11:40" };
            TimeSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Title="Events",
                    Values = new ChartValues<int>{2,5,7,4,6},
                    StrokeThickness = 3,
                    Stroke = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#00C8FF"),
                    Fill = System.Windows.Media.Brushes.Transparent
                }
            };

            DataContext = this;
        }
    }

    public class LogItem
    {
        public string Time { get; set; }
        public string Attack { get; set; }
        public string IP { get; set; }
    }

    public class StatusItem
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public StatusItem(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }
}
