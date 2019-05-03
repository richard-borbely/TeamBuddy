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

namespace TeamBuddy.App.ViewModels
{
    public class HomeCreateUserViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private UserDetailModel _newUser;

        public UserDetailModel NewUser
        {
            get => _newUser;
            set
            {
                _newUser = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateNewUserCommand { get; set; }
        public ICommand CreateNewUserCanceledCommand { get; set; }

        public HomeCreateUserViewModel(IMediator mediator)
        {
            this.mediator = mediator;

            CreateNewUserCanceledCommand = new RelayCommand(CreateNewUserCanceled);

            mediator.Register<CreateNewUserSelectedMessage>(ShowCreateNewUserTab);
            mediator.Register<CreateNewTeamSelectedMessage>(CreateNewUserCanceled);
        }

        private void CreateNewUserCanceled(CreateNewTeamSelectedMessage obj)
        {
            NewUser = null;
        }

        private void CreateNewUserCanceled()
        {
            NewUser = null;
        }

        private void ShowCreateNewUserTab(CreateNewUserSelectedMessage obj)
        {
            mediator.Send(new CreateNewTeamCancelMessage());
            NewUser = new UserDetailModel();
        }
    }
}
