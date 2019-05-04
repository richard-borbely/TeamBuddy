using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TeamBuddy.App.Commands;
using TeamBuddy.BL.Messages;
using TeamBuddy.BL.Models;
using TeamBuddy.BL.Services;
using TeamBuddy.DAL.Enumerations;

namespace TeamBuddy.App.ViewModels
{
    public class HomeUserDetailViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private UserDetailModel _user;

        public UserDetailModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            } 
        }

        public ICommand CreateNewUserSelectedCommand { get; set; }
        public ICommand CreateNewTeamSelectedCommand { get; set; }

        public HomeUserDetailViewModel(IMediator mediator)
        {
            this.mediator = mediator;

            CreateNewUserSelectedCommand = new RelayCommand(CreateNewUserSelected);
            CreateNewTeamSelectedCommand = new RelayCommand(CreateNewTeamSelected);

            mediator.Register<LogInMessage>(ShowUserDetails);
        }

        private void ShowUserDetails(LogInMessage login)
        {
            User = login.SignedUser;
        }

        private void CreateNewTeamSelected()
        {
            mediator.Send(new CreateNewTeamSelectedMessage());
        }

        private void CreateNewUserSelected()
        {
            mediator.Send(new CreateNewUserSelectedMessage());
        }
    }
}
