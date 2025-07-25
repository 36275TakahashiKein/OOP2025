using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;

namespace RssReader {
    public partial class Form1 : Form {

        private Dictionary<string, string> rssUrlDict = new Dictionary<string, string> {
            { "主要","https://news.yahoo.co.jp/rss/topics/top-picks.xml"},
            { "国内","https://news.yahoo.co.jp/rss/topics/domestic.xml"}
        };

        private List<ItemData> items;
        public Form1() {
            InitializeComponent();
            //コンボボックスから選択
            cbUrl.DataSource = rssUrlDict.Select(x => x.Key).ToList();
            cbUrl.SelectedIndex = -1;
        }


        //取得ボタン
        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {

                string xml = await hc.GetStringAsync(getRssUrl(cbUrl.Text));
                XDocument xdoc = XDocument.Parse(xml);
                //XDocument xdoc = XDocument.Parse(await hc.GetStreamAsync(tbUrl.Text));

                //RSSを解析して必要な要素を取得
                items = xdoc.Root.Descendants("item")
                    .Select(x =>
                        new ItemData {
                            Title = (string?)x.Element("title"),
                            Link = (string?)x.Element("link"),
                        }).ToList();


                //リストボックスへタイトル表示（答え）
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title));

            }

        }

        private string? getRssUrl(string str) {
            if (rssUrlDict.ContainsKey(str)) {
                return rssUrlDict[str];
            }
            return str;
        }


        //タイトルを選択（クリック）したときに呼ばれるイベントハンドラ
        private void lbTitles_Click(object sender, EventArgs e) {
            wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
            tbSource.Text = items[lbTitles.SelectedIndex].Link;

        }


        //お気に入り追加
        private void btFavorite_Click(object sender, EventArgs e) {
            rssUrlDict.Add("a", tbSource.Text);
            cbUrl.DataSource = rssUrlDict.Select(x => x.Key).ToList();

        }



        //戻る
        private void btGoBack_Click(object sender, EventArgs e) {
            wvRssLink.GoBack();
        }

        //進む
        private void btGoForward_Click(object sender, EventArgs e) {
            wvRssLink.GoForward();
        }

        private void webView21_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            btGoBack.Enabled = wvRssLink.CanGoBack;
            btGoForward.Enabled = wvRssLink.CanGoForward;
        } //戻る・進むボタン完成;


        private void button1_Click(object sender, EventArgs e) {

        }

        
    }
}
