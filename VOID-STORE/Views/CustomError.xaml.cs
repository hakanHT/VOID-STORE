using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace VOID_STORE.Views
{
    public partial class CustomError : Window
    {
        public CustomError(string title, string message, bool isSuccess = false)
        {
            InitializeComponent();

            // Başlığı olduğu gibi göster
            txtTitle.Text = title?.Trim() ?? "Bilgi";
            txtMessage.Text = message;

            if (isSuccess)
            {
                // Başarılı işlemleri canlı yeşil ile göster
                Brush successBrush = new SolidColorBrush(Color.FromRgb(0x00, 0xCC, 0x00));
                txtTitle.Foreground = successBrush;
                btnOk.Background = successBrush;
                btnOk.BorderBrush = successBrush;
                btnOk.Foreground = Brushes.White;
            }
            else if (string.Equals(txtTitle.Text, "Bilgi", System.StringComparison.OrdinalIgnoreCase))
            {
                // Bilgi/Misafir uyarıları için beyaz buton ve koyu metin
                btnOk.Background = Brushes.White;
                btnOk.BorderBrush = Brushes.White;
                btnOk.Foreground = new SolidColorBrush(Color.FromRgb(0x0A, 0x0A, 0x0C));
                txtTitle.Foreground = Brushes.White;
            }
            else
            {
                // Hata durumlarında kırmızı buton (varsayılan)
                Brush errorBrush = new SolidColorBrush(Color.FromRgb(0xE8, 0x11, 0x23));
                txtTitle.Foreground = errorBrush;
                btnOk.Background = errorBrush;
                btnOk.BorderBrush = errorBrush;
                btnOk.Foreground = Brushes.White;
            }
        }

        public static void ShowDialog(string message, string title = "Bilgi", bool isSuccess = false, Window? owner = null)
        {
            CustomError errorWindow = new CustomError(title, message, isSuccess);
            Window? dialogOwner = owner ?? GetActiveWindow();

            if (dialogOwner != null)
            {
                errorWindow.Owner = dialogOwner;
                errorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            else
            {
                errorWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }

            errorWindow.ShowDialog();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Başlıktan pencereyi taşı
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Pencereyi kapat
            Close();
        }

        private static Window? GetActiveWindow()
        {
            // Etkin pencereyi bul
            if (Application.Current == null)
            {
                return null;
            }

            foreach (Window window in Application.Current.Windows)
            {
                if (window.IsActive)
                {
                    return window;
                }
            }

            return Application.Current.MainWindow;
        }
    }
}
