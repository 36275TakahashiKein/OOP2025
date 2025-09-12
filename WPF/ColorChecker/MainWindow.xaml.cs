using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        MyColor currentColor;
        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
        }

        /// <summary>
        /// MainWindow.xaml の相互作用ロジック
        /// </summary>
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            var newColor = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            colorArea.Background = new SolidColorBrush(newColor);

            var colorList = (MyColor[])DataContext;
            int i = Array.FindIndex(colorList, c => c.Color.Equals(newColor));

            if (i != -1) {
                currentColor = colorList[i]; // currentColor を更新
                colorSelectComboBox.SelectedIndex = i;
            } else {
                currentColor = new MyColor() { Color = newColor, Name = $"R: {newColor.R}, G: {newColor.G}, B: {newColor.B}" };
                colorSelectComboBox.SelectedIndex = -1; // 対応色がなければ選択解除
            }


        }


        //コンボボックスから色を選択
        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var cb = (ComboBox)sender;

            if (((ComboBox)sender).SelectedIndex == -1) return;

            var comboSelectMyColor = ((MyColor)((ComboBox)sender).SelectedItem).Color;
            currentColor = (MyColor)((ComboBox)sender).SelectedItem;
            setSliderValue(comboSelectMyColor);
        }

        //各スライダーの値を設定する
        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            byte rValue = (byte)rSlider.Value;
            byte gValue = (byte)gSlider.Value;
            byte bValue = (byte)bSlider.Value;

            string colorText = $"R: {rValue}, G: {gValue}, B: {bValue}";


            var matchedColor = GetColorList().FirstOrDefault(c =>
            c.Color.R == rValue &&
            c.Color.G == gValue &&
            c.Color.B == bValue
            );

            if (matchedColor != null) {
                colorList.Items.Add(matchedColor.Name);  // MyColor オブジェクトをそのまま追加
            } else {
                // 一致しなければ RGB 値を表示
                var newColor = new MyColor {
                    Color = Color.FromRgb(rValue, gValue, bValue),
                    Name = colorText // RGB値を名前として設定
                };
                colorList.Items.Add(newColor.Name);  // MyColor オブジェクトを追加
            }

        }

        private void colorList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // ListBox から選択されたアイテムを取得（名前は "R: 255, G: 0, B: 0" など）
            string selectedColorText = (string)((ListBox)sender).SelectedItem;

            if (!string.IsNullOrEmpty(selectedColorText)) {
                // 1. RGB 形式のチェック
                var match = Regex.Match(selectedColorText, @"R:\s*(\d+),\s*G:\s*(\d+),\s*B:\s*(\d+)");

                if (match.Success) {
                    // RGB 形式の場合
                    int rValue = int.Parse(match.Groups[1].Value);
                    int gValue = int.Parse(match.Groups[2].Value);
                    int bValue = int.Parse(match.Groups[3].Value);

                    // スライダーに反映させる
                    rSlider.Value = rValue;
                    gSlider.Value = gValue;
                    bSlider.Value = bValue;

                    // 色を反映
                    colorArea.Background = new SolidColorBrush(Color.FromRgb((byte)rValue, (byte)gValue, (byte)bValue));
                } else {
                    // 2. 色名の場合
                    try {
                        // Colors クラスから色名を取得
                        var colorProperty = typeof(Colors).GetProperty(selectedColorText, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

                        if (colorProperty != null) {
                            Color color = (Color)colorProperty.GetValue(null);
                            // 色を反映
                            colorArea.Background = new SolidColorBrush(color);

                            // スライダーに反映させる
                            rSlider.Value = color.R;
                            gSlider.Value = color.G;
                            bSlider.Value = color.B;
                        }
                    }
                    catch (Exception ex) {
                        // 色名が不正だった場合のエラーハンドリング
                        MessageBox.Show($"エラー: 色名 '{selectedColorText}' は認識できません。{ex.Message}");
                    }
                }
            }
        }
    }
}
