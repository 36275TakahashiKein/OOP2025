namespace KeyTest
{
    public partial class KeyTest : Form
    {
        String consoleText = ""; //テキストボックス｢console｣の文字列編集用の変数
        String key = ""; //押されたキーを保存する変数
        String preKey = ""; //押されっぱなしか判定するため、一つ前のキーを保存する変数
        public KeyTest()
        {
            InitializeComponent();
            consoleText += "接続" + "\r\n";
            console.Text = consoleText;
        }

        private void KeyTest_KeyDown(object sender, KeyEventArgs e)
        {
            key = e.KeyData.ToString(); //押されたキーを保存
            key = key.ToLower();
            //｢S｣による離陸
            if (key == "s")
            {
                consoleText += "離陸" + "\r\n";
                console.Text = consoleText;
            }
            //｢S｣による離陸
            if (key == "d")
            {
                consoleText += "静止(ホバリング)" + "\r\n";
                console.Text = consoleText;
                consoleText += "着陸" + "\r\n";
                console.Text = consoleText;
            }
            if (preKey != key)
            {
                switch (key)
                {

                    case "up":
                        consoleText += "前進" + "\r\n";
                        console.Text = consoleText;
                        break;
                    case "down":
                        consoleText += "後進" + "\r\n";
                        console.Text = consoleText;
                        break;
                    case "right":
                        consoleText += "右旋回" + "\r\n";
                        console.Text = consoleText;
                        break;
                    case "left":
                        consoleText += "左旋回" + "\r\n";
                        console.Text = consoleText;
                        break;
                }
                consoleText += key + "\r\n"; ; //押されたキーをconsoleTextに書き出し
                console.Text = consoleText; //consoleTextをconsoleに書き出し
                console.SelectionStart = console.TextLength; //カーソルを最下行へ移動
            }
            else
            {
                console.SelectionStart = console.TextLength; //同じキーが押されっぱなしなら、
                                                             //カーソルを最下行へ移動するだけ
                console.Focus();
            }
            preKey = key; //一つ前のキーとして、保存
            preKey = preKey.ToLower();

        }

        private void KeyTest_KeyUp(object sender, KeyEventArgs e)
        {
            consoleText += "静止(ホバリング)" + "\r\n"; //静止(ホバリング)と表示
            console.Text = consoleText;
            console.SelectionStart = console.TextLength; //カーソルを最下行へ移動
            console.Focus();
            preKey = ""; //次の｢KeyDown｣のため、prekey, keyともに初期化
            key = "";
        }
    }
}
