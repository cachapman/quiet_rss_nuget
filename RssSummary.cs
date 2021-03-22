using System;

namespace QuietRssNuget
{
     public class RssSummary
    {
        public RssSummary(string company, string rssUri, DateTimeOffset lastUpdate, double quietStreak, string title)
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
        public double QuietStreak {get;set;}
        public DateTime LastPostDateUTC { get; set; }

    }
}