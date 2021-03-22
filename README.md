# QuietRssNuget
Nuget to return a list of non-posting RSS feeds given a list of RSS feeds and a specific number of days. 

## Assumptions
- Assumed the logic was >= the dates coming in will be considered quiet
- That the ask of multiple urls per company superceeded the ask for a Dictionary type object, or at least, in functionality worked the same
- Could have made an object of "RssFeeds" which was an array of streams, but this flattened approach makes iteation easier
- Capable of running latest framework
- Seperate concern from any app that may need to use this (hence nuget)
- Unable to have a primitive Dictionary containing multiple of the same key, so moved to Tuple to achieve lack of duplication but with multiple keys
 - Seeing the simple nature of this code, I assume this, for now, won't need an abstract to build off of
