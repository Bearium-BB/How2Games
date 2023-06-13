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
    public class PublisherTagHelperFunctionsTests
    {
        [TestMethod()]
        public void CreateTest()
        {

            // Arrange
            string text = null;
            PublisherTag pt = new PublisherTag();

            pt.Text = text;

            // Assert
            Assert.IsNull(pt.Text);

        }
    }
}