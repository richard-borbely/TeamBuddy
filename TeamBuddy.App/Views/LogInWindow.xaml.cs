using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeamBuddy.App.Views;

namespace TeamBuddyUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBoxLogin_OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            //if (txtBox.Text == "xlogin00@fit.vutbr.cz")
                txtBox.Text = string.Empty;
        }

        private void TextBoxPassword_OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            //if (txtBox.Text == "●●●●●●●●●●●●")
                txtBox.Text = string.Empty;
        }

        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow();
            signInWindow.Show();
            this.Close();
        }

        private void ButtonLogo_Click(object sender, RoutedEventArgs e)
        {
            TeamSelectionWindow teamSelectionWindow = new TeamSelectionWindow();
            teamSelectionWindow.Show();
            this.Close();
        }
    }
}
