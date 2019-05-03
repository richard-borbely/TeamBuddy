using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuddy.App.Views;
using TeamBuddy.BL.Services;

namespace TeamBuddy.App.ViewModels
{
    public class ViewModelLocator
    {
        public IMediator Mediator { get; set; }
        public HomeViewModel HomeViewModel => new HomeViewModel(Mediator);
        public HomeUserDetailViewModel HomeUserDetailViewModel => new HomeUserDetailViewModel(Mediator);
        public HomeTeamListViewModel HomeTeamListViewModel => new HomeTeamListViewModel(Mediator);
        public HomeCreateUserViewModel HomeCreateUserViewModel => new HomeCreateUserViewModel(Mediator);
        public HomeCreateTeamViewModel HomeCreateTeamViewModel => new HomeCreateTeamViewModel(Mediator);
        public SelectedTeamViewModel SelectedTeamViewModel => new SelectedTeamViewModel(Mediator);
        public SelectedTeamLeftBarView SelectedTeamLeftBarView => new SelectedTeamLeftBarView(Mediator);
        public ViewModelLocator()
        {
            Mediator = new Mediator();
        }
    }
}
