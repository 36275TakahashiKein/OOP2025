using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test04 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   /* public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }*/
    public class CurrentUnits {
        public string Temperature_2m { get; set; }
        public string Relative_Humidity_2m { get; set; }
        public string Precipitation { get; set; }
    }

    public class CurrentWeather {
        public string Time { get; set; }
        public double Temperature_2m { get; set; }
        public double Relative_Humidity_2m { get; set; }
        public double Precipitation { get; set; }
        public int Weather_Code { get; set; } // wmo code (optional)
    }

    public class OpenMeteoResponse {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Timezone { get; set; }
        public CurrentUnits Current_Units { get; set; }
        public CurrentWeather Current { get; set; }
    }
    public class WeatherService {
        private readonly HttpClient _http = new HttpClient();

        public async Task<OpenMeteoResponse> GetCurrentAsync(double lat, double lon, string timezone = "Asia/Tokyo") {
            // weather_code を含めれば画像切替が楽になります
            var url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}" +
                      $"&current=temperature_2m,relative_humidity_2m,precipitation,weather_code" +
                      $"&timezone={Uri.EscapeDataString(timezone)}";
            var json = await _http.GetStringAsync(url);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<OpenMeteoResponse>(json, options)!;
        }
    }

    // 地名から緯度経度（例: Open-Meteo の Geocoding API を利用）
    public class GeoService {
        private readonly HttpClient _http = new HttpClient();
        public async Task<(double lat, double lon)?> GeocodeAsync(string name) {
            var url = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(name)}&count=1&language=ja";
            var json = await _http.GetStringAsync(url);
            using var doc = JsonDocument.Parse(json);
            var results = doc.RootElement.GetProperty("results");
            if (results.GetArrayLength() == 0) return null;
            var first = results[0];
            return (first.GetProperty("latitude").GetDouble(), first.GetProperty("longitude").GetDouble());
        }
    }
    public class MainViewModel : INotifyPropertyChanged {
        private readonly WeatherService _weather = new WeatherService();
        private readonly GeoService _geo = new GeoService();

        private string _placeQuery;
        public string PlaceQuery {
            get => _placeQuery;
            set { _placeQuery = value; OnPropertyChanged(nameof(PlaceQuery)); }
        }

        private string _status;
        public string Status {
            get => _status;
            set { _status = value; OnPropertyChanged(nameof(Status)); }
        }

        private double? _temperature;
        public double? Temperature { get => _temperature; set { _temperature = value; OnPropertyChanged(nameof(Temperature)); } }
        private double? _humidity;
        public double? Humidity { get => _humidity; set { _humidity = value; OnPropertyChanged(nameof(Humidity)); } }
        private double? _precip;
        public double? Precipitation { get => _precip; set { _precip = value; OnPropertyChanged(nameof(Precipitation)); } }
        private string _weatherImage;
        public string WeatherImage { get => _weatherImage; set { _weatherImage = value; OnPropertyChanged(nameof(WeatherImage)); } }

        public async Task GetByLatLonAsync(double lat, double lon) {
            try {
                Status = "取得中…";
                var resp = await _weather.GetCurrentAsync(lat, lon);
                Temperature = resp.Current.Temperature_2m;
                Humidity = resp.Current.Relative_Humidity_2m;
                Precipitation = resp.Current.Precipitation;
                WeatherImage = WeatherCodeToImage(resp.Current.Weather_Code);
                Status = $"更新: {resp.Current.Time}";
            }
            catch (Exception ex) {
                Status = $"エラー: {ex.Message}";
            }
        }

        public async Task GetByPlaceAsync() {
            if (string.IsNullOrWhiteSpace(PlaceQuery)) { Status = "地名を入力してください"; return; }
            var geo = await _geo.GeocodeAsync(PlaceQuery);
            if (geo is null) { Status = "地名が見つかりません"; return; }
            await GetByLatLonAsync(geo.Value.lat, geo.Value.lon);
        }

        // 現在地取得は OS API または IP ベースの推定サービスを呼ぶ想定
        public async Task GetByCurrentLocationAsync(double lat, double lon) => await GetByLatLonAsync(lat, lon);

        private string WeatherCodeToImage(int code) {
            // WMO weather codes の簡易マッピング例
            if (code == 0) return "Images/sunny.png";
            if (code is >= 1 and <= 3) return "Images/cloudy.png";
            if (code is 45 or 48) return "Images/fog.png";
            if (code is 51 or 53 or 55 or 61 or 63 or 65 or 80 or 81 or 82) return "Images/rain.png";
            if (code is 71 or 73 or 75 or 85 or 86) return "Images/snow.png";
            return "Images/unknown.png";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public partial class MainWindow : Window {
        public MainViewModel VM { get; } = new MainViewModel();
        public MainWindow() {
            InitializeComponent();
            DataContext = VM;
        }

        private async void SearchPlace_Click(object sender, RoutedEventArgs e) {
            await VM.GetByPlaceAsync();
        }

        private async void CurrentLocation_Click(object sender, RoutedEventArgs e) {
            // 例: 仮の座標（群馬県太田市周辺）
            await VM.GetByCurrentLocationAsync(36.29, 139.38);
        }

        private async void LatLon_Click(object sender, RoutedEventArgs e) {
            // ダイアログや別入力から数値を取得する設計に
            double lat = 36.29, lon = 139.38;
            await VM.GetByLatLonAsync(lat, lon);
        }
    }



}