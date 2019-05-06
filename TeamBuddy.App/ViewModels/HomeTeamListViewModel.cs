using System.Collections.ObjectModel;
using System.Windows.Input;
using TeamBuddy.App.Commands;
using TeamBuddy.BL.Extensions;
using TeamBuddy.BL.Messages;
using TeamBuddy.BL.Models;
using TeamBuddy.BL.Repositories;
using TeamBuddy.BL.Services;

namespace TeamBuddy.App.ViewModels
{
    public class HomeTeamListViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private readonly ITeamBuddyRepository teamBuddyRepository;

        public ObservableCollection<TeamListModel> Teams { get; set; } = new ObservableCollection<TeamListModel>();

        public ICommand TeamSelectedCommand { get; set; }

        public HomeTeamListViewModel(IMediator mediator, ITeamBuddyRepository teamBuddyRepository)
        {
            this.mediator = mediator;
            this.teamBuddyRepository = teamBuddyRepository;

            TeamSelectedCommand = new RelayCommand<TeamListModel>(TeamSelected);

            mediator.Register<LogInMessage>(ListUserTeams);
            mediator.Register<ReloadMyTeamsMessage>(ReloadMyTeams);
        }

        private void ReloadMyTeams(ReloadMyTeamsMessage signedUser)
        {
            Teams.Clear();
            var teams = teamBuddyRepository.GetAllMyTeams(signedUser.Id);
            Teams.AddRange(teams);
        }

        private void ListUserTeams(LogInMessage login)
        {
            var teams = teamBuddyRepository.GetAllMyTeams(login.SignedUser.Id);
            Teams.AddRange(teams);
        }

        private void TeamSelected(TeamListModel team)
        {
            mediator.Send(new TeamSelectedMessage { Name = team.Name });
        }
    }
}
