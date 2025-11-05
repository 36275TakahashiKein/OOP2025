using System.Diagnostics;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Exercise01_Forms {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) {
            // 非同期でファイルを読み込む
            label1.Text = ""; // 最初にラベルをクリア
            await Do(); // 非同期でファイル読み込みタスク実行
            label1.Text = "終了"; // ファイル読み込み後にラベルを更新
        }

        private async Task Do() {
            // 非同期でファイルを読み込む
            using (StreamReader reader = new StreamReader(@"C:\Users\infosys\source\repos\OOP2025\Chapter14\演習問題\Exercise01_Forms\走れメロス.txt")) {
                string line;
                // 非同期で1行ずつ読み込む
                while ((line = await reader.ReadLineAsync()) != null) {
                    // ここで TextBox の操作は UI スレッドで行われる
                    // 直接 textBox1.AppendText() を使える
                    textBox1.AppendText(line + Environment.NewLine);
                    await Task.Yield();  // UI スレッドに制御を戻す
                }
            }
        }

        static async Task ReadCharacters() {
            String result;
            using (StreamReader reader = File.OpenText("走れメロス.txt")) {
                /*toolStripStatusLabel1.Text = $"";
                result = await reader.ReadLineAsync();
                toolStripStatusLabel1.Text =  result;*/
            }

            /* toolStripStatusLabel1.Text = "";
             var elapsed = await Task.Run(() => DoLongTimeWork());
             toolStripStatusLabel1.Text = $"{elapsed}";*/
        }



        static async Task ReadAndDisplayFilesAsync() {
            String filename = "走れメロス.txt";
            Char[] buffer;

            using (var sr = new StreamReader(filename)) {
                buffer = new Char[(int)sr.BaseStream.Length];
                await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
            }

            Console.WriteLine(new String(buffer));
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        /*private async void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await Task.Run(() => DoLongTimeWork());
            toolStripStatusLabel1.Text = $"{elapsed}ミリ秒";
        }*/

    }
}
