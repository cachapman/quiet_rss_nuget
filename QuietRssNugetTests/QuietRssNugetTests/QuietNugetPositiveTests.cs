using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using QuietRssNuget;
using System;

namespace QuietRssNugetTests
{
    [TestClass]
    public class QuietNugetPositiveTests
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
            var dictionary = new List<Tuple<string, string>>();

            dictionary.Add(new Tuple<string, string>("Company A", TestRssFeedHelper.MakeNewTestRssFeedWithDate(DateTime.UtcNow)));

            //act
            var ret = RssRetriever.GetQuietFeeds(dictionary, 0);

            //assert
            Assert.IsTrue(ret.Count == 1);
        }

        [TestMethod]
        public void PositiveCanOpenMultipleKnownGoodRssFeeds()
        {
            //arrange
            var dictionary = new List<Tuple<string, string>>();
            dictionary.Add(new Tuple<string, string>("Company A", TestRssFeedHelper.MakeNewTestRssFeedWithDate(DateTime.UtcNow)));
            dictionary.Add(new Tuple<string, string>("Company B", TestRssFeedHelper.MakeNewTestRssFeedWithDate(DateTime.UtcNow)));

            //act
            var ret = RssRetriever.GetQuietFeeds(dictionary, 0);

            //assert
            Assert.IsTrue(ret.Count == 2);
        }

        [TestMethod]
        public void PositiveCanReturnMultipleRssFeedsForSameCompany()
        {
            //arrange
            var dictionary = new List<Tuple<string, string>>();
            dictionary.Add(new Tuple<string, string>("Company A", TestRssFeedHelper.MakeNewTestRssFeedWithDate(DateTime.UtcNow)));
            dictionary.Add(new Tuple<string, string>("Company A", TestRssFeedHelper.MakeNewTestRssFeedWithDate(DateTime.UtcNow)));

            //act
            var ret = RssRetriever.GetQuietFeeds(dictionary, 0);

            //assert
            Assert.IsTrue(ret.Count == 2);
        }

        [TestMethod]
        public void PositiveReturnFeedWithUpdatesForSpecifiedDateInsideRange()
        {
            //arrange
            var givenNumberOfDaysOfSilence = 4;
            var latestPost = 5;
            var dictionary = new List<Tuple<string, string>>();
            dictionary.Add(new Tuple<string, string>("Company A", TestRssFeedHelper.MakeNewTestRssFeedWithDate(DateTime.UtcNow.AddDays(-1 * latestPost))));

            //act
            var ret = RssRetriever.GetQuietFeeds(dictionary, givenNumberOfDaysOfSilence);

            //assert
            Assert.IsTrue(ret.Count == 1);
        }

        [TestMethod]
        public void PositiveReturnFeedWithOutUpdatesForSpecifiedDateOnTheDot()
        {
            //arrange
            var givenNumberOfDaysOfSilence = 5;
            var latestPost = 5;
            var dictionary = new List<Tuple<string, string>>();
            dictionary.Add(new Tuple<string, string>("Company A", TestRssFeedHelper.MakeNewTestRssFeedWithDate(DateTime.UtcNow.AddDays(-1 * latestPost))));

            //act
            var ret = RssRetriever.GetQuietFeeds(dictionary, givenNumberOfDaysOfSilence);

            //assert
            Assert.IsTrue(ret.Count == 1);
        }

        [TestMethod]
        public void PositiveDoNotReturnFeedWithUpdatesForSpecifiedDate()
        {
            //arrange
            var givenNumberOfDaysOfSilence = 6;
            var latestPost = 5;
            var dictionary = new List<Tuple<string, string>>();
            dictionary.Add(new Tuple<string, string>("Company A", TestRssFeedHelper.MakeNewTestRssFeedWithDate(DateTime.UtcNow.AddDays(-1 * latestPost))));

            //act
            var ret = RssRetriever.GetQuietFeeds(dictionary, givenNumberOfDaysOfSilence);

            //assert
            Assert.IsTrue(ret.Count == 0);
        }

        

    }
}

