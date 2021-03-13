using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Linq;
using System.IO;
using System.Net.Http;

namespace QuietRssNuget
{
    public static class RssRetriever
    {
        public static HashSet<RssSummary> GetQuietFeeds(List<Tuple<string, string>> companyFeeds, double? quietStreak = 5)
        {
            var ret = new HashSet<RssSummary>();
            var quietStreakStartDate = DateTime.UtcNow.AddDays((double)quietStreak * -1);

            if (companyFeeds == null) return ret;

            foreach (Tuple<string, string> entry in companyFeeds)
            {
                SyndicationFeed rssFeed = GetFeedFromUri(entry.Item2);

                if (rssFeed != null)
                {
                    DateTimeOffset lastUpdate = LastUpdateTime(rssFeed);
                    if (lastUpdate.DateTime.Date <= quietStreakStartDate.Date)
                        ret.Add(new RssSummary(entry.Item1, entry.Item2, lastUpdate,  CalculateQuietStreak(lastUpdate.DateTime.Date), rssFeed.Title.Text));
                }
            }
            return ret;
        }

        private static double CalculateQuietStreak(DateTime lastUpdate)
        {
            return (DateTime.UtcNow.Date - lastUpdate).TotalDays;
        }

        private static SyndicationFeed GetFeedFromUri(string uri)
        {
            //don't try/catch exception; should be handled in application (is it valid? log it? remove it?)
            XmlReader feed = XmlReader.Create(uri);
            var rssFeed = SyndicationFeed.Load(feed);
            feed.Close();
            return rssFeed;
        }

        private static DateTimeOffset LastUpdateTime(SyndicationFeed rssFeed)
        {
            //Short research has proven this field is not always updated, so we need to double check over the published items
            var lastUpdatedTime = rssFeed.LastUpdatedTime;

            if (rssFeed.Items.Count() == 0) return lastUpdatedTime;

            var maxPublishDate = rssFeed.Items.Select(x => x.PublishDate).Max();

            return lastUpdatedTime > maxPublishDate ? lastUpdatedTime : maxPublishDate;
        }
    }
}
