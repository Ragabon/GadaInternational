using System.Collections.Generic;
using System.Linq;
using Gada.Discussions.Entities;
using Gada.Discussions.Repositories;
using Gada.Infrastructure.Data.Dapper.Repositories.Discussions;
using NUnit.Framework;

namespace Gada.Tests.Integration.RepositoryTests
{
    class DiscussionRepositoryTests : ContextTestBase
    {
        private IDiscussionRepository<Discussion> _discussionRepository;

        private Discussion _expecteDiscussion;

        [TestFixtureSetUp]
        public void Setup()
        {
            _discussionRepository = new DiscussionRepository();

            var user = User.CreateUser("user@test.com");

            var interests = new List<Interest> {Interest.CreateInterest("General")};

            var discussion = Discussion.CreateDiscussion("Test", "Hello world!", user, interests, true, null);

            var post = Post.CreatePost("Foo bar", user);

            discussion.AddPost(post);
            _expecteDiscussion = discussion;

            Context.DiscussionRepository.Add(discussion);

            Context.Save();
        }

        [Test]
        public async void Get_All_Discussions_Should_Retrieve_Results()
        {
            var discussions = await _discussionRepository.GetAll();

            Assert.NotNull(discussions);
            Assert.AreEqual(1, discussions.Count());
        }

        [Test]
        public async void Get_List_Of_Discussions_Should_Retrieve_Results()
        {
            var discussions = await _discussionRepository.GetList();

            Assert.NotNull(discussions);
            Assert.AreEqual(1, discussions.Count());
            Assert.NotNull(discussions.FirstOrDefault().CreatedBy);
        }

        [Test]
        public void Find_By_Id_Should_Retrieve_Correct_Discussion()
        {
            var discussion = _discussionRepository.FindById(_expecteDiscussion.Id);

            Assert.NotNull(discussion);
            Assert.AreEqual(_expecteDiscussion.Id, discussion.Id);
            Assert.AreEqual(_expecteDiscussion.Title, discussion.Title);
            Assert.AreEqual(_expecteDiscussion.Description, discussion.Description);
        }
    }
}
