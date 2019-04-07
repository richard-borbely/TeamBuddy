using System;
using System.Collections.Generic;
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
                Passwd = "StrongPass13",
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
                Passwd = "StrongRussia",
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
                Passwd = "StrongRussia42",
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
                    Passwd = "StrongRussia",
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
                    Passwd = "StrongRussia42",
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

        


        private ITeamBuddyRepository CreateSUT()
        {
            return new TeamBuddyRepository(new InMemoryDbContextFactory(), new Mapper.Mapper());
        }
    }
}
