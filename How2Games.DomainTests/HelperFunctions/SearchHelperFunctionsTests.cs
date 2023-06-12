using Microsoft.VisualStudio.TestTools.UnitTesting;
using How2Games.Domain.HelperFunctions;
using System;

namespace How2Games.Domain.HelperFunctions.Tests
{
    [TestClass()]
    public class SearchHelperFunctionsTests
    {
        [TestMethod()]
        public void LevenshteinDistanceTest()
        {
            SearchHelperFunctions searchHelperFunctions = new SearchHelperFunctions();

            // Test 1
            string s1 = "hello";
            string s2 = "hello";
            int distance = searchHelperFunctions.LevenshteinDistance(s1, s2);
            Assert.AreEqual(0, distance);

            // Test 2
            s1 = "kitten";
            s2 = "sitting";
            distance = searchHelperFunctions.LevenshteinDistance(s1, s2);
            Assert.AreEqual(3, distance);

            // Test 3
            s1 = "book";
            s2 = "car";
            distance = searchHelperFunctions.LevenshteinDistance(s1, s2);
            Assert.AreEqual(4, distance);
        }
    }
}
