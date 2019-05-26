using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskRepository;

namespace TastkManager.Tests
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestGetUser()
        {
            Repository repos = new Repository();
            var result = repos.GetUsers();
        }
    }
}
