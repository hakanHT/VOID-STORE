using System.Windows;
using System.Windows.Input;

namespace VOID_STORE.Views
{
    public partial class AccountRecovery : Window
    {
        public AccountRecovery()
        {
            // form bilesenlerini baslat
            InitializeComponent();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // pencere surukleme islemini aktif et
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // geri don butonuna basildiginda login sayfasini ac
            Login loginScreen = new Login();
            loginScreen.Left = this.Left;
            loginScreen.Top = this.Top;
            loginScreen.WindowStartupLocation = WindowStartupLocation.Manual;
            loginScreen.Show();
            this.Close();
        }

        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            // sifremi unuttum sayfasina yonlendir
            ForgotPassword forgotPasswordScreen = new ForgotPassword();
            forgotPasswordScreen.Left = this.Left;
            forgotPasswordScreen.Top = this.Top;
            forgotPasswordScreen.WindowStartupLocation = WindowStartupLocation.Manual;
            forgotPasswordScreen.Show();
            this.Close();
        }

        private void ForgotUsername_Click(object sender, RoutedEventArgs e)
        {
            // kullanici adi unuttum sayfasina yonlendir
            ForgotUsername forgotUsernameScreen = new ForgotUsername();
            forgotUsernameScreen.Left = this.Left;
            forgotUsernameScreen.Top = this.Top;
            forgotUsernameScreen.WindowStartupLocation = WindowStartupLocation.Manual;
            forgotUsernameScreen.Show();
            this.Close();
        }

        private void ForgotEmail_Click(object sender, RoutedEventArgs e)
        {
            // e-posta unuttum sayfasina yonlendir
            ForgotEmail forgotEmailScreen = new ForgotEmail();
            forgotEmailScreen.Left = this.Left;
            forgotEmailScreen.Top = this.Top;
            forgotEmailScreen.WindowStartupLocation = WindowStartupLocation.Manual;
            forgotEmailScreen.Show();
            this.Close();
        }
    }
}