using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;

namespace RssReader {
    public partial class Form1 : Form {

        private Dictionary<string, string> rssUrlDict = new Dictionary<string, string> {
            { "��v","https://news.yahoo.co.jp/rss/topics/top-picks.xml"},
            { "����","https://news.yahoo.co.jp/rss/topics/domestic.xml"}
        };

        private List<ItemData> items;
        public Form1() {
            InitializeComponent();
            //�R���{�{�b�N�X����I��
            cbUrl.DataSource = rssUrlDict.Select(x => x.Key).ToList();
            cbUrl.SelectedIndex = -1;
        }


        //�擾�{�^��
        private async void btRssGet_Click(object sender, EventArgs e) {

            using (var hc = new HttpClient()) {

                string xml = await hc.GetStringAsync(getRssUrl(cbUrl.Text));
                XDocument xdoc = XDocument.Parse(xml);
                //XDocument xdoc = XDocument.Parse(await hc.GetStreamAsync(tbUrl.Text));

                //RSS����͂��ĕK�v�ȗv�f���擾
                items = xdoc.Root.Descendants("item")
                    .Select(x =>
                        new ItemData {
                            Title = (string?)x.Element("title"),
                            Link = (string?)x.Element("link"),
                        }).ToList();


                //���X�g�{�b�N�X�փ^�C�g���\���i�����j
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


        //�^�C�g����I���i�N���b�N�j�����Ƃ��ɌĂ΂��C�x���g�n���h��
        private void lbTitles_Click(object sender, EventArgs e) {
            wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
            tbSource.Text = items[lbTitles.SelectedIndex].Link;

        }


        //���C�ɓ���ǉ�
        private void btFavorite_Click(object sender, EventArgs e) {
            rssUrlDict.Add("a", tbSource.Text);
            cbUrl.DataSource = rssUrlDict.Select(x => x.Key).ToList();

        }



        //�߂�
        private void btGoBack_Click(object sender, EventArgs e) {
            wvRssLink.GoBack();
        }

        //�i��
        private void btGoForward_Click(object sender, EventArgs e) {
            wvRssLink.GoForward();
        }

        private void webView21_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e) {
            btGoBack.Enabled = wvRssLink.CanGoBack;
            btGoForward.Enabled = wvRssLink.CanGoForward;
        } //�߂�E�i�ރ{�^������;


        private void button1_Click(object sender, EventArgs e) {

        }

        
    }
}
