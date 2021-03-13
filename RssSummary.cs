using System;

namespace QuietRssNuget
{
    //I have a feeling we may need to make this more generic
    //But, unsure of market demand for expansion, since the ask is straight forward.
    //TODO: Ask on longevity of this code
    public class RssSummary
    {
        public RssSummary(string company, string rssUri, DateTimeOffset lastUpdate, int quietStreak, string title)
        {
            this.Company = company;
            this.RssUri = rssUri;
            this.LastPostDateUTC = lastUpdate.UtcDateTime;
            this.QuietStreak = quietStreak; 
            this.Title = Title;
        }

      
        public string Company {get;set;}
        public string Title { get; set; }
        public string RssUri { get; set; }
        public int QuietStreak {get;set;}
        public DateTime LastPostDateUTC { get; set; }

    }
}