using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuddy.BL.Services;

namespace TeamBuddy.App.ViewModels
{
    public class ViewModelLocator
    {
        public IMediator Mediator { get; set; }
        public HomeUserDetailViewModel HomeUserDetailViewModel => new HomeUserDetailViewModel(Mediator);
        public HomeTeamListViewModel HomeTeamListViewModel => new HomeTeamListViewModel(Mediator);
        public HomeCreateUserViewModel HomeCreateUserViewModel => new HomeCreateUserViewModel(Mediator);
        public HomeCreateTeamViewModel HomeCreateTeamViewModel => new HomeCreateTeamViewModel(Mediator);
        public ViewModelLocator()
        {
            Mediator = new Mediator();
        }
    }
}
