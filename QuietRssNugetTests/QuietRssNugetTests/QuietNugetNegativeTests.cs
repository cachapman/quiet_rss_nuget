using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using QuietRssNuget;
using System;
using System.IO;
using System.Net.Http;

namespace QuietRssNugetTests
{
    [TestClass]
    public class QuietNugetNegativeTests
    {
        public object QuietRssNuget { get; private set; }

        [TestInitialize]
        public void QuietNugetNegativeInit()
        {
            TestRssFeedHelper.ClearFiles();
        }

        [TestMethod]
        public void NegativeThrowsABadURL()
        {
            //arrange
            var dictionary = new List<Tuple<string, string>>();
            dictionary.Add(new Tuple<string, string>("Company A", "https://notrealrssfeedimreallysureitsnotrealtrustme.com"));


            //act + assert
            Assert.ThrowsException<HttpRequestException>(() => { RssRetriever.GetQuietFeeds(dictionary, 0); });
        }

        [TestMethod]
        public void NegativeThrowsABadFeed()
        {
            //arrange
            var dictionary = new List<Tuple<string, string>>();
            dictionary.Add(new Tuple<string, string>("Company A", "https://google.com"));


            //act + assert
            Assert.ThrowsException<System.Xml.XmlException>(() => { RssRetriever.GetQuietFeeds(dictionary, 0); });
        }
    }
}

