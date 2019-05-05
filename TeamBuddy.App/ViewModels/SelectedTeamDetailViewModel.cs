using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TeamBuddy.App.Commands;
using TeamBuddy.BL.Extensions;
using TeamBuddy.BL.Messages;
using TeamBuddy.BL.Models;
using TeamBuddy.BL.Repositories;
using TeamBuddy.BL.Services;
using TeamBuddy.DAL.Entities;
using TeamBuddy.DAL.Enumerations;

namespace TeamBuddy.App.ViewModels
{
    public class SelectedTeamDetailViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private readonly ITeamBuddyRepository teamBuddyRepository;
        private TeamDetailModel _selectedTeam;
        private ObservableCollection<UserListModel> _users;

        public ObservableCollection<UserListModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            } 
        }

        public TeamDetailModel SelectedTeam
        {
            get => _selectedTeam;
            set
            {
                _selectedTeam = value;
                OnPropertyChanged();
            } 
        }
        
        public ICommand UserSelectedCommand { get; set; }

        public SelectedTeamDetailViewModel(IMediator mediator, ITeamBuddyRepository teamBuddyRepository)
        {
            this.mediator = mediator;
            this.teamBuddyRepository = teamBuddyRepository;

            UserSelectedCommand = new RelayCommand<UserListModel>(UserSelected);

            mediator.Register<TeamSelectedMessage>(TeamSelected);
            mediator.Register<ReloadTeamUsersMessage>(ReloadTeamUsers);
        }

        private void ReloadTeamUsers(ReloadTeamUsersMessage obj)
        {
            Users.Clear();
            var users = teamBuddyRepository.GetAllUsersInTeam(SelectedTeam.Id);
            Users.AddRange(users);
        }

        private void UserSelected(UserListModel user)
        {
            mediator.Send(new UserSelectedMessage {Username = user.Username});
        }

        private void TeamSelected(TeamSelectedMessage selectedTeam)
        {
            Users = new ObservableCollection<UserListModel>();
            SelectedTeam = teamBuddyRepository.GetByName(selectedTeam.Name);
            var users = teamBuddyRepository.GetAllUsersInTeam(SelectedTeam.Id);
            Users.AddRange(users);
        }
    }
}
