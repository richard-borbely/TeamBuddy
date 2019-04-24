using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TeamBuddy.App.Views;

namespace TeamBuddy.App.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LogInView : MainWindow
    {
        public LogInView()
        {
            InitializeComponent();
        }

        private void TextBoxLogin_OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text == "xlogin00@fit.vutbr.cz")
                txtBox.Text = string.Empty;
        }

        private void TextBoxPassword_OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text == "●●●●●●●●●●●●")
                txtBox.Text = string.Empty;
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
            //this.Close();
        }

        //private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        //{
        //    SignInWindow signInWindow = new SignInWindow();
        //    signInWindow.Show();
        //    this.Close();
        //}
    }
}
