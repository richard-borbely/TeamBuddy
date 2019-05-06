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
    public class HomeCreateTeamViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private readonly ITeamBuddyRepository teamBuddyRepository;
        private readonly IMessageBoxService messageBoxService;
        private TeamDetailModel _newTeam;

        public TeamDetailModel NewTeam
        {
            get => _newTeam;
            set
            {
                _newTeam = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateNewTeamCommand { get; set; }
        public ICommand CreateNewTeamCanceledCommand { get; set; }

        public HomeCreateTeamViewModel(IMediator mediator, ITeamBuddyRepository teamBuddyRepository, IMessageBoxService messageBoxService)
        {
            this.mediator = mediator;
            this.teamBuddyRepository = teamBuddyRepository;
            this.messageBoxService = messageBoxService;

            CreateNewTeamCanceledCommand = new RelayCommand(CreateNewTeamCanceled);
            CreateNewTeamCommand = new RelayCommand(CreateNewTeam);

            mediator.Register<CreateNewTeamSelectedMessage>(ShowCreateNewTeamTab);
            mediator.Register<CreateNewTeamCancelMessage>(CreateNewTeamCanceled);
        }

        private void CreateNewTeam(object obj)
        {
            try
            {
                var newTeamModel = teamBuddyRepository.Create(NewTeam);
                mediator.Send(new AddUserToTeamMessage { Id = newTeamModel.Id });
                NewTeam = null;
            }
            catch
            {
                messageBoxService.Show($"Please, fill in the required fields!", "Team creation failed", MessageBoxButton.OK);
            }
        }

        private void CreateNewTeamCanceled(CreateNewTeamCancelMessage obj)
        {
            NewTeam = null;
        }

        private void CreateNewTeamCanceled()
        {
            NewTeam = null;
        }

        private void ShowCreateNewTeamTab(CreateNewTeamSelectedMessage obj)
        {
            mediator.Send(new CreateNewUserCancelMessage());
            NewTeam = new TeamDetailModel();
        }
    }
}
