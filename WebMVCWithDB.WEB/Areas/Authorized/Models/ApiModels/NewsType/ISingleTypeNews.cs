using System.Collections.Generic;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.Reddit;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.Twitter;

namespace WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.NewsType
{
    public interface ISingleTypeNews
    {
        string Name { get; set; }
        IEnumerable<RedditThread> Reddit { get; set; }
        IEnumerable<Tweet> Twitter { get; set; }
    }
}