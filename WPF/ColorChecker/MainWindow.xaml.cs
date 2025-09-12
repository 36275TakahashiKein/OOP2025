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
                currentColor = colorList[i];
                colorSelectComboBox.SelectedIndex = i;
            } else {
                currentColor = new MyColor() { Color = newColor, Name = $"R: {newColor.R}, G: {newColor.G}, B: {newColor.B}" };
                colorSelectComboBox.SelectedIndex = -1;
            }
        }

        //コンボボックスから色を選択
        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
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
                colorList.Items.Add(matchedColor.Name);//ColorName探す
            } else {
                var newColor = new MyColor { //NameなければRGB
                    Color = Color.FromRgb(rValue, gValue, bValue),
                    Name = colorText
                };
                colorList.Items.Add(newColor.Name);
            }
        }

        private void colorList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            string selectedColorText = (string)((ListBox)sender).SelectedItem;
            //正規表現で探す
            if (!string.IsNullOrEmpty(selectedColorText)) {
                
                var match = Regex.Match(selectedColorText, @"R:\s*(\d+),\s*G:\s*(\d+),\s*B:\s*(\d+)");

                if (match.Success) {
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

        private void Window_Loaded(object sender, RoutedEventArgs e) { 
            var defaultColor = Colors.Black;
            setSliderValue(defaultColor);
            colorArea.Background = new SolidColorBrush(defaultColor);

            var colorList = (MyColor[])DataContext;
            int index = Array.FindIndex(colorList, c => c.Color.Equals(defaultColor));

            if (index != -1) {
                colorSelectComboBox.SelectedIndex = index;
                currentColor = colorList[index];
            }
        }
    }
}
