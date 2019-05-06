using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TeamBuddy.App.Commands;
using TeamBuddy.BL.Extensions;
using TeamBuddy.BL.Messages;
using TeamBuddy.BL.Models;
using TeamBuddy.BL.Repositories;
using TeamBuddy.BL.Services;

namespace TeamBuddy.App.ViewModels
{
    public class SelectedTeamPostListViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private readonly ITeamBuddyRepository teamBuddyRepository;
        private ObservableCollection<PostDetailModel> _posts = new ObservableCollection<PostDetailModel>();
        private ObservableCollection<CommentDetailModel> _comments = new ObservableCollection<CommentDetailModel>();

        private static TeamDetailModel SelectedTeam { get; set; }

        public ObservableCollection<PostDetailModel> Posts
        {
            get => _posts;
            set
            {
                _posts = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CommentDetailModel> Comments
        {
            get => _comments;
            set
            {
                _comments = value;
                OnPropertyChanged();
            }
        }
        //public ObservableCollection<CommentDetailModel> Comments { get; set; } = new ObservableCollection<CommentDetailModel>()
        //{
        //    new CommentDetailModel
        //    {
        //        Text = "First comment text",
        //        CommentAdditionTime = DateTime.Now,
        //        User = Author
        //    },
        //    new CommentDetailModel
        //    {
        //        Text = "Second comment text",
        //        CommentAdditionTime = DateTime.Now,
        //        User = Author
        //    }
        //};

        public ICommand ShowAuthorCommand { get; set; }
        public ICommand ShowCommentsCommand { get; set; }
        public ICommand AddCommentCommand { get; set; }
        public ICommand DeletePostCommand { get; set; }

        public SelectedTeamPostListViewModel(IMediator mediator, ITeamBuddyRepository teamBuddyRepository)
        {
            this.mediator = mediator;
            this.teamBuddyRepository = teamBuddyRepository;

            ShowAuthorCommand = new RelayCommand(ShowAuthor);
            ShowCommentsCommand = new RelayCommand(ShowComments);
            AddCommentCommand = new RelayCommand(AddComment);
            DeletePostCommand = new RelayCommand(DeletePost);

            mediator.Register<TeamSelectedMessage>(LoadPosts);
            mediator.Register<ReloadTeamPostsMessage>(ReloadTeamPosts);
        }

        private void DeletePost(object SelectedPostId)
        {
            teamBuddyRepository.DeletePost((Guid)SelectedPostId);
            mediator.Send(new ReloadTeamPostsMessage());
        }

        private void AddComment(object SelectedPostId)
        {
            mediator.Send(new CreateNewCommentMessage{ Id = (Guid)SelectedPostId });
        }

        private void ShowComments(Object SelectedPostId)
        {
            Comments.Clear();
            var comments = teamBuddyRepository.GetAllCommentsInPost((Guid)SelectedPostId);
            Comments.AddRange(comments);
        }

        private void ShowAuthor(Object SelectedUsersUsername)
        {
            mediator.Send(new UserSelectedMessage { Username = SelectedUsersUsername.ToString() });
        }

        private void ReloadTeamPosts(ReloadTeamPostsMessage obj)
        {
            Posts.Clear();
            var posts = teamBuddyRepository.GetAllPostsInTeam(SelectedTeam.Id);
            Posts.AddRange(posts);
        }

        private void LoadPosts(TeamSelectedMessage selectedTeam)
        {
            Posts.Clear();
            SelectedTeam = teamBuddyRepository.GetByName(selectedTeam.Name);
            var posts = teamBuddyRepository.GetAllPostsInTeam(SelectedTeam.Id);
            Posts.AddRange(posts);
        }
    }
}
