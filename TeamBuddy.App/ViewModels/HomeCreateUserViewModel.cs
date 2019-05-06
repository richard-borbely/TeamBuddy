using System.Windows;
using System.Windows.Input;
using TeamBuddy.App.Commands;
using TeamBuddy.App.Services;
using TeamBuddy.BL.Messages;
using TeamBuddy.BL.Models;
using TeamBuddy.BL.Repositories;
using TeamBuddy.BL.Services;
using TeamBuddy.DAL.Enumerations;

namespace TeamBuddy.App.ViewModels
{
    public class HomeCreateUserViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private readonly ITeamBuddyRepository teamBuddyRepository;
        private readonly IMessageBoxService messageBoxService;
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

        public HomeCreateUserViewModel(IMediator mediator, ITeamBuddyRepository teamBuddyRepository, IMessageBoxService messageBoxService)
        {
            this.mediator = mediator;
            this.teamBuddyRepository = teamBuddyRepository;
            this.messageBoxService = messageBoxService;

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
            try
            {
                teamBuddyRepository.Create(NewUser);
                NewUser = null;
            }
            catch
            {
                messageBoxService.Show($"Please, fill in the required fields!", "User creation failed", MessageBoxButton.OK);
            }
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
