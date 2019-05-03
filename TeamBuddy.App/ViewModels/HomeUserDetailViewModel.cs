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
using TeamBuddy.DAL.Enumerations;

namespace TeamBuddy.App.ViewModels
{
    public class HomeUserDetailViewModel : ViewModelBase
    {
        private readonly IMediator mediator;

        public UserDetailModel User { get; set; } = new UserDetailModel()
        {
            Email = "xborbe00@stud.fit.vutbr.cz",
            Username = "xborbe00",
            Name = "Richard Borbély",
            Gender = Gender.Male
        };

        public ICommand CreateNewUserSelectedCommand { get; set; }
        public ICommand CreateNewTeamSelectedCommand { get; set; }

        public HomeUserDetailViewModel(IMediator mediator)
        {
            this.mediator = mediator;

            CreateNewUserSelectedCommand = new RelayCommand(CreateNewUserSelected);
            CreateNewTeamSelectedCommand = new RelayCommand(CreateNewTeamSelected);
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
