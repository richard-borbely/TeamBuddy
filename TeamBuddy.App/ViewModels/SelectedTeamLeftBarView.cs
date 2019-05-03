using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TeamBuddy.App.Commands;
using TeamBuddy.BL.Messages;
using TeamBuddy.BL.Services;

namespace TeamBuddy.App.ViewModels
{
    public class SelectedTeamLeftBarView : ViewModelBase
    {
        private readonly IMediator mediator;

        public ICommand BackHomeCommand { get; set; }

        public SelectedTeamLeftBarView(IMediator mediator)
        {
            this.mediator = mediator;

            BackHomeCommand = new RelayCommand(BackHome);
        }

        private void BackHome()
        {
            mediator.Send(new BackHomeMessage());
        }
    }
}
