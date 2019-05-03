using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuddy.BL.Models;
using TeamBuddy.BL.Services;

namespace TeamBuddy.App.ViewModels
{
    public class HomeTeamListViewModel : ViewModelBase
    {
        private readonly IMediator mediator;

        public ObservableCollection<TeamListModel> Teams { get; set; } = new ObservableCollection<TeamListModel>()
        {
            new TeamListModel() {Name = "IFJ Team"},
            new TeamListModel() {Name = "ICS Team"},
            new TeamListModel() {Name = "IW5 Team"}
        };

        public HomeTeamListViewModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

    }
}
