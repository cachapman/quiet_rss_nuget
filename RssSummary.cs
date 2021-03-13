using System;

namespace QuietRssNuget
{
    public class RssSummary
    {
        public string Company {get;set;}
        public string Title { get; set; }
        public string RssUri { get; set; }
        public int QuietStreak {get;set;}
        public DateTime LastPost { get; set; }
    }
}