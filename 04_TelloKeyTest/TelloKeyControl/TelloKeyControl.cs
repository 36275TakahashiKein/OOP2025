using System.Windows.Forms;
using System;
using TelloLib;
using System.Security.Cryptography.Xml;
namespace TelloKeyControl
{
    public partial class TelloKeyControl : Form
    {
        String consoleText = ""; //テキストボックス｢console｣の文字列編集用の変数
        String key = ""; //押されたキーを保存する変数
        String preKey = ""; //押されっぱなしか判定するため、一つ前のキーを保存する変数
        public TelloKeyControl()// コンストラクタ
        {
            InitializeComponent();
            Tello.onConnection += Tello_onConnection; //接続時などのメソッドを実行
            Tello.onUpdate += Tello_onUpdate;
            Tello.onVideoData += Tello_onVideoData;
            Tello.startConnecting(); // 接続開始
            if (Tello.connected) /* 接続できたら、｢静止｣の指示を送る */
            /* → Telloに残っている前の指示を初期化 */
            {
                Tello.controllerState.setAxis(0, 0, 0, 0); //静止
                Tello.sendControllerUpdate();

            }
        }

        private void TelloKeyControl_KeyDown(object sender, KeyEventArgs e)
        {
            key = e.KeyData.ToString(); //押されたキーを保存
            key = key.ToLower();
            //「S」による離陸
            if (key == "s" && Tello.connected && !Tello.state.flying)
            //Telloと接続中、かつ、飛行していない
            {
                Tello.takeOff();
            }
            //「D」による着陸
            if (key == "d" && Tello.connected && Tello.state.flying)
            //Telloと接続中、かつ、飛行中
            {
                Tello.controllerState.setAxis(0, 0, 0, 0);//静止
                Tello.sendControllerUpdate();
                Tello.land();
            }

            if (preKey != key) /* 押されたキーが変わったら */
            {
                switch (key)
                {
                    case "up":
                        Tello.controllerState.setAxis(0, 0, 0, 0.3f);//前進
                        Tello.sendControllerUpdate();
                        break;
                    case "down":
                        Tello.controllerState.setAxis(0, 0, 0, -0.3f);//後進
                        Tello.sendControllerUpdate();
                        break;
                    case "right":
                        Tello.controllerState.setAxis(0.3f, 0, 0, 0);//右旋回
                        Tello.sendControllerUpdate();
                        break;
                    case "left":
                        Tello.controllerState.setAxis(-0.3f, 0, 0, 0);//左旋回
                        Tello.sendControllerUpdate();
                        break;
                }
                consoleText += key + "\r\n"; //キーを｢console｣に出力
                console.Text = consoleText; //押されたキーを書き出し
                console.SelectionStart = console.TextLength; //カーソルを最下行へ移動
                console.Focus();
                console.ScrollToCaret();
            }
            else
            {
                console.SelectionStart = console.TextLength; //同じキーが押されっぱなしなら、
                                                             //カーソルを最下行へ移動するだけ
            }
            preKey = key; //一つ前のキーとして、保存
            preKey = preKey.ToLower();
        }

        private void TelloKeyControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (Tello.connected && Tello.state.flying) /* 接続されていて、飛行中 */
            {
                consoleText += "HOVERING" + "\r\n"; //｢HOVERING｣と表示
                console.Text = consoleText;
                console.SelectionStart = console.TextLength; //カーソルを最下行へ移動
                console.Focus();
                Tello.controllerState.setAxis(0, 0, 0, 0); //静止（ホバリング）
                Tello.sendControllerUpdate();
            }
            else if (Tello.connected && !Tello.state.flying) /* 接続されていて、飛んでいない */
            {
                consoleText += "NOT FLYING" + "\r\n"; // ｢NOT FLYING｣と表示
                console.Text = consoleText;
                console.SelectionStart = console.TextLength; //カーソルを最下行へ移動
                console.Focus();
            }
            else /* 接続されていない状態 */
            {
                consoleText += "NOT CONNECTING" + "\r\n"; //｢NOT CONNECTING｣と表示
                console.Text = consoleText;
                console.SelectionStart = console.TextLength; //カーソルを最下行へ移動
                console.Focus();
            }
            preKey = ""; //次の「KeyDown」のため、prekey,key を初期化
            key = "";

        }

        private static void Tello_onConnection(TelloLib.Tello.ConnectionState newState)
        {
            if (newState == Tello.ConnectionState.Connected)
            {
                Tello.queryAttAngle();
                Tello.setMaxHeight(1);
            }
        }

        private static void Tello_onVideoData(byte[] data) { }
        private static void Tello_onUpdate(int cmdId) { }
    }
}
