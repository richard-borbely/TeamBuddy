using System.Windows;

namespace TeamBuddy.App.Views
{
    /// <summary>
    /// Interaction logic for TeamBuddyWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }


        private void HomePageUc_OnLoaded(object sender, RoutedEventArgs e)
        {
            TeamBuddy.App.ViewModel.UserViewModel userViewModelObject =
                new TeamBuddy.App.ViewModel.UserViewModel();
            userViewModelObject.LoadUser();

            HomePageUc.DataContext = userViewModelObject;
        }
    }
}
