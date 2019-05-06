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
    public class SelectedTeamCreateCommentViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private readonly ITeamBuddyRepository teamBuddyRepository;
        private readonly IMessageBoxService messageBoxService;
        private CommentDetailModel _newComment;

        public CommentDetailModel NewComment
        {
            get => _newComment;
            set
            {
                _newComment = value; 
                OnPropertyChanged();
            }
        }

        private UserDetailModel SignedUser { get; set; }
        private Guid PostId { get; set; }

        public ICommand CreateCommentCancelCommand { get; set; }
        public ICommand CreateCommentCommand { get; set; }

        public SelectedTeamCreateCommentViewModel(IMediator mediator, ITeamBuddyRepository teamBuddyRepository, IMessageBoxService messageBoxService)
        {
            this.mediator = mediator;
            this.teamBuddyRepository = teamBuddyRepository;
            this.messageBoxService = messageBoxService;

            CreateCommentCancelCommand = new RelayCommand(CreateCommentCancel);
            CreateCommentCommand = new RelayCommand(CreateComment);

            mediator.Register<CreateNewCommentMessage>(CreateNewCommentSelected);
            mediator.Register<CommentCreateCancelMessage>(HideCommentCreate);
            mediator.Register<LogInMessage>(SigndUser);
        }

        private void SigndUser(LogInMessage signedUser)
        {
            SignedUser = signedUser.SignedUser;
        }

        private void CreateComment()
        {
            try
            {
                NewComment.User = SignedUser;
                PostDetailModel post = teamBuddyRepository.GetPostById(PostId);
                NewComment.Post = post;
                NewComment.CommentAdditionTime = DateTime.Now;
                teamBuddyRepository.Create(NewComment);
                NewComment = null;
            }
            catch
            {
                messageBoxService.Show($"Please, fill in the required fields!", "Comment creation failed", MessageBoxButton.OK);
            }
        }

        private void HideCommentCreate(CommentCreateCancelMessage obj)
        {
            NewComment = null;
        }

        private void CreateCommentCancel()
        {
            NewComment = null;
        }

        private void CreateNewCommentSelected(CreateNewCommentMessage selectedPost)
        {
            mediator.Send(new CreateNewPostCancelMessage());
            mediator.Send(new UsersSettingsCancelMessage());
            NewComment = new CommentDetailModel();
            PostId = selectedPost.Id;
        }
    }
}
