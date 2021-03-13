using System;

namespace QuietRssNuget
{
    //I have a feeling we may need to make this more generic
    //But, unsure of market demand for expansion, since the ask is straight forward.
    //TODO: Ask on longevity of this code
    public class RssSummary
    {
        public string Company {get;set;}
        public string Title { get; set; }
        public string RssUri { get; set; }
        public int QuietStreak {get;set;}
        public DateTime LastPost { get; set; }
    }
}