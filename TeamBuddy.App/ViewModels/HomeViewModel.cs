using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuddy.BL.Messages;
using TeamBuddy.BL.Models;
using TeamBuddy.BL.Services;

namespace TeamBuddy.App.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IMediator mediator;

        public Object ShowHomeView { get; set; } = new Object();
        //public UserDetailModel SignedUser { get; set; }

        public HomeViewModel(IMediator mediator)
        {
            this.mediator = mediator;

            mediator.Register<TeamSelectedMessage>(HideHomeView);
        }

        private void HideHomeView(TeamSelectedMessage obj)
        {
            ShowHomeView = null;
        }
    }
}
