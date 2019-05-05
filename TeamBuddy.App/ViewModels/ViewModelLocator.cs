using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuddy.App.Services;
using TeamBuddy.App.Views;
using TeamBuddy.BL.Mapper;
using TeamBuddy.BL.Repositories;
using TeamBuddy.BL.Services;
using TeamBuddy.DAL;

namespace TeamBuddy.App.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IMediator mediator;
        private readonly IDbContextFactory dbContextFactory;
        private readonly IMapper _mapper = new Mapper();
        private readonly ITeamBuddyRepository teamBuddyRepository;
        private readonly IMessageBoxService messageBoxService;

        public LogInViewModel LogInViewModel => new LogInViewModel(mediator, teamBuddyRepository, messageBoxService);
        public HomeViewModel HomeViewModel => new HomeViewModel(mediator);
        public HomeUserDetailViewModel HomeUserDetailViewModel => new HomeUserDetailViewModel(mediator, teamBuddyRepository, messageBoxService);
        public HomeTeamListViewModel HomeTeamListViewModel => new HomeTeamListViewModel(mediator, teamBuddyRepository);
        public HomeCreateUserViewModel HomeCreateUserViewModel => new HomeCreateUserViewModel(mediator, teamBuddyRepository, messageBoxService);
        public HomeCreateTeamViewModel HomeCreateTeamViewModel => new HomeCreateTeamViewModel(mediator, teamBuddyRepository, messageBoxService);
        public SelectedTeamViewModel SelectedTeamViewModel => new SelectedTeamViewModel(mediator);
        public SelectedTeamLeftBarViewModel SelectedTeamLeftBarViewModel => new SelectedTeamLeftBarViewModel(mediator);
        public SelectedTeamDetailViewModel SelectedTeamDetailViewModel => new SelectedTeamDetailViewModel(mediator, teamBuddyRepository);
        public SelectedTeamPostListViewModel SelectedTeamPostListViewModel =>new SelectedTeamPostListViewModel(mediator);
        public SelectedTeamUserDetailViewModel SelectedTeamUserDetailViewModel => new SelectedTeamUserDetailViewModel(mediator, teamBuddyRepository);
        public ViewModelLocator()
        {
            mediator = new Mediator();
            dbContextFactory = new DefaultDbContextFactory();
            teamBuddyRepository = new TeamBuddyRepository(dbContextFactory, _mapper);
            messageBoxService = new MessageBoxService();
        }
    }
}
