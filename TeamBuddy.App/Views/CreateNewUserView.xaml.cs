using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TeamBuddy.App.Views
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class CreateNewUserView : Window
    {
        public CreateNewUserView()
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

        //private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        //{
        //    MainWindow mainWindow = new MainWindow();
        //    mainWindow.Show();
        //    this.Close();
        //}

        private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}