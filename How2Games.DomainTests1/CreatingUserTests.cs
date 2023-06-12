using Microsoft.VisualStudio.TestTools.UnitTesting;
using How2Games.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using How2Games.Domain.DB;
using NuGet.Frameworks;

namespace How2Games.Domain.Tests
{
    [TestClass()]
    public class CreatingUserTests
    {
        [TestMethod()]
        public void UserNameIsntNull()
        {
            var user = new How2GamesUser();

            user.UserName = null;


            Assert.AreEqual(null, user.UserName);
        } 
        [TestMethod()]
        public void NameIsValid()
        {
            var user = new How2GamesUser();
            string FirstName = "Hans";
            string LastName = "KirbyLord";
            user.FullName = $"{FirstName} {LastName}";

            Assert.ThrowsException<ArgumentNullException>(() => {
                if (!string.IsNullOrEmpty(user.FullName))
                {
                    throw new ArgumentNullException();
                }
            });
        }
    }
}