using System;
using System.Linq;
using Blueprints;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskRepository;

namespace TastkManager.Tests
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestGetUsers()
        {
            Repository repos = new Repository();
            var result = repos.GetUsers();
            var actual = result.ToArray().Length;
            Assert.IsTrue(actual > 0,"Was expecting at least one or more users from the repository");
        }

        [TestMethod]
        public void  TestGetUser()
        {
            Repository repos = new Repository();
            var firstUser = repos.GetUsers().FirstOrDefault();
            var actual = repos.GetUser(firstUser.ID);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void TestUserCreation()
        {

            Repository repos = new Repository();

            int count = repos.GetUsers().Count();

            IUser user = new User() { First = "John", Last = "Doe" };

            user = repos.AddUser(user);

            Assert.AreEqual(0, user.ID);
            Assert.IsNull(repos.GetUser(user.ID));
            Assert.AreEqual(count, repos.GetUsers().Count());

            int updated = repos.UpdateDatabase();

            Assert.IsTrue(updated > 0);

            var results = repos.GetUsers().ToArray();

            user = repos.GetUsers()
                .Where(x => x.First.Equals("John") && x.Last.Equals("Doe") )
                .FirstOrDefault();

            Assert.IsNotNull(repos.GetUser(user.ID));

        }

    }

}
