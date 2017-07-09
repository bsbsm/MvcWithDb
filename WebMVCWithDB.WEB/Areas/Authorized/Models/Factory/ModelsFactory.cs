using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.NewsType;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.Reddit;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.Twitter;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces;

namespace WebMVCWithDB.WEB.Areas.Authorized.Models.Factory
{
    public class ModelsFactory : IModelsFactory
    {
        public ICreateBook BuildCreateBook()
        {
            return new CreateBook();
        }

        public IMainBook BuildMainBook()
        {
            return new MainBook();
        }

        public ISearchBook BuildSearchBook()
        {
            return new SearchBook();
        }

        public RedditThread BuildRedditThread()
        {
            return new RedditThread();
        }
        public Tweet BuildTweet()
        {
            return new Tweet();
        }
        public ISingleTypeNews BuildSingleTypeNews()
        {
            return new SingleTypeNews();
        }
    }
}