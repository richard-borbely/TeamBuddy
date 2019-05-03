using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamBuddy.BL.Mapper;
using TeamBuddy.BL.Models;
using TeamBuddy.BL.Repositories;
using TeamBuddy.DAL.Enumerations;
using TeamBuddy.DAL.Tests;
using Xunit;


namespace TeamBuddy.BL.Tests
{
    public class TeamBuddyRepositoryTests
    {
        private readonly IMapper _mapper = new Mapper.Mapper();

        [Fact]
        public void GetAllTeams_WithNeededData_ReturnsCollectionOfTeams()
        {
            //Arrange
            var sut = CreateSUT();
            var modelTeam1 = new TeamDetailModel
            {
                Name = "ICS project 2019",
                Description = "This team is dedicated for users, " +
                              "who are working on ICS projects."
            };
            var modelTeam2 = new TeamDetailModel
            {
                Name = "IFJ project 2019",
                Description = "This team is dedicated for users, " +
                              "who are working on IFJ projects."
            };
            sut.Create(modelTeam1);
            sut.Create(modelTeam2);
            
            //Act
            var allTeamsModel = sut.GetAllTeams();

            //Assert
            Assert.Equal(2,allTeamsModel.ToList().Count);
        }

        [Fact]
        public void GetAllUsers_WithNeededData_ReturnsCollectionOfUsers()
        {
            //Arrange
            var sut = CreateSUT();
            var modelUser1 = new UserDetailModel
            {
                Username = "xorlov00",
                Name = "Dimitrij Orlov",
                Password = "StrongPass13",
                Gender = Gender.Male,
                Email = "dima.orlov@vk.com"
            };
            var modelUser2 = new UserDetailModel
            {
                Username = "xshoyg01",
                Name = "Sergey Shoygu",
                Password = "StrongRussia",
                Gender = Gender.Male,
                Email = "shoygu@duma.gov.ru"
            };
            sut.Create(modelUser1);
            sut.Create(modelUser2);

            //Act
            var allUsersModel = sut.GetAllUsers();

            //Assert
            Assert.NotNull(allUsersModel.ToList());
        }

        [Fact]
        public void GetAllPosts_WithNeededData_ReturnsCollectionOfPosts()
        {
            //Arrange
            var sut = CreateSUT();
            var modelUser = new UserDetailModel
            {
                Username = "xshoyg01",
                Name = "Sergey Shoygu",
                Password = "StrongRussia",
                Gender = Gender.Male,
                Email = "shoygu@duma.gov.ru"
            };
            var modelPost1 = new PostDetailModel()
            {
                Title = "The first post in this Team!",
                Text = "Some post text.",
                PostAdditionTime = DateTime.Now,
                User = modelUser
            };
            var modelPost2 = new PostDetailModel()
            {
                Title = "The Second post in this Team!",
                Text = "Some post text.",
                PostAdditionTime = DateTime.Now,
                User = modelUser
            };
            sut.Create(modelUser);
            sut.Create(modelPost1);
            sut.Create(modelPost2);

            //Act
            var allPostsModel = sut.GetAllPosts();

            //Assert
            Assert.Equal(2, allPostsModel.ToList().Count);
        }

        [Fact]
        public void GetAllComments_WithNeededData_ReturnsCollectionOfComments()
        {
            //Arrange
            var sut = CreateSUT();
            var modelComment1 = new CommentDetailModel()
            {
                Text = "Some comment1 text.",
                CommentAdditionTime = DateTime.Now,
                User = new UserDetailModel
                {
                    Username = "xorlov00",
                    Name = "Dimitrij Orlov",
                    Password = "StrongPass13",
                    Gender = Gender.Male,
                    Email = "dima.orlov@vk.com"
                }
            };
            var modelComment2 = new CommentDetailModel()
            {
                Text = "Some comment2 text.",
                CommentAdditionTime = DateTime.Now,
                User = new UserDetailModel
                {
                    Username = "xlavro00",
                    Name = "Sergey Lavrov",
                    Password = "StrongRussia42",
                    Gender = Gender.Male,
                    Email = "lavrov@duma.gov.ru"
                }
            };
            sut.Create(modelComment1);
            sut.Create(modelComment2);

            //Act
            var allCommentsModel = sut.GetAllComments();

            //Assert
            Assert.Equal(2,allCommentsModel.ToList().Count);
        }

