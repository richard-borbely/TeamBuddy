using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class SelectedTeamUserSettingsViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private readonly ITeamBuddyRepository teamBuddyRepository;
        private readonly IMessageBoxService messageBoxService;
        private UserListModel _user;

        public UserListModel User
        {
            get => _user;
            set
            {
                _user = value; 
                OnPropertyChanged();
            }
        }

        private TeamDetailModel SelectedTeam { get; set; }

        public ICommand UserSettingsCancelCommand { get; set; }
        public ICommand AddNewUserToTeamCommand { get; set; }
        public ICommand DeleteUserFromTeamCommand { get; set; }

        public SelectedTeamUserSettingsViewModel(IMediator mediator, ITeamBuddyRepository teamBuddyRepository, IMessageBoxService messageBoxService)
        {
            this.mediator = mediator;
            this.teamBuddyRepository = teamBuddyRepository;
            this.messageBoxService = messageBoxService;

            UserSettingsCancelCommand = new RelayCommand(HideUsersSettings);
            AddNewUserToTeamCommand = new RelayCommand(AddNewUserToTeam);
            DeleteUserFromTeamCommand = new RelayCommand(DeleteUserFromTeam);

            mediator.Register<TeamSelectedMessage>(TeamSelected);
            mediator.Register<UsersSettingsSelectedMessage>(UserSettingsSelected);
            mediator.Register<UsersSettingsCancelMessage>(HideUsersSettings);
        }

        private void DeleteUserFromTeam()
        {
            try
            {
                var selectedUser = teamBuddyRepository.GetByUsername(User.Username);
                teamBuddyRepository.RemoveUserFromTeam(selectedUser, SelectedTeam.Id);
                mediator.Send(new ReloadTeamUsersMessage());
                User = null;
            }
            catch
            {
                messageBoxService.Show($"Please, fill the required field correctly!", "User addition failed", MessageBoxButton.OK);
            }
        }

        private void TeamSelected(TeamSelectedMessage selectedTeam)
        {
            SelectedTeam = teamBuddyRepository.GetByName(selectedTeam.Name);
        }

        private void AddNewUserToTeam()
        {
            try
            {
                var selectedUser = teamBuddyRepository.GetByUsername(User.Username);
                teamBuddyRepository.AddUserToTeam(selectedUser, SelectedTeam.Id);
                mediator.Send(new ReloadTeamUsersMessage());
                User = null;
            }
            catch
            {
                messageBoxService.Show($"Please, fill the required field correctly!", "User addition failed", MessageBoxButton.OK);
            }
        }

        private void HideUsersSettings()
        {
            User = null;
        }

        private void HideUsersSettings(UsersSettingsCancelMessage obj)
        {
            User = null;
        }

        private void UserSettingsSelected(UsersSettingsSelectedMessage obj)
        {
            mediator.Send(new CreateNewPostCancelMessage());
            mediator.Send(new CommentCreateCancelMessage());
            User = new UserListModel();
        }
    }
}
