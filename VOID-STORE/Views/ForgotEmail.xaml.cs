using System;
using System.Windows;
using System.Windows.Input;
using VOID_STORE.Controllers;

namespace VOID_STORE.Views
{
    public partial class ForgotEmail : Window
    {
        private readonly ForgotEmailController _controller;

        public ForgotEmail()
        {
            // form bilesenlerini baslat
            InitializeComponent();
            _controller = new ForgotEmailController();
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
            // kucultme islemi
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // kapatma islemi
            Application.Current.Shutdown();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // geri don islemi
            AccountRecovery recoveryScreen = new AccountRecovery();
            recoveryScreen.Left = this.Left;
            recoveryScreen.Top = this.Top;
            recoveryScreen.WindowStartupLocation = WindowStartupLocation.Manual;
            recoveryScreen.Show();
            this.Close();
        }

        private void FindEmail_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();

            // bos alan kontrolu
            if (string.IsNullOrEmpty(username))
            {
                CustomError.ShowDialog("Lütfen kullanıcı adınızı girin.", "EKSİK BİLGİ");
                return;
            }

            try
            {
                // veritabanindan maili bul ve maskele
                string maskedEmail = _controller.GetMaskedEmail(username);

                if (!string.IsNullOrEmpty(maskedEmail))
                {
                    // mail bulunduysa ekranda goster
                    txtMaskedEmail.Text = maskedEmail;
                    pnlResult.Visibility = Visibility.Visible;
                }
                else
                {
                    // kullanici bulunamadiysa uyari ver
                    CustomError.ShowDialog("Bu kullanıcı adına ait bir hesap bulunamadı.", "BULUNAMADI");
                    pnlResult.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                CustomError.ShowDialog("Bir hata oluştu: " + ex.Message, "SİSTEM HATASI");
            }
        }

        private void GoToForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            // sifremi unuttum ekranina gecis
            ForgotPassword forgotScreen = new ForgotPassword();
            forgotScreen.Left = this.Left;
            forgotScreen.Top = this.Top;
            forgotScreen.WindowStartupLocation = WindowStartupLocation.Manual;
            forgotScreen.Show();
            this.Close();
        }
    }
}