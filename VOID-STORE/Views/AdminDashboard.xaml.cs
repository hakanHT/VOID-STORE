using System.Windows;
using System.Windows.Input;

namespace VOID_STORE.Views
{
    public partial class AdminDashboard : Window
    {
        public AdminDashboard()
        {
            // paneli baslat
            InitializeComponent();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // pencereyi surukle
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            // pencereyi kucult
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // uygulamayi kapat
            Application.Current.Shutdown();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // giris ekranina don
            Login loginWindow = new Login();
            loginWindow.Show();
            Close();
        }

        private void StoreButton_Click(object sender, RoutedEventArgs e)
        {
            // magazaya gec
            MainAppWindow mainWindow = new MainAppWindow();
            mainWindow.Show();
            Close();
        }

        private void PlaceholderButton_Click(object sender, RoutedEventArgs e)
        {
            // kapali bolumu bildir
            CustomError.ShowDialog("Bu bölüm henüz kullanıma açılmadı.", "BİLGİ", true);
        }
    }
}
