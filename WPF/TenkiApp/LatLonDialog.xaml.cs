using System.Windows;

namespace TenkiApp {
    public partial class LatLonDialog : Window {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public LatLonDialog() {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e) {
            if (double.TryParse(LatitudeBox.Text, out double lat) &&
                double.TryParse(LongitudeBox.Text, out double lon)) {
                Latitude = lat;
                Longitude = lon;
                DialogResult = true; // OKを返す
            } else {
                MessageBox.Show("緯度と経度は数値で入力してください。", "入力エラー",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) {
            DialogResult = false; // キャンセルを返す
        }
    }
}
