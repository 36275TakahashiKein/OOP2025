using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;
        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {
            using (var hc = new HttpClient()) {

                string xml = await hc.GetStringAsync(tbUrl.Text);
                XDocument xdoc = XDocument.Parse(xml);
                //XDocument xdoc = XDocument.Parse(await hc.GetStreamAsync(tbUrl.Text));


                //var url = hc.OpenRead(tbUrl.Text);
                //XDocument xdoc = XDocument.Load(url);//RSSの取得


                //RSSを解析して必要な要素を取得
                items = xdoc.Root.Descendants("item")
                    .Select(x =>
                        new ItemData {
                            Title = (string?)x.Element("title"),
                            Link = (string?)x.Element("link"),
                        }).ToList();
                


                //リストボックスへタイトル表示
                //lbTitles.DataSource = items;
                //lbTitles.DisplayMember = "Title";

                //リストボックスへタイトル表示（答え）
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title));
                //foreach (var item in items) {
                //    lbTitles.Items.Add(item.Title);
                //}


            }
        }


        //タイトルを選択（クリック）したときに呼ばれるイベントハンドラ
        private void lbTitles_Click(object sender, EventArgs e) {
             webView21.Source = new Uri(items[lbTitles.SelectedIndex].Link);

        }
    }
}
