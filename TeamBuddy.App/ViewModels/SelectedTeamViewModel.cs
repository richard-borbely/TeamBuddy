using System;
using TeamBuddy.BL.Messages;
using TeamBuddy.BL.Services;

namespace TeamBuddy.App.ViewModels
{
    public class SelectedTeamViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private object _showSelectedTeam = null;

        public Object ShowSelectedTeam
        {
            get => _showSelectedTeam;
            set
            {
                _showSelectedTeam = value;
                OnPropertyChanged();
            }
        }

        public SelectedTeamViewModel(IMediator mediator)
        {
            this.mediator = mediator;

            mediator.Register<TeamSelectedMessage>(ShowSelectedTeamView);
            mediator.Register<BackHomeMessage>(HideSelectedTeamView);
        }

        private void ShowSelectedTeamView(TeamSelectedMessage obj)
        {
            ShowSelectedTeam = new Object();
        }

        private void HideSelectedTeamView(BackHomeMessage obj)
        {
            ShowSelectedTeam = null;
        }
    }
}
