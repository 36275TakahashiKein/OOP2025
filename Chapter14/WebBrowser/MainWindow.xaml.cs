using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
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
using Microsoft.Web.WebView2.Core;

namespace WebBrowser;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
        /*// WebView2初期化完了イベント追加
        this.WebView.CoreWebView2InitializationCompleted += this.WebView2InitializationCompleted;

        // WebView2初期化完了確認
        this.WebView.EnsureCoreWebView2Async(null);*/

    }

    private void BackButton_Click(object sender, RoutedEventArgs e) {

    }

    private void ForwardButton_Click(object sender, RoutedEventArgs e) {

    }

    private async void GoButton_Click(object sender, RoutedEventArgs e) {
        var bbb = AddressBar.Text;
        if (this.WebView.CoreWebView2 != null) {
            // CoreWebView2が初期化されていれば、Navigateを呼び出す
            this.WebView.CoreWebView2.Navigate($"{bbb}");

            // 遷移完了のイベント追加
            this.WebView.CoreWebView2.NavigationCompleted += this.webView2_NavigationCompleted;
        } else {
            // CoreWebView2が初期化されていない場合、初期化を待つ
            await this.WebView.EnsureCoreWebView2Async(null);
            this.WebView.CoreWebView2.Navigate($"{bbb}");
            this.WebView.CoreWebView2.NavigationCompleted += this.webView2_NavigationCompleted;
        }
    }
    

    private void WebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e) {
        if (e.IsSuccess) {
            // どこぞやのURL
            this.WebView.CoreWebView2.Navigate("https://www.yahoo.co.jp/");

            // 遷移完了のイベント追加
            this.WebView.CoreWebView2.NavigationCompleted += this.webView2_NavigationCompleted;
        } else {
            // エラー処理
        }
    }

    private void webView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e) {
        if (e.IsSuccess) {
            // 実行したいJavaSciprtを記載　※サンプル：name:pppppのタグに"C#"の文字列をセット
            this.WebView.ExecuteScriptAsync("document.getElementsByName('ppppp').item(0).value = 'C#';");
        } else {
            // エラー処理
        }
    }



    /*static async Task Main(string[] args) {
        HttpClient hc = new HttpClient();

        hc.DefaultRequestHeaders.UserAgent.ParseAdd(
            "MyWikipediaClient/1.0 (https://example.com/; contact@example.com)"
            );

        var text = await GetFromWikipediaAsync(hc, "伊勢崎市");
        Console.WriteLine(text);
    }*/

    /*static async Task GetHtmlExample(HttpClient httpClient) {
        var url = "https://www.yahoo.co.jp/";
        var text = await httpClient.GetStreamAsync(url);
        Console.WriteLine(text);
        
    }

    static async Task<string> GetFromWikipediaAsync(HttpClient httpClient, string keyword) {
        // UriBuilderとFormUrlEncodedContentを使い、パラメーター付きのURLを組み立てる
        var builder = new UriBuilder("https://ja.wikipedia.org/w/api.php");
        var content = new FormUrlEncodedContent(new Dictionary<string, string>() {
            ["action"] = "query",
            ["format"] = "json",
            ["prop"] = "extracts",
            ["redirects"] = "1",
            ["explaintext"] = "1",
            ["titles"] = keyword,
        });
        // JsonStringを取得する
        builder.Query = await content.ReadAsStringAsync();
        var jsonString = await httpClient.GetStringAsync(builder.Uri);

        // JsonStringをパースして、コンテンツ文字列を取得する
        return GetContentString(jsonString);
    }

    // JsonStringをパースして、コンテンツ文字列を取得する
    static string GetContentString(string jsonString) {
        var jsonNode = JsonNode.Parse(jsonString)!;
        var node = jsonNode["query"]!["pages"]!;
        var pagesElement = JsonSerializer.Deserialize<JsonElement>(node);
        var name = GetChildPropertyName(pagesElement);
        JsonElement contentElement = pagesElement.GetProperty(name);
        JsonElement extractElement = contentElement.GetProperty("extract");
        return extractElement.GetString() ?? "";
    }

    // element直下のキー名を取得する
    static string GetChildPropertyName(JsonElement element) {
        return element.EnumerateObject().First().Name;
    }*/
}
