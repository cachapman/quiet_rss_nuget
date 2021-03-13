using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using QuietRssNuget;
using System;

namespace QuietRssNugetTests
{
    [TestClass]
    public class QuietNugetTests
    {
        public object QuietRssNuget { get; private set; }
        
        [TestInitialize]
        public void QuietNugetInit()
        {
            TestRssFeedHelper.ClearFiles();
        }

        [TestMethod]
        public void PositiveCanOpenKnownGoodRssFeed()
        {
            //arrange
            var dictionary = new Dictionary<string, string>();
            
            dictionary.Add("Company 1", TestRssFeedHelper.MakeNewTestRssFeedWithDate(DateTime.UtcNow));

            //act
            var ret = RssRetriever.GetQuietFeeds(dictionary, 0);

            //assert
            Assert.IsTrue(ret.Count == 1);
        }


        [TestMethod]
        public void PositiveCanOpenMultipleKnownGoodRssFeeds()
        {
            //arrange
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("Company A", TestRssFeedHelper.MakeNewTestRssFeedWithDate(DateTime.UtcNow));
            dictionary.Add("Company B", TestRssFeedHelper.MakeNewTestRssFeedWithDate(DateTime.UtcNow));

            //act
            var ret = RssRetriever.GetQuietFeeds(dictionary, 0);

            //assert
            Assert.IsTrue(ret.Count == 2);
        }

        [TestMethod]
        public void PositiveCanReturnMultipleRssFeedsForSameCompany()
        {
            //arrange
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("Company A", TestRssFeedHelper.MakeNewTestRssFeedWithDate(DateTime.UtcNow));
            dictionary.Add("Company A", TestRssFeedHelper.MakeNewTestRssFeedWithDate(DateTime.UtcNow));

            //act
            var ret = RssRetriever.GetQuietFeeds(dictionary, 0);

            //assert
            Assert.IsTrue(ret.Count == 2);
        }
    }
}

