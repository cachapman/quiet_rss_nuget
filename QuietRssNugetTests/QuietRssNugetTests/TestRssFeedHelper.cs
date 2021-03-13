using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuietRssNugetTests
{
    public static class TestRssFeedHelper
    {
        private static string _workingDir = Directory.GetCurrentDirectory() + "\\TestFeeds\\";

        public static string MakeNewTestRssFeedWithDate(DateTime lastUpdated)
        {
            SyndicationFeed feed = new SyndicationFeed("Title " + Guid.NewGuid().ToString(),
                                                        "Description " + Guid.NewGuid().ToString(), 
                                                        null /*assuming it's good*/, 
                                                        Guid.NewGuid().ToString(), 
                                                        lastUpdated);

            return WriteToFile(feed, feed.Id);
        }

        public static string MakeNewTestRssFeedWithBadUpdatedDate()
        {
           return  MakeNewTestRssFeedWithDate(DateTime.MinValue);
        }


        public static string WriteToFile(SyndicationFeed feed, string name)
        {
            string filename = _workingDir + name + ".xml";
            Directory.CreateDirectory(_workingDir);
            XmlWriter rssWriter = XmlWriter.Create(filename);
            Rss20FeedFormatter rssFormatter = new Rss20FeedFormatter(feed);
            rssFormatter.WriteTo(rssWriter);
            rssWriter.Close();
            return filename;
        }

        public static void ClearFiles()
        {
            var files = Directory.GetFiles(_workingDir);
            foreach (string f in files)
                File.Delete(f);
        }
    }
}
