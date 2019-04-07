using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TeamBuddy.DAL.Entities;
using TeamBuddy.DAL.Enumerations;


namespace TeamBuddy.DAL.Tests
{
    public class TeamBuddyDbContextTests
    {
        private readonly IDbContextFactory _dbContextFactory;

        public TeamBuddyDbContextTests()
        {
            _dbContextFactory = new InMemoryDbContextFactory();
        }

        [Fact]
        public void CreateUserTest()
        {
            //Arrange
            var user = new User
            {
                Name = "Dimitrij Orlov",
                Gender = Gender.Male,
                Email = "orlov.dima@gmail.com",
                Status = Status.Offline
            };

            //Act
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }

            //Assert
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                User retrievedUser = null;
                try
                {
                    retrievedUser = dbContext.Users.First(u => u.Id == user.Id);
                    Assert.NotNull(retrievedUser);
                }
                finally
                {
                    //Teardown
                    if (retrievedUser != null)
                    {
                        dbContext.Users.Remove(retrievedUser);
                    }
                }
            }
        }

        [Fact]
        public void RemoveUserTest()
        {
            //Arrange
            var team = new Team
            {
                Name = "TeamBuddy",
                Description = "The first team of this app."
            };
            var user = new User
            {
                Name = "Alexander Ovechkin",
                Passwd = "veryStrongPass13",
                Gender = Gender.Male,
                Email = "ovechkin.alex@gmail.com",
                Status = Status.Offline,
            };
            var comment = new Comment
            {
                Text = "Hello World! This is just testing comment.",
                CommentAdditionTime = DateTime.Now,
                User = user
            };
            var post = new Post
            {
                Title = "Our First Post",
                Text = "Hello World! This is just testing post.",
                PostAdditionTime = DateTime.Now,
                User = user,
                Team = team

            };

            //Act
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Users.Add(user);
                dbContext.Teams.Add(team);
                dbContext.Comments.Add(comment);
                dbContext.Posts.Add(post);
                dbContext.SaveChanges();
            }

            //Act
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }

            //Assert
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                User retrievedUser = null;
                try
                {
                    retrievedUser = dbContext.Users.FirstOrDefault(u => u.Id == post.Id);
                    Assert.Null(retrievedUser);
                    Assert.Null(post.User);
                    Assert.Null(comment.User);
                }
                finally
                {
                    //Teardown
                    if (retrievedUser != null)
                    {
                        dbContext.Users.Remove(retrievedUser);
                    }
                }
            }
        }

        [Fact]
        public void CreateTeamTest()
        {
            //Arrange
            var team = new Team
            {
                Name = "TeamBuddy",
                Description = "The first team of this app."
            };

            //Act
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Teams.Add(team);
                dbContext.SaveChanges();
            }

            //Assert
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                Team retrievedTeam = null;
                try
                {
                    retrievedTeam = dbContext.Teams.First(t => t.Id == team.Id);
                    Assert.NotNull(retrievedTeam);
                }
                finally
                {
                    //Teardown
                    if (retrievedTeam != null)
                    {
                        dbContext.Teams.Remove(retrievedTeam);
                    }
                }
            }
        }

        [Fact]
        public void RemoveTeamTest()
        {
            //Arrange
            var user = new User
            {
                Name = "Dimitrij Orlov",
                Gender = Gender.Male,
                Email = "orlov.dima@gmail.com",
                Status = Status.Offline
            };
            var team = new Team
            {
                Name = "TeamBuddy",
                Description = "The first team of this app."
            };
            var post1 = new Post
            {
                Title = "Our First Post",
                Text = "Hello World! This is just testing post.",
                PostAdditionTime = DateTime.Now,
                User = user,
                Team = team
            };
            var post2 = new Post
            {
                Title = "Our First Post",
                Text = "Hello World! This is just testing post.",
                PostAdditionTime = DateTime.Now,
                User = user,
                Team = team
            };
            var post3 = new Post
            {
                Title = "Our First Post",
                Text = "Hello World! This is just testing post.",
                PostAdditionTime = DateTime.Now,
                User = user,
                Team = team
            };
            var comment1 = new Comment
            {
                Text = "Hello World! This is just testing comment.",
                CommentAdditionTime = DateTime.Now,
                User = user,
                Post = post1
            };
            var comment2 = new Comment
            {
                Text = "Hello World! This is just testing Second comment.",
                CommentAdditionTime = DateTime.Now,
                User = user,
                Post = post1
            };
            var comment3 = new Comment
            {
                Text = "Hello World! This is just testing comment.",
                CommentAdditionTime = DateTime.Now,
                User = user,
                Post = post1
            };
            var comment4 = new Comment
            {
                Text = "Hello World! This is just testing Second comment.",
                CommentAdditionTime = DateTime.Now,
                User = user,
                Post = post2
            };

            //Act
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Users.Add(user);
                dbContext.Posts.Add(post1);
                dbContext.Posts.Add(post2);
                dbContext.Posts.Add(post3);
                dbContext.Comments.Add(comment1);
                dbContext.Comments.Add(comment2);
                dbContext.Comments.Add(comment3);
                dbContext.Comments.Add(comment4);
                dbContext.Teams.Add(team);
                dbContext.SaveChanges();
            }

            //Act
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Teams.Remove(team);
                dbContext.SaveChanges();
            }

            //Assert
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                Team retrievedTeam = null;
                try
                {
                    retrievedTeam = dbContext.Teams.FirstOrDefault(t => t.Id == team.Id);
                    Assert.Null(retrievedTeam);
                    Assert.Equal(0, user.Posts.Count);
                    Assert.Equal(0, user.Comments.Count);
                }
                finally
                {
                    //Teardown
                    if (retrievedTeam != null)
                    {
                        dbContext.Teams.Remove(retrievedTeam);
                    }
                }
            }
        }

        [Fact]
        public void CreatePostTest()
        {
            //Arrange
            var post = new Post
            {
                Title = "Our First Post",
                Text = "Hello World! This is just testing post.",
                PostAdditionTime = DateTime.Now,
                User = new User
                {
                    Name = "Dimitrij Orlov",
                    Gender = Gender.Male,
                    Email = "orlov.dima@gmail.com",
                    Status = Status.Offline
                },
                Team = new Team
                {
                    Name = "TeamBuddy",
                    Description = "The first team of this app."
                }
            };

            //Act
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Posts.Add(post);
                dbContext.SaveChanges();
            }

            //Assert
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                Post retrievedPost = null;
                try
                {
                    retrievedPost = dbContext.Posts
                        .Include(u => u.User)
                        .Include(t => t.Team)
                        .First(p => p.Id == post.Id);
                    Assert.NotNull(retrievedPost);
                    Assert.NotNull(retrievedPost.User);
                    Assert.NotNull(retrievedPost.Team);
                    var retrievedUser = dbContext.Users.First(u => u.Id == post.User.Id);
                    Assert.NotNull(retrievedUser);
                    var retrievedTeam = dbContext.Teams.First(t => t.Id == post.Team.Id);
                    Assert.NotNull(retrievedTeam);
                }
                finally
                {
                    //Teardown
                    if (retrievedPost != null)
                    {
                        dbContext.Posts.Remove(retrievedPost);
                    }
                }
            }
        }

        [Fact]
        void RemovePostTest()
        {
            //Arrange
            var user1 = new User
            {
                Name = "Dimitrij Orlov",
                Gender = Gender.Male,
                Email = "orlov.dima@gmail.com",
                Status = Status.Offline
            };
            var user2 = new User
            {
                Name = "Alexander Ovechkin",
                Gender = Gender.Male,
                Email = "ovechkin.alex@gmail.com",
                Status = Status.Offline
            };
            var team = new Team
            {
                Name = "TeamBuddy",
                Description = "The first team of this app."
            };
            var comment = new Comment
            {
                Text = "Hello World! This is just testing comment.",
                CommentAdditionTime = DateTime.Now,
                User = user2

            };
            var post = new Post
            {
                Title = "Our First Post",
                Text = "Hello World! This is just testing post.",
                PostAdditionTime = DateTime.Now,
                Comments = new List<Comment> {comment},
                Team = team,
                User = user1
            };
            
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                
                dbContext.Users.Add(user1);
                dbContext.Users.Add(user2);
                dbContext.Teams.Add(team);
                dbContext.Comments.Add(comment);
                dbContext.Posts.Add(post);
                dbContext.SaveChanges();
            }

            //Act
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Posts.Remove(post);
                dbContext.SaveChanges();
            }

            //Assert
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                Post retrievedPost = null;
                try
                {
                retrievedPost = dbContext.Posts.FirstOrDefault(p => p.Id == post.Id);
                Assert.Null(retrievedPost);
                var retrievedComment = dbContext.Comments.FirstOrDefault(c => c.Id == user2.Id);
                Assert.Null(retrievedComment);
                var retrievedUser = dbContext.Users.FirstOrDefault(u => u.Id == user1.Id);
                Assert.NotNull(retrievedUser);
                var retrievedTeam = dbContext.Teams.FirstOrDefault(t => t.Id == team.Id);
                Assert.NotNull(retrievedTeam);
                }
                finally
                {
                    //Teardown
                    if (retrievedPost != null)
                    {
                        dbContext.Posts.Remove(retrievedPost);
                    }
                }
            }
        }

        [Fact]
        public void CreateCommentTest()
        {
            //Arrange
            var comment = new Comment
            {
                Text = "Hello World! This is just testing comment.",
                CommentAdditionTime = DateTime.Now,
                User = new User
                {
                    Name = "Dimitrij Orlov",
                    Gender = Gender.Male,
                    Email = "orlov.dima@gmail.com",
                    Status = Status.Offline
                },
                Post = new Post
                {
                    Title = "Our First Post",
                    Text = "Hello World! This is just testing post.",
                    PostAdditionTime = DateTime.Now,
                    User = new User
                    {
                        Name = "Dimitrij Orlov",
                        Gender = Gender.Male,
                        Email = "orlov.dima@gmail.com",
                        Status = Status.Offline
                    },
                    Team = new Team
                    {
                        Name = "TeamBuddy",
                        Description = "The first team of this app."
                    }
                }
            };

            //Act
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Comments.Add(comment);
                dbContext.SaveChanges();
            }

            //Assert
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                Comment retrievedComment = null;
                try
                {
                    retrievedComment = dbContext.Comments
                        .Include(c => c.User)
                        .Include(c => c.Post)
                        .First(c => c.Id == comment.Id);
                    Assert.NotNull(retrievedComment);
                    Assert.NotNull(retrievedComment.User);
                    Assert.NotNull(retrievedComment.Post);
                    var retrievedUser = dbContext.Users
                        .First(u => u.Id == comment.User.Id);
                    Assert.NotNull(retrievedUser);
                    var retrievedPost = dbContext.Posts
                        .First(p => p.Id == comment.Post.Id);
                    Assert.NotNull(retrievedPost);
                }
                finally
                {
                    //Teardown
                    if (retrievedComment != null)
                    {
                        dbContext.Comments.Remove(retrievedComment);
                    }
                }
            }
        }

        [Fact]
        public void RemoveCommentTest()
        {
            //Act
            var user = new User
            {
                Name = "Dimitrij Orlov",
                Gender = Gender.Male,
                Email = "orlov.dima@gmail.com",
                Status = Status.Offline
            };
            var team = new Team
            {
                Name = "TeamBuddy",
                Description = "The first team of this app."
            };
            var post = new Post
            {
                Title = "Our First Post",
                Text = "Hello World! This is just testing post.",
                PostAdditionTime = DateTime.Now,
                User = user,
                Team = team
            };
            var comment = new Comment
            {
                Text = "Hello World! This is just testing comment.",
                CommentAdditionTime = DateTime.Now,
                User = user,
                Post = post
            };
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Users.Add(user);
                dbContext.Teams.Add(team);
                dbContext.Posts.Add(post);
                dbContext.Comments.Add(comment);
                dbContext.SaveChanges();
            }
            //Act
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Comments.Remove(comment);
                dbContext.SaveChanges();

            }
            //Asserts
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                Comment retrievedComment = null;
                try
                {
                    retrievedComment = dbContext.Comments.FirstOrDefault(c => c.Id == comment.Id);
                    Assert.Null(retrievedComment);
                }
                finally
                {
                    //Teardown
                    if (retrievedComment != null)
                    {
                        dbContext.Comments.Remove(retrievedComment);
                    }
                }
            }
        }
    }
}
