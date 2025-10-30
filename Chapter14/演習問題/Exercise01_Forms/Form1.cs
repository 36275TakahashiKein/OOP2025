using System.Diagnostics;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise01_Forms {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            //await ReadCharacters();
        }

        static async Task ReadCharacters() {
            String result;
            using (StreamReader reader = File.OpenText("‘–‚êƒƒƒX.txt")) {
                /*toolStripStatusLabel1.Text = $"";
                result = await reader.ReadLineAsync();
                toolStripStatusLabel1.Text =  result;*/
            }

            /* toolStripStatusLabel1.Text = "";
             var elapsed = await Task.Run(() => DoLongTimeWork());
             toolStripStatusLabel1.Text = $"{elapsed}";*/
        }

        

        static async Task ReadAndDisplayFilesAsync() {
            String filename = "‘–‚êƒƒƒX.txt";
            Char[] buffer;

            using (var sr = new StreamReader(filename)) {
                buffer = new Char[(int)sr.BaseStream.Length];
                await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
            }

            Console.WriteLine(new String(buffer));
        }

        /*private async void button1_Click(object sender, EventArgs e) {
            toolStripStatusLabel1.Text = "";
            var elapsed = await Task.Run(() => DoLongTimeWork());
            toolStripStatusLabel1.Text = $"{elapsed}ƒ~ƒŠ•b";
        }*/

    }
}
