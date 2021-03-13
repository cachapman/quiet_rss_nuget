using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace QuietRssNuget
{
    public static class RssRetriever
    {
        public static HashSet<RssSummary> GetQuietFeeds(Dictionary<string, string> companyFeeds, int? quietStreak = 5){
            var ret = new HashSet<RssSummary>();
            if(companyFeeds == null) return ret;

            foreach (KeyValuePair<string, string> entry in companyFeeds) { 
                
                //open the feed
                XmlReader feed = XmlReader.Create(entry.Value);
                var rssFeed = SyndicationFeed.Load(feed);
                feed.Close();

                if (rssFeed != null)
                {
                    ret.Add(new RssSummary
                    {
                        Company = entry.Key,
                        RssUri = entry.Value,
                        LastPost = DateTime.Now, //TODO FIX
                        QuietStreak = 0, //TODO FIX
                        Title = rssFeed.Title.Text
                    });
                }
                //get latest date
                //compare to quiet streak
                //if matches, add to list
              
            }

            return ret;

        }
    }
}
