using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using QuietRssNuget;

namespace QuietRssNugetTests
{
    [TestClass]
    public class QuietNugetTests
    {
        public object QuietRssNuget { get; private set; }

        [TestMethod]
        public void PositiveCanOpenKnownGoodRssFeed()
        {
            //arrange
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("The Apology Line", "https://rss.art19.com/apology-line");

            //act
            var ret = RssRetriever.GetQuietFeeds(dictionary);

            //assert
            Assert.IsTrue(ret.Count == 1);
        }


        [TestMethod]
        public void PositiveCanOpenMultipleKnownGoodRssFeeds()
        {
            //arrange
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("Company A", "https://rss.art19.com/apology-line");
            dictionary.Add("Company B", "https://feeds.simplecast.com/54nAGcIl");

            //act
            var ret = RssRetriever.GetQuietFeeds(dictionary);

            //assert
            Assert.IsTrue(ret.Count == 2);
        }

        [TestMethod]
        public void PositiveCanReturnMultipleRssFeedsForSameCompany()
        {
            //arrange
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("Company A", "https://rss.art19.com/apology-line");
            dictionary.Add("Company A", "https://feeds.simplecast.com/54nAGcIl");

            //act
            var ret = RssRetriever.GetQuietFeeds(dictionary);

            //assert
            Assert.IsTrue(ret.Count == 2);
        }
    }
}

