using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TeamBuddy.App.Commands;
using TeamBuddy.App.Services;
using TeamBuddy.BL.Messages;
using TeamBuddy.BL.Models;
using TeamBuddy.BL.Repositories;
using TeamBuddy.BL.Services;

namespace TeamBuddy.App.ViewModels
{
    public class SelectedTeamCreatePostViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private readonly ITeamBuddyRepository teamBuddyRepository;
        private readonly IMessageBoxService messageBoxService;
        private PostDetailModel _newPost;

        public PostDetailModel NewPost
        {
            get => _newPost;
            set
            {
                _newPost = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreatePostCancelCommand { get; set; }

        public SelectedTeamCreatePostViewModel(IMediator mediator, ITeamBuddyRepository teamBuddyRepository, IMessageBoxService messageBoxService)
        {
            this.mediator = mediator;
            this.teamBuddyRepository = teamBuddyRepository;
            this.messageBoxService = messageBoxService;

            CreatePostCancelCommand = new RelayCommand(HideCreateNewPost);

            mediator.Register<CreateNewPostSelectedMessage>(CreateNewPostSelected);
            mediator.Register<CreateNewPostCancelMessage>(HideCreateNewPost);
        }

        private void HideCreateNewPost()
        {
            NewPost = null;
        }

        private void HideCreateNewPost(CreateNewPostCancelMessage obj)
        {
            NewPost = null;
        }

        private void CreateNewPostSelected(CreateNewPostSelectedMessage obj)
        {
            mediator.Send(new UsersSettingsCancelMessage());
            NewPost = new PostDetailModel();
        }
    }
}
