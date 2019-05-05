using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuddy.BL.Extensions;
using TeamBuddy.BL.Messages;
using TeamBuddy.BL.Models;
using TeamBuddy.BL.Repositories;
using TeamBuddy.BL.Services;
using TeamBuddy.DAL.Enumerations;

namespace TeamBuddy.App.ViewModels
{
    public class SelectedTeamPostListViewModel : ViewModelBase
    {
        private readonly IMediator mediator;
        private readonly ITeamBuddyRepository teamBuddyRepository;
        private ObservableCollection<PostDetailModel> _posts = new ObservableCollection<PostDetailModel>();

        public static UserDetailModel Author = new UserDetailModel()
        {
            Username = "xshoyg01",
            Name = "Sergey Shoygu",
            Password = "StrongRussia",
            Gender = Gender.Male,
            Email = "shoygu@duma.gov.ru"
        };

        private static TeamDetailModel SelectedTeam { get; set; }

        ////public ObservableCollection<PostDetailModel> Posts { get; set; } = new ObservableCollection<PostDetailModel>()
        ////{
        ////    new PostDetailModel
        ////    {
        ////        Title = "First Post Title",
        ////        Text = "He an thing rapid these after going drawn "+
        ////               "or. Timed she his law the spoil round "+
        ////               "defer. In surprise concerns informed betrayed"+
        ////               "he learning is ye.",
        ////        PostAdditionTime = DateTime.Now,
        ////        User = Author
        ////    },
        ////    new PostDetailModel
        ////    {
        ////        Title = "Second Post Title",
        ////        Text = "He an thing rapid these after going drawn "+
        ////               "or. Timed she his law the spoil round "+
        ////               "defer. In surprise concerns informed betrayed"+
        ////               "he learning is ye.",
        ////        PostAdditionTime = DateTime.Now,
        ////        User = Author
        ////    },
        ////    new PostDetailModel
        ////    {
        ////        Title = "Another post",
        ////        Text = "He an thing rapid these after going drawn "+
        ////               "or. Timed she his law the spoil round "+
        ////               "defer. In surprise concerns informed betrayed"+
        ////               "he learning is ye.",
        ////        PostAdditionTime = DateTime.Now,
        ////        User = Author
        ////    },
        ////    new PostDetailModel
        ////    {
        ////        Title = "Last Post",
        ////        Text = "He an thing rapid these after going drawn "+
        ////               "or. Timed she his law the spoil round "+
        ////               "defer. In surprise concerns informed betrayed"+
        ////               "he learning is ye.",
        ////        PostAdditionTime = DateTime.Now,
        ////        User = Author
        ////    }
        ////};

        public ObservableCollection<PostDetailModel> Posts
        {
            get => _posts;
            set
            {
                _posts = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CommentDetailModel> Comments { get; set; } = new ObservableCollection<CommentDetailModel>()
        {
            new CommentDetailModel
            {
                Text = "First comment text",
                CommentAdditionTime = DateTime.Now,
                User = Author
            },
            new CommentDetailModel
            {
                Text = "Second comment text",
                CommentAdditionTime = DateTime.Now,
                User = Author
            }
        };


        public SelectedTeamPostListViewModel(IMediator mediator, ITeamBuddyRepository teamBuddyRepository)
        {
            this.mediator = mediator;
            this.teamBuddyRepository = teamBuddyRepository;

            mediator.Register<TeamSelectedMessage>(LoadPosts);
            mediator.Register<ReloadTeamPostsMessage>(ReloadTeamPosts);
        }

        private void ReloadTeamPosts(ReloadTeamPostsMessage obj)
        {
            Posts.Clear();
            var posts = teamBuddyRepository.GetAllPostsInTeam(SelectedTeam.Id);
            Posts.AddRange(posts);
        }

        private void LoadPosts(TeamSelectedMessage selectedTeam)
        {
            SelectedTeam = teamBuddyRepository.GetByName(selectedTeam.Name);
            var posts = teamBuddyRepository.GetAllPostsInTeam(SelectedTeam.Id);
            Posts.AddRange(posts);
        }
    }
}
