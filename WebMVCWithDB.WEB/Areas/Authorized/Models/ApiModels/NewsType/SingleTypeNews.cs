using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.NewsType
{
    public class SingleTypeNews : ISingleTypeNews
    {
        public string Name { get; set; }
        public IEnumerable<Reddit.RedditThread> Reddit { get; set; }
        public IEnumerable<Twitter.Tweet> Twitter { get; set; }
    }

    public enum NewsTypes
    {
        StreetFighter,
        Tekken,
        GuiltyGear
    }
}