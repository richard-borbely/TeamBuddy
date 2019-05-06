using System.Windows.Input;
using TeamBuddy.App.Commands;
using TeamBuddy.BL.Messages;
using TeamBuddy.BL.Services;

namespace TeamBuddy.App.ViewModels
{
    public class SelectedTeamLeftBarViewModel : ViewModelBase
    {
        private readonly IMediator mediator;

        public ICommand BackHomeCommand { get; set; }
        public ICommand CreateNewPostSelectedCommand { get; set; }
        public ICommand UsersSettingsSelectedCommand { get; set; }

        public SelectedTeamLeftBarViewModel(IMediator mediator)
        {
            this.mediator = mediator;

            BackHomeCommand = new RelayCommand(BackHome);
            CreateNewPostSelectedCommand = new RelayCommand(CreateNewPostSelected);
            UsersSettingsSelectedCommand = new RelayCommand(UsersSettingsSelected);
        }

        private void UsersSettingsSelected()
        {
            mediator.Send(new UsersSettingsSelectedMessage());
        }

        private void CreateNewPostSelected()
        {
            mediator.Send(new CreateNewPostSelectedMessage());
        }

        private void BackHome()
        {
            mediator.Send(new BackHomeMessage());
            mediator.Send(new UsersSettingsCancelMessage());
            mediator.Send(new CreateNewPostCancelMessage());
        }
    }
}
