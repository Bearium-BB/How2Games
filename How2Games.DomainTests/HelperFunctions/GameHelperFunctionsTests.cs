using Microsoft.VisualStudio.TestTools.UnitTesting;
using How2Games.Domain.HelperFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using How2Games.Domain.DB;

namespace How2Games.Domain.HelperFunctions.Tests
{
    [TestClass()]
    public class GameHelperFunctionsTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            string name = "Test Game";
            string shortDescription = "Short description";
            string detailedDescription = "Detailed description";
            string imgUrl = "http://example.com/image.jpg";

            GameHelperFunctions gameHelperFunctions = new GameHelperFunctions();
            // Act
            Game game = gameHelperFunctions.Create(name, shortDescription, detailedDescription, imgUrl);

            // Assert
            Assert.IsNotNull(game);
            Assert.AreEqual(name, game.Name);
            Assert.AreEqual(shortDescription, game.ShortDescription);
            Assert.AreEqual(detailedDescription, game.DetailedDescription);
            Assert.AreEqual(imgUrl, game.ImgUrl);
        }
    }
}