        [Fact]
        public void FindTeamByName_ExistingItem_ReturnsItsModel()
        {
            //Arrange
            var sut = CreateSUT();
            var model = new TeamDetailModel
            {
                Name = "ICS project 2019",
                Description = "This team is dedicated for users, " +
                              "who are working on ICS projects."
            };
            var createdModel = sut.Create(model);
            try
            {
                //Act
                var foundModel = sut.GetByName(createdModel.Name);

                //Assert
                Assert.NotNull(foundModel);
            }
            finally
            {
                //Teardown
                sut.DeleteTeam(createdModel.Id);
            }
        }

        [Fact]
        public void FindUserByUsername_ExistingItem_ReturnsItsModel()
        {
            //Arrange
            var sut = CreateSUT();
            var model = new UserDetailModel
            {
                Username = "xorlov00",
                Name = "Dimitrij Orlov",
                Password = "StrongPass13",
                Gender = Gender.Male,
                Email = "dima.orlov@vk.com"
            };
            var createdModel = sut.Create(model);
            try
            {
                //Act
                var foundModel = sut.GetByUsername(createdModel.Username);

                //Assert
                Assert.NotNull(foundModel);
            }
            finally
            {
                //Teardown
                sut.DeleteUser(createdModel.Id);
            }
        }

        [Fact]
        public void FindUserByEmail_ExistingItem_ReturnsItsModel()
        {
            //Arrange
            var sut = CreateSUT();
            var model = new UserDetailModel
            {
                Username = "xshoyg01",
                Name = "Sergey Shoygu",
                Password = "StrongRussia",
                Gender = Gender.Male,
                Email = "shoygu@duma.gov.ru"
            };
            var createdModel = sut.Create(model);
            try
            {
                //Act
                var foundModel = sut.GetByEmail(createdModel.Email);

                //Assert
                Assert.NotNull(foundModel);
            }
            finally
            {
                //Teardown
                sut.DeleteUser(createdModel.Id);
            }
        }

        [Fact]
        public void CreateTeam_WithValidData_ReturnsCreatedTeam()
        {
            //Arrange
            var sut = CreateSUT();
            var model = new TeamDetailModel
            {
                Name = "IFJ projects",
                Description = "This team is dedicated for users, " +
                              "who are working on IFJ projects."
            };

            TeamDetailModel createdModel = null;
            try
            {
                //Act
                createdModel = sut.Create(model);

                //Assert
                Assert.NotNull(createdModel);
            }
            finally
            {
                //Teardown
                if (createdModel != null)
                {
                    sut.DeleteTeam(createdModel.Id);
                }
            }
        }

        [Fact]
        public void CreateUser_WithValidData_ReturnsCreatedUser()
        {
            //Arrange
            var sut = CreateSUT();
            var model = new UserDetailModel()
            {
                Username = "xlavro00",
                Name = "Sergey Lavrov",
                Password = "StrongRussia42",
                Gender = Gender.Male,
                Email = "lavrov@duma.gov.ru"
            };

            UserDetailModel createdModel = null;
            try
            {
                //Act
                createdModel = sut.Create(model);

                //Assert
                Assert.NotNull(createdModel);
            }
            finally
            {
                //Teardown
                if (createdModel != null)
                {
                    sut.DeleteUser(createdModel.Id);
                }
            }
        }

        [Fact]
        public void CreatePost_WithValidData_ReturnsCreatedPost()
        {
            //Arrange
            var sut = CreateSUT();
            var model = new PostDetailModel()
            {
                Title = "The first post in this Team!",
                Text = "Some post text.",
                PostAdditionTime = DateTime.Now,
                User = new UserDetailModel
                {
                    Username = "xshoyg01",
                    Name = "Sergey Shoygu",
                    Password = "StrongRussia",
                    Gender = Gender.Male,
                    Email = "shoygu@duma.gov.ru"
                }
            };

            PostDetailModel createdModel = null;
            try
            {
                //Act
                createdModel = sut.Create(model);

                //Assert
                Assert.NotNull(createdModel);
            }
            finally
            {
                //Teardown
                if (createdModel != null)
                {
                    sut.DeletePost(createdModel.Id);
                }
            }
        }

