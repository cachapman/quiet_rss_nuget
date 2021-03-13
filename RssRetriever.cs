using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace QuietRssNuget
{
    public class RssRetriever
    {
        public HashSet<RssSummary> GetQuietFeeds(Dictionary<string, string> companyFeeds, int? quietStreak = 5, int? returnLimit = int.MaxValue){
            var ret = new HashSet<RssSummary>((int)returnLimit);
            if(companyFeeds == null) return ret;

            foreach (KeyValuePair<string, string> entry in companyFeeds) { 
                
                //open the feed
                XmlReader feed = XmlReader.Create(entry.Value);
                var rssFeed = SyndicationFeed.Load(feed);
                feed.Close();

                //get latest date
                //compare to quiet streak
                //if matches, add to list
                //if at the return limit, break and return
            }

            return ret;

        }
    }
}
