using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ICommand GenderSelectedCommand { get; set; }
        public ICommand CreateNewUserCommand { get; set; }
        public ICommand CreateNewUserCanceledCommand { get; set; }

        public HomeCreateUserViewModel(IMediator mediator)
        {
            this.mediator = mediator;

            GenderSelectedCommand = new RelayCommand<Gender>(GenderSelected);
            CreateNewUserCommand = new RelayCommand(CreateNewUser);
            CreateNewUserCanceledCommand = new RelayCommand(CreateNewUserCancel);

            mediator.Register<CreateNewUserSelectedMessage>(ShowCreateNewUserTab);
            mediator.Register<CreateNewTeamSelectedMessage>(CreateNewUserCancel);
        }

        private void GenderSelected(Gender userGender)
        {
            NewUser.Gender = userGender;
        }

        private void CreateNewUser()
        {
            
        }

        private void CreateNewUserCancel(CreateNewTeamSelectedMessage obj)
        {
            NewUser = null;
        }

        private void CreateNewUserCancel()
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
