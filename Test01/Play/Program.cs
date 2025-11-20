using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Play {
    internal class Program {
        private static string GetWeatherDescription(int weatherCode) {
            switch (weatherCode) {
                case 1: return "晴れ";
                case 2: return "曇り";
                case 3: return "小雨";
                case 4: return "大雨";
                case 5: return "雷";
                case 6: return "雪";
                case 7: return "霧";
                default: return "不明な天気";
            }
        }

        // 座標から住所を取得するメソッド
        private static async Task<string> GetLocationName(double latitude, double longitude) {
            string url = $"https://nominatim.openstreetmap.org/reverse?lat={latitude}&lon={longitude}&format=json&accept-language=ja";

            using (HttpClient client = new HttpClient()) {
                client.DefaultRequestHeaders.Add("User-Agent", "CSharpApp"); // NominatimはUser-Agent必須
                var response = await client.GetStringAsync(url);
                dynamic locationData = JsonConvert.DeserializeObject(response);

                // display_name に住所が入っている
                return locationData.display_name;
            }
        }

        private static async Task GetWeatherData(double latitude, double longitude) {
            string apiUrl =
                $"https://api.open-meteo.com/v1/jma?latitude={latitude}&longitude={longitude}" +
                $"&current=temperature_2m,weather_code,wind_speed_10m" +
                $"&hourly=temperature_2m,precipitation" +
                $"&timezone=Asia/Tokyo" +
                $"&past_days=2" +
                $"&forecast_days=3";

            using (HttpClient client = new HttpClient()) {
                try {
                    var response = await client.GetStringAsync(apiUrl);
                    dynamic weatherData = JsonConvert.DeserializeObject(response);

                    // 座標から住所を取得
                    string locationName = await GetLocationName(latitude, longitude);

                    Console.WriteLine($"場所: {locationName}\n");

                    // 現在の天気データ
                    Console.WriteLine("現在の天気情報:");
                    Console.WriteLine($"時間: {weatherData.current.time}");
                    Console.WriteLine($"気温: {weatherData.current.temperature_2m}°C");
                    Console.WriteLine($"天気: {GetWeatherDescription((int)weatherData.current.weather_code)}");
                    Console.WriteLine($"風速: {weatherData.current.wind_speed_10m} km/h");

                    // 時間ごとの天気データ
                    Console.WriteLine("\n時間ごとの天気データ:");
                    for (int i = 0; i < weatherData.hourly.time.Count; i++) {
                        string time = weatherData.hourly.time[i];
                        double temperature = weatherData.hourly.temperature_2m[i];
                        double precipitation = weatherData.hourly.precipitation[i];

                        Console.WriteLine($"{time}: 気温 {temperature}°C, 降水量 {precipitation}mm");
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine($"エラー: {ex.Message}");
                }
            }
        }

        private static async Task Main(string[] args) {
            double latitude = 36.634282;   // 札幌の緯度
            double longitude = 138.520597; // 札幌の経度

            await GetWeatherData(latitude, longitude);
        }
    }
}
