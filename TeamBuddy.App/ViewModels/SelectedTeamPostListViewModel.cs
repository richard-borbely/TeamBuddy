using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuddy.BL.Models;
using TeamBuddy.BL.Services;
using TeamBuddy.DAL.Enumerations;

namespace TeamBuddy.App.ViewModels
{
    public class SelectedTeamPostListViewModel : ViewModelBase
    {
        private readonly IMediator mediator;

        public static UserDetailModel Author = new UserDetailModel()
        {
            Username = "xshoyg01",
            Name = "Sergey Shoygu",
            Password = "StrongRussia",
            Gender = Gender.Male,
            Email = "shoygu@duma.gov.ru"
        };

        public ObservableCollection<PostDetailModel> Posts { get; set; } = new ObservableCollection<PostDetailModel>()
        {
            new PostDetailModel
            {
                Title = "First Post Title",
                Text = "He an thing rapid these after going drawn "+
                       "or. Timed she his law the spoil round "+
                       "defer. In surprise concerns informed betrayed"+
                       "he learning is ye.",
                PostAdditionTime = DateTime.Now,
                User = Author
            },
            new PostDetailModel
            {
                Title = "Second Post Title",
                Text = "He an thing rapid these after going drawn "+
                       "or. Timed she his law the spoil round "+
                       "defer. In surprise concerns informed betrayed"+
                       "he learning is ye.",
                PostAdditionTime = DateTime.Now,
                User = Author
            },
            new PostDetailModel
            {
                Title = "Another post",
                Text = "He an thing rapid these after going drawn "+
                       "or. Timed she his law the spoil round "+
                       "defer. In surprise concerns informed betrayed"+
                       "he learning is ye.",
                PostAdditionTime = DateTime.Now,
                User = Author
            },
            new PostDetailModel
            {
                Title = "Last Post",
                Text = "He an thing rapid these after going drawn "+
                       "or. Timed she his law the spoil round "+
                       "defer. In surprise concerns informed betrayed"+
                       "he learning is ye.",
                PostAdditionTime = DateTime.Now,
                User = Author
            }
        };

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


        public SelectedTeamPostListViewModel(IMediator mediator)
        {
            this.mediator = mediator;

        }



    }
}