        [Fact]
        public void CreateComment_WithValidData_ReturnsCreatedComment()
        {
            //Arrange
            var sut = CreateSUT();
            var model = new CommentDetailModel()
            {
                Text = "Some comment text.",
                CommentAdditionTime = DateTime.Now,
                User = new UserDetailModel
                {
                    Username = "xlavro00",
                    Name = "Sergey Lavrov",
                    Password = "StrongRussia42",
                    Gender = Gender.Male,
                    Email = "lavrov@duma.gov.ru"
                }
            };

            CommentDetailModel createdModel = null;
            try
            {
                //Act
                createdModel = sut.Create(model);

                //Assert
                Assert.NotNull(createdModel);
            }
            finally
            {
                //Teardown
                if (createdModel != null)
                {
                    sut.DeleteComment(createdModel.Id);
                }
            }
        }

        [Fact]
        public void AddUser_WithValidData_AddsUserToTeam()
        {
            //Arrange
            var sut = CreateSUT();
            var userModel = new UserDetailModel()
            {
                Username = "xlavro00",
                Name = "Sergey Lavrov",
                Password = "StrongRussia42",
                Gender = Gender.Male,
                Email = "lavrov@duma.gov.ru"
            };
            var teamModel = new TeamDetailModel()
            {
                Name = "IFJ projects",
                Description = "This team is dedicated for users, " +
                              "who are working on IFJ projects."
            };

            var createdTeamModel = sut.Create(teamModel);
            var teamEntity = _mapper.MapTeamToEntity(createdTeamModel);
            try
            {
                //Act
                sut.AddUserToTeam(userModel, createdTeamModel.Id);

                //Assert
                Assert.Equal(0,teamEntity.UserInTeam.Count);
            }
            finally
            {
                //Teardown
                if (createdTeamModel != null)
                {
                    sut.DeleteTeam(createdTeamModel.Id);
                }
            }
        }

        [Fact]
        public void UpdateUser_WithValidData_ChangesUsersProperty()
        {
            //Arrange
            var sut = CreateSUT();
            var model = new UserDetailModel()
            {
                Username = "xlavro00",
                Name = "Sergey Lavrov",
                Password = "StrongRussia42",
                Gender = Gender.Male,
                Email = "lavrov@duma.gov.ru",
                Status = Status.Online
            };

            var createdModel = sut.Create(model);
            try
            {
                //Act
                createdModel.Status = Status.DoNotDisturb;
                sut.UpdateUser(createdModel);

                //Assert
                Assert.Equal(Status.DoNotDisturb, createdModel.Status);
            }
            finally
            {
                //Teardown
                if (createdModel != null)
                {
                    sut.DeleteUser(createdModel.Id);
                }
            }
        }

        [Fact]
        public void RemoveUser_ExistingItem_RemovesUser()
        {
            //Arrange
            var sut = CreateSUT();
            var model = new UserDetailModel
            {
                Username = "xmedved00",
                Name = "Dmitry Medvedev",
                Password = "StrongRussiaNo1",
                Gender = Gender.Male,
                Email = "medved@duma.gov.ru",
                Status = Status.DoNotDisturb
            };
            var createdModel = sut.Create(model);

            //Act
            sut.DeleteUser(createdModel.Id);

            //Assert
            Assert.Null(sut.GetByEmail(createdModel.Email));
        }

        [Fact]
        public void RemoveTeam_ExistingItem_RemovesTeam()
        {
            //Arrange
            var sut = CreateSUT();
            var model = new TeamDetailModel
            {
                Name = "IFJ projects",
                Description = "This team is dedicated for users, " +
                              "who are working on IFJ projects."
            };
            var createdModel = sut.Create(model);

            //Act
            sut.DeleteTeam(createdModel.Id);

            //Assert
            Assert.Null(sut.GetByEmail(createdModel.Name));
        }

        private ITeamBuddyRepository CreateSUT()
        {
            return new TeamBuddyRepository(new InMemoryDbContextFactory(), _mapper);
        }
    }
}
