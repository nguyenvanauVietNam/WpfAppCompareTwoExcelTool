using Microsoft.Win32;
using System.IO;
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

namespace WpfAppCompareTwoExcelTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SelectExcelFileButton_Click(object sender, RoutedEventArgs e)
        {
            // Tạo một OpenFileDialog
            string strTitle = "Chọn File Excel";
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*",
                Title = strTitle
            };

            // Hiển thị hộp thoại và kiểm tra nếu người dùng đã chọn file
            if (openFileDialog.ShowDialog() == true)
            {
                // Lấy đường dẫn file đã chọn
                string filePath = openFileDialog.FileName;
                //MessageBox.Show($"Bạn đã chọn file: {filePath}");

                // Bạn có thể thêm mã để xử lý file Excel ở đây
                // Xác định nút nào đã được nhấn thông qua Tag
                if (sender is Button button && button.Tag is string textBoxName)
                {
                    // Lấy tên file đã chọn
                    string selectedFilePath = openFileDialog.FileName;
                    // Cập nhật TextBox tương ứng với file đã chọn
                    TextBox textBox = (TextBox)this.FindName(textBoxName);
                    if (textBox != null)
                    {
                        textBox.Text = selectedFilePath;
                    }
                }

            }
        }
        private void CompareExcelFile_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem TextBox1 và TextBox2 có rỗng không
            if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                TextBlock1.Text = string.Empty;
                TextBlock1.Text = "Đường dẫn rỗng";
                return;
            }

            // Kiểm tra xem đường dẫn trong TextBox1 có hợp lệ không
            if (!File.Exists(TextBox1.Text))
            {
                TextBlock1.Text = string.Empty;
                TextBlock1.Text = "Đường dẫn execel 1 không hợp lệ";
                return;
            }

            // Kiểm tra xem đường dẫn trong TextBox2 có hợp lệ không
            if (!File.Exists(TextBox2.Text))
            {
                TextBlock1.Text = string.Empty;
                TextBlock1.Text = "Đường dẫn execel 2 không hợp lệ";
                return;
            }

            // Nếu tất cả đều hợp lệ, thực hiện so sánh hoặc các thao tác khác ở đây
            // ...
            TextBlock1.Text = string.Empty;
            TextBlock1.Text = "File đã sẵn sàng compare";

        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
           //TODO
        }

    }

}