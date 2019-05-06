using System;
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

        private TeamDetailModel SelectedTeam { get; set; }
        private UserDetailModel SignedUser { get; set; }

        public ICommand CreatePostCommand { get; set; }
        public ICommand CreatePostCancelCommand { get; set; }

        public SelectedTeamCreatePostViewModel(IMediator mediator, ITeamBuddyRepository teamBuddyRepository, IMessageBoxService messageBoxService)
        {
            this.mediator = mediator;
            this.teamBuddyRepository = teamBuddyRepository;
            this.messageBoxService = messageBoxService;

            CreatePostCommand = new RelayCommand(CreatePost);
            CreatePostCancelCommand = new RelayCommand(HideCreateNewPost);

            mediator.Register<TeamSelectedMessage>(TeamSelected);
            mediator.Register<LogInMessage>(SigndUser);
            mediator.Register<CreateNewPostSelectedMessage>(CreateNewPostSelected);
            mediator.Register<CreateNewPostCancelMessage>(HideCreateNewPost);
        }

        private void SigndUser(LogInMessage signedUser)
        {
            SignedUser = signedUser.SignedUser;
        }

        private void TeamSelected(TeamSelectedMessage selectedTeam)
        {
            SelectedTeam = teamBuddyRepository.GetByName(selectedTeam.Name);
        }

        private void CreatePost()
        {
            try
            {
                NewPost.Team = SelectedTeam;
                NewPost.User = SignedUser;
                NewPost.PostAdditionTime = DateTime.Now;
                teamBuddyRepository.Create(NewPost, SelectedTeam.Id);
                NewPost = null;
            }
            catch
            {
                messageBoxService.Show($"Please, fill in the required fields!", "Post creation failed", MessageBoxButton.OK);
            }
            finally
            {
                mediator.Send(new ReloadTeamPostsMessage());
            }
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
            mediator.Send(new CommentCreateCancelMessage());
            NewPost = new PostDetailModel();
        }
    }
}
