using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace VOID_STORE
{
    public partial class CodeVerification : Window
    {
        public CodeVerification()
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
            ForgotPassword forgotScreen = new ForgotPassword();
            forgotScreen.Left = this.Left;
            forgotScreen.Top = this.Top;
            forgotScreen.WindowStartupLocation = WindowStartupLocation.Manual;
            forgotScreen.Show();
            this.Close();
        }

        private void CodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox currentBox && currentBox.Text.Length == 1)
            {
                if (currentBox == txtCode1) txtCode2.Focus();
                else if (currentBox == txtCode2) txtCode3.Focus();
                else if (currentBox == txtCode3) txtCode4.Focus();
                else if (currentBox == txtCode4) txtCode5.Focus();
                else if (currentBox == txtCode5) txtCode6.Focus();
                // Son kutuya gelince bir yere atlama
            }
        }

        private void VerifyCode_Click(object sender, RoutedEventArgs e)
        {
            // Doğrulama başarılı ise Şifre Yenileme ekranına geç , uygulama pozisyonunu koru
            ResetPassword resetScreen = new ResetPassword();
            resetScreen.Left = this.Left;
            resetScreen.Top = this.Top;
            resetScreen.WindowStartupLocation = WindowStartupLocation.Manual;
            resetScreen.Show();
            this.Close();
        }
    }
}
