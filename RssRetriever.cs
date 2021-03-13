using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Linq;

namespace QuietRssNuget
{
    public static class RssRetriever
    {
        public static HashSet<RssSummary> GetQuietFeeds(Dictionary<string, string> companyFeeds, double? quietStreak = 5){
            var ret = new HashSet<RssSummary>();
            var quietStreakStartDate = DateTime.UtcNow.AddDays((double)quietStreak * -1);


            if(companyFeeds == null) return ret;

            foreach (KeyValuePair<string, string> entry in companyFeeds) { 
                
                //open the feed
                XmlReader feed = XmlReader.Create(entry.Value);
                var rssFeed = SyndicationFeed.Load(feed);
                feed.Close();

                if (rssFeed != null)
                {
                    DateTimeOffset lastUpdate = LastUpdateTime(rssFeed);
                    if(lastUpdate.DateTime.Date <= quietStreakStartDate.Date)
                       ret.Add(new RssSummary(entry.Key, entry.Value, lastUpdate, 0 /*TODO FIX*/, rssFeed.Title.Text));
                }
            }
            return ret;
        }

        private static DateTimeOffset LastUpdateTime(SyndicationFeed rssFeed)
        {
            //Short research has proven this field is not always updated, so we need to double check over the published items
            var lastUpdatedTime = rssFeed.LastUpdatedTime;

            var maxPublishDate = rssFeed.Items.Select(x => x.PublishDate).Max();

            return lastUpdatedTime > maxPublishDate ? lastUpdatedTime : maxPublishDate;
        }
    }
}
