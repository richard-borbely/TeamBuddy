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
    public class HomeCreateTeamViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
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

        public HomeCreateTeamViewModel(IMediator mediator)
        {
            this.mediator = mediator;

            CreateNewTeamCanceledCommand = new RelayCommand(CreateNewTeamCanceled);

            mediator.Register<CreateNewTeamSelectedMessage>(ShowCreateNewTeamTab);
            mediator.Register<CreateNewTeamCancelMessage>(CreateNewTeamCanceled);
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
