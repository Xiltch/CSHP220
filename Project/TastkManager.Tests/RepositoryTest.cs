using System;
using System.Linq;
using Blueprints;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManager.App_Data;

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
            Assert.IsTrue(actual > 0, "Was expecting at least one or more users from the repository");
        }

        [TestMethod]
        public void TestGetUser()
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

            repos.AddUser(user);

            Assert.AreEqual(count, repos.GetUsers().Count());

            int updated = repos.Save();

            Assert.IsTrue(updated > 0);

            var results = repos.GetUsers().ToArray();

            user = results
                .Where(x => x.First.Equals("John") && x.Last.Equals("Doe"))
                .FirstOrDefault();

            Assert.IsNotNull(repos.GetUser(user.ID));

            user.Last = "Dorian";

            repos.UpdateUser(user);

            results = repos.GetUsers().ToArray();

            user = results
                .Where(x => x.First.Equals("John") && x.Last.Equals("Doe"))
                .FirstOrDefault();

            Assert.IsNotNull(repos.GetUser(user.ID));

            updated = repos.Save();

            Assert.IsTrue(updated > 0);

            results = repos.GetUsers().ToArray();

            user = results
                .Where(x => x.First.Equals("John") && x.Last.Equals("Doe"))
                .FirstOrDefault();

            Assert.IsNull(user);

            user = results
                .Where(x => x.First.Equals("John") && x.Last.Equals("Dorian"))
                .FirstOrDefault();

            Assert.IsNotNull(repos.GetUser(user.ID));

            repos.DeleteUser(user.ID);

            Assert.IsNotNull(repos.GetUser(user.ID));

            updated = repos.Save();

            Assert.IsTrue(updated > 0);

            Assert.IsNull(repos.GetUser(user.ID));

        }

    }

}
