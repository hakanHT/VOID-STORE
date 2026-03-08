using System;
using System.Windows;
using System.Windows.Input;

namespace VOID_STORE
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Ekranı sürükleyebilmek için 
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            // Uygulamayı alta alma butonu
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Uygulamadan tamamen çıkış butonu
            Application.Current.Shutdown();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Veritabanı bağlantısı eklenecek
        }

        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            // Şifre sıfırlama ekranına yönlendirilecek
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Kayıt ekranına yönlendirilecek
        }

        private void GuestLogin_Click(object sender, RoutedEventArgs e)
        {
            // Misafir giriş paneline yönlendirilecek
        }
    }
}