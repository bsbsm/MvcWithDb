using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.NewsType;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.Reddit;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.Twitter;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces;

namespace WebMVCWithDB.WEB.Areas.Authorized.Models.Factory
{
    public interface IModelsFactory
    {
        IMainBook BuildMainBook();
        ICreateBook BuildCreateBook();
        ISearchBook BuildSearchBook();
        ISingleTypeNews BuildSingleTypeNews();
        RedditThread BuildRedditThread();
        Tweet BuildTweet();
    }
}