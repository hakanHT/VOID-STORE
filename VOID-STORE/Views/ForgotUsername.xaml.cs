using System;
using System.Windows;
using System.Windows.Input;
using VOID_STORE.Controllers;

namespace VOID_STORE.Views
{
    public partial class ForgotUsername : Window
    {
        private readonly ForgotUsernameController _controller;

        public ForgotUsername()
        {
            // gorsel bilesenleri baslat
            InitializeComponent();
            _controller = new ForgotUsernameController();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // pencereyi suruklemek icin
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
            // kurtarma seceneklerine geri don
            AccountRecovery recoveryScreen = new AccountRecovery();
            recoveryScreen.Left = this.Left;
            recoveryScreen.Top = this.Top;
            recoveryScreen.WindowStartupLocation = WindowStartupLocation.Manual;
            recoveryScreen.Show();
            this.Close();
        }

        private void SendUsername_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();

            // alan bos mu kontrolu
            if (string.IsNullOrEmpty(email))
            {
                CustomError.ShowDialog("Lütfen e-posta adresinizi girin.", "EKSİK BİLGİ");
                return;
            }

            try
            {
                // controllera islem icin gonder
                string result = _controller.SendUsernameReminder(email);

                if (string.IsNullOrEmpty(result))
                {
                    // islem basariliysa yesil pencere ile bilgi ver
                    CustomError.ShowDialog("Kullanıcı adınız e-posta adresinize başarıyla gönderildi.", "BAŞARILI", true);
                    
                    // login ekranina geri dondur
                    Login loginScreen = new Login();
                    loginScreen.Left = this.Left;
                    loginScreen.Top = this.Top;
                    loginScreen.WindowStartupLocation = WindowStartupLocation.Manual;
                    loginScreen.Show();
                    this.Close();
                }
                else
                {
                    // islem hataliysa kirmizi pencere ile sebebi goster
                    CustomError.ShowDialog(result, "HATA");
                }
            }
            catch (Exception ex)
            {
                CustomError.ShowDialog("Bir hata oluştu: " + ex.Message, "SİSTEM HATASI");
            }
        }
    }
}