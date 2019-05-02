using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TeamBuddy.BL.Models;
using TeamBuddy.DAL.Enumerations;

namespace TeamBuddy.App
{
    public class MainViewModel
    {
        public ObservableCollection<TeamListModel> Teams { get; } =
            new ObservableCollection<TeamListModel>
            {
                new TeamListModel() {Name = "IFJ Team"},
                new TeamListModel() {Name = "IPP Team"},
                new TeamListModel() {Name = "ICS Team"}
            };

        public UserDetailModel User { get; set; }

        public MainViewModel()
        {
            this.User = new UserDetailModel
            {
                Email = "xborbe00@stud.fit.vutbr.cz",
                Username = "xborbe00",
                Name = "Richard Borbely",
                Gender = Gender.Male
            };
        }
    }
}