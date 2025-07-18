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
                //XDocument xdoc = XDocument.Load(url);//RSS�̎擾


                //RSS����͂��ĕK�v�ȗv�f���擾
                items = xdoc.Root.Descendants("item")
                    .Select(x =>
                        new ItemData {
                            Title = (string?)x.Element("title"),
                            Link = (string?)x.Element("link"),
                        }).ToList();
                


                //���X�g�{�b�N�X�փ^�C�g���\��
                //lbTitles.DataSource = items;
                //lbTitles.DisplayMember = "Title";

                //���X�g�{�b�N�X�փ^�C�g���\���i�����j
                lbTitles.Items.Clear();
                items.ForEach(item => lbTitles.Items.Add(item.Title));
                //foreach (var item in items) {
                //    lbTitles.Items.Add(item.Title);
                //}


            }
        }


        //�^�C�g����I���i�N���b�N�j�����Ƃ��ɌĂ΂��C�x���g�n���h��
        private void lbTitles_Click(object sender, EventArgs e) {
             webView21.Source = new Uri(items[lbTitles.SelectedIndex].Link);

        }
    }
}
