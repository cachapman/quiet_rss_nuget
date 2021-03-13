using System;
using System.Linq;
using System.Collections.Generic;
using System.ServiceModel.Syndication;

namespace QuietRssNuget
{
    public class RssRetriever
    {
        public HashSet<RssSummary> GetQuietFeeds(Dictionary<string, string> companyFeeds, int? quietStreak = 5, int? returnLimit = int.MaxValue){
            var ret = new HashSet<RssSummary>();
            if(companyFeeds == null) return ret;

            foreach (KeyValuePair<string, string> entry in companyFeeds{
                //open the feed
                //determine feed type
                //format feed to understandble type
                //get latest date
                //compare to quiet streak
                //if matches, add to list
                //if at the return limit, break and return
            }

            return ret.Take(returnLimit);

        }
    }
}
