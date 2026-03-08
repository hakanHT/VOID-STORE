using System;
using System.Windows;
using System.Windows.Input;

namespace VOID_STORE
{
    public partial class ResetPassword : Window
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Kullanıcı bu aşamada geri dönmek isterse Login'e dönsün
            Login loginScreen = new Login();
            loginScreen.Left = this.Left;
            loginScreen.Top = this.Top;
            loginScreen.WindowStartupLocation = WindowStartupLocation.Manual;
            loginScreen.Show();
            this.Close();
        }

        private void SavePassword_Click(object sender, RoutedEventArgs e)
        {
            // Şifre kaydetme işlemi eklenecek.
        }
    }
}
