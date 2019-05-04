using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
        private object _showHome = null;

        public Object ShowHome
        {
            get => _showHome;
            set
            {
                _showHome = value;
                OnPropertyChanged();
            }
        }
        //public UserDetailModel SignedUser { get; set; }

        public HomeViewModel(IMediator mediator)
        {
            this.mediator = mediator;

            mediator.Register<LogInMessage>(ShowHomeView);
            mediator.Register<TeamSelectedMessage>(HideHomeView);
            mediator.Register<BackHomeMessage>(ShowHomeView);
        }

        private void HideHomeView(TeamSelectedMessage obj)
        {
            ShowHome = null;
        }

        private void ShowHomeView(Object obj)
        {
            ShowHome = new Object();
        }
    }
}
