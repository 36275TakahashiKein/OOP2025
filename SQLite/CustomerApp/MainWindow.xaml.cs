using CustomerApp.Data;
using SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomerApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    private List<Customer> _customers = new List<Customer>();
    public MainWindow() {
        InitializeComponent();
        ReadDatabase();
        CustomerListView.ItemsSource = _customers;
    }
    private void ReadDatabase() {
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            _customers = connection.Table<Customer>().ToList();

        }
    }
    private void SaveButton_Click(object sender, RoutedEventArgs e) {
        var customer = new Customer() {
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
            Address = JyushoTextBox.Text,
        };

        var openFileDialog = new Microsoft.Win32.OpenFileDialog();
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
        bool? result = openFileDialog.ShowDialog();

        if (result == true) {
            var imagePath = openFileDialog.FileName;
            byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
            customer.Picture = imageBytes; // 画像をbyte[]として保存
        }


        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Insert(customer);
        }
    }

    private void ReadButton_Click(object sender, RoutedEventArgs e) {
        ReadDatabase();
        CustomerListView.ItemsSource = _customers;

    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e) {
        var item = CustomerListView.SelectedItem as Customer;


        if (item == null) {
            MessageBox.Show("行を選択してください"); return;
        }
        //データベース接続
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Delete(item);//データベースから選択されているレコードの削除
            ReadDatabase();
            CustomerListView.ItemsSource = _customers;

        }
    }

    //リストビューのフィルタリング
    private void SeartchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
        var filterList = _customers.Where(p => p.Name.Contains(SeartchTextBox.Text));

        CustomerListView.ItemsSource = filterList;
    }

    //リストビューから1レコード選択
    private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var selectedCustomer = CustomerListView.SelectedItem as Customer;

        // 選択した人の名前と電話をテキストボックスに表示する
        NameTextBox.Text = selectedCustomer?.Name;
        PhoneTextBox.Text = selectedCustomer?.Phone;

    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e) {
        var selectedCustomer = CustomerListView.SelectedItem as Customer;
        if (selectedCustomer is null) return;
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            var customer = new Customer() {
                Id = selectedCustomer.Id,
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
            };
            connection.Update(customer);
        }
        ReadDatabase();
        CustomerListView.ItemsSource = _customers;
    }

}






