using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TenkiApp {
    public partial class MainWindow : Window {
        private const string ApiUrl = "https://api.open-meteo.com/v1/forecast";

        public MainWindow() {
            InitializeComponent();
        }

        // 結果を表示
        private async void OnGetWeatherButtonClick(object sender, RoutedEventArgs e) {
            try {
                // 入力値を取得
                string latitude = LatitudeTextBox.Text;
                string longitude = LongitudeTextBox.Text;

                // 入力のバリデーション
                if (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude)) {
                    MessageBox.Show("緯度と経度の両方を入力してください。");
                    return;
                }

                if (!IsValidLatitude(latitude) || !IsValidLongitude(longitude)) {
                    MessageBox.Show("無効な緯度または経度です。");
                    return;
                }

                // 天気情報を取得
                var weatherData = await GetWeatherDataAsync(latitude, longitude);

                if (weatherData != null) {
                    // 結果を表示
                    WeatherResult.Text = $"現在の温度: {weatherData.CurrentWeather.Temperature}°C\n" +
                                         $"風速: {weatherData.CurrentWeather.Windspeed} m/s";

                    // 天気アイコンを設定
                    SetWeatherIcon(weatherData.CurrentWeather.WeatherCode);

                    // 温度に応じて色分け
                    SetTemperatureColor(weatherData.CurrentWeather.Temperature);
                } else {
                    WeatherResult.Text = "天気データの取得に失敗しました。";
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"エラー: {ex.Message}");
            }
        }

        // 天気データを取得
        private async Task<WeatherResponse> GetWeatherDataAsync(string latitude, string longitude) {
            using (HttpClient client = new HttpClient()) {
                try {
                    string requestUrl = $"{ApiUrl}?latitude={latitude}&longitude={longitude}&current_weather=true";
                    string response = await client.GetStringAsync(requestUrl);
                    var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
                    return weatherResponse;
                }
                catch {
                    return null;
                }
            }
        }

        // 天気アイコンを設定
        private void SetWeatherIcon(int weatherCode) {
            string iconPath = weatherCode switch {
                1 => "Assets/sunny.png",  // 晴れ
                2 => "Assets/cloudy.png", // 曇り
                3 => "Assets/rainy.png",  // 雨
                _ => "Assets/default.png" // デフォルト
            };

            WeatherIcon.Source = new BitmapImage(new Uri(iconPath, UriKind.Relative));
        }

        // 温度に応じて文字色を変更
        private void SetTemperatureColor(float temperature) {
            if (temperature > 25) {
                WeatherResult.Foreground = Brushes.Red;
            } else if (temperature < 10) {
                WeatherResult.Foreground = Brushes.Blue;
            } else {
                WeatherResult.Foreground = Brushes.Black;
            }
        }

        // 緯度の検証
        private bool IsValidLatitude(string latitude) {
            return double.TryParse(latitude, out double lat) && lat >= -90 && lat <= 90;
        }

        // 経度の検証
        private bool IsValidLongitude(string longitude) {
            return double.TryParse(longitude, out double lon) && lon >= -180 && lon <= 180;
        }

        // 緯度テキスト変更時
        private void LatitudeTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            LatitudePlaceholder.Visibility = string.IsNullOrEmpty(LatitudeTextBox.Text) ? Visibility.Visible : Visibility.Hidden;
        }

        // 経度テキスト変更時
        private void LongitudeTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            LongitudePlaceholder.Visibility = string.IsNullOrEmpty(LongitudeTextBox.Text) ? Visibility.Visible : Visibility.Hidden;
        }
    }

    // 天気情報のレスポンスデータ
    public class WeatherResponse {
        [JsonProperty("current_weather")]
        public CurrentWeather CurrentWeather { get; set; }
    }

    public class CurrentWeather {
        [JsonProperty("temperature")]
        public float Temperature { get; set; }

        [JsonProperty("windspeed")]
        public float Windspeed { get; set; }

        [JsonProperty("weathercode")]
        public int WeatherCode { get; set; }
    }

}
