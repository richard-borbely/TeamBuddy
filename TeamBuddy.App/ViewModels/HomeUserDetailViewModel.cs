using System.Windows;
using System.Windows.Input;
using TeamBuddy.App.Commands;
using TeamBuddy.App.Services;
using TeamBuddy.BL.Messages;
using TeamBuddy.BL.Models;
using TeamBuddy.BL.Repositories;
using TeamBuddy.BL.Services;

namespace TeamBuddy.App.ViewModels
{
    public class HomeUserDetailViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private readonly ITeamBuddyRepository teamBuddyRepository;
        private readonly IMessageBoxService messageBoxService;
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

        public HomeUserDetailViewModel(IMediator mediator, ITeamBuddyRepository teamBuddyRepository, IMessageBoxService messageBoxService)
        {
            this.mediator = mediator;
            this.teamBuddyRepository = teamBuddyRepository;
            this.messageBoxService = messageBoxService;

            CreateNewUserSelectedCommand = new RelayCommand(CreateNewUserSelected);
            CreateNewTeamSelectedCommand = new RelayCommand(CreateNewTeamSelected);

            mediator.Register<LogInMessage>(ShowUserDetails);
            mediator.Register<AddUserToTeamMessage>(AddUserToTeam);
        }

        private void AddUserToTeam(AddUserToTeamMessage newTeam)
        {
            try
            {
                teamBuddyRepository.AddUserToTeam(User, newTeam.Id);
                mediator.Send(new ReloadMyTeamsMessage{Id = User.Id});
            }
            catch
            {
                messageBoxService.Show($"User can't be added to team!", "User addition failed", MessageBoxButton.OK);
            }
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
