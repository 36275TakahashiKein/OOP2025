using System.Diagnostics;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        /*private void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            DoLongTimeWork();
            toolStripStatusLabel1.Text = "�I��";
        }*/

        /*private async void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            await Task.Run(() => DoLongTimeWork());
            toolStripStatusLabel1.Text = $"�I��";
        }*/

        /*private async void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await Task.Run(() => DoLongTimeWork());
            toolStripStatusLabel1.Text = $"{elapsed}�~���b";
        }*/

        private async void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await DoLongTimeWorkWorkAsync(4000);
            toolStripStatusLabel1.Text = $"{elapsed}�~���b";
        }

        private async Task<long> DoLongTimeWorkWorkAsync(int milliseconds) {
            var sw = Stopwatch.StartNew();
            await Task.Run(() => {
                System.Threading.Thread.Sleep(milliseconds);
            });
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        //�񓯊����\�b�h
        private async Task DoLongTimeWork() {
            await Task.Run(() => {
                System.Threading.Thread.Sleep(5000);
            });
        }
    }
}
