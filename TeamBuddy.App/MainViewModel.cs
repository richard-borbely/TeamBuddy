using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TeamBuddy.BL.Models;
using TeamBuddy.DAL.Enumerations;

namespace TeamBuddy.App
{
    public class MainViewModel
    {
        public ObservableCollection<TeamListModel> TeamSelectionTeamListVm { get; } = new ObservableCollection<TeamListModel>();


        public UserDetailModel User { get; set; }


        public MainViewModel()
        {

            this.TeamSelectionTeamListVm.Add(new TeamListModel() { Name = "IFJ Team" });
            this.TeamSelectionTeamListVm.Add(new TeamListModel() { Name = "IPP Team" });
            this.TeamSelectionTeamListVm.Add(new TeamListModel() { Name = "ICS Team" });
            this.TeamSelectionTeamListVm.Add(new TeamListModel() { Name = "IW5 Team" });


            this.User = new UserDetailModel
            {
                Email = "xborbe00@stud.fit.vutbr.cz",
                Username = "xborbe00",
                Name = "Richard Borbely",
                Gender = Gender.Male
            };

        }

        public ObservableCollection<string> Name { get; set; }
    }

}