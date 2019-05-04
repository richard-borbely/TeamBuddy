using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuddy.BL.Messages;
using TeamBuddy.BL.Models;
using TeamBuddy.BL.Repositories;
using TeamBuddy.BL.Services;

namespace TeamBuddy.App.ViewModels
{
    public class SelectedTeamUserDetailViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private readonly ITeamBuddyRepository teamBuddyRepository;
        private UserDetailModel _selectedUser;

        public UserDetailModel SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        public SelectedTeamUserDetailViewModel(IMediator mediator, ITeamBuddyRepository teamBuddyRepository)
        {
            this.mediator = mediator;
            this.teamBuddyRepository = teamBuddyRepository;

            mediator.Register<UserSelectedMessage>(UserSelected);
            mediator.Register<BackHomeMessage>(HideSelectedUser);
        }

        private void HideSelectedUser(BackHomeMessage obj)
        {
            SelectedUser = null;
        }

        private void UserSelected(UserSelectedMessage selectedUser)
        {
            SelectedUser = teamBuddyRepository.GetByUsername(selectedUser.Username);
        }
    }
}
