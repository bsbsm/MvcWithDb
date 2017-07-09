using LinqToTwitter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.NewsType;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.Reddit;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.Twitter;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Factory;

namespace WebMVCWithDB.WEB.Areas.Authorized.Services.Api
{
    public class ApiService : IApiService
    {
        private IModelsFactory _factory;
        public ApiService(IModelsFactory factory)
        {
            _factory = factory;
        }
        
        public IEnumerable<ISingleTypeNews> GetAllNews()
        {
            var news = new List<ISingleTypeNews>();

            foreach(var type in (NewsTypes[])Enum.GetValues(typeof(NewsTypes)))
            {
                news.Add(GetNews(type));
            }

            return news;
        }

        public ISingleTypeNews GetNews(NewsTypes type)
        {
            var news = _factory.BuildSingleTypeNews();    

            switch (type)
            {
                case NewsTypes.StreetFighter:
                    news.Name = "Street Fighter V";
                    news.Reddit = FromReddit("StreetFighter");
                    news.Twitter = FromTwitter("Street Fighter V");
                    break;
                case NewsTypes.Tekken:
                    news.Name = "Tekken 7";
                    news.Reddit = FromReddit("Tekken");
                    news.Twitter = FromTwitter("Tekken 7");
                    break;
                case NewsTypes.GuiltyGear:
                    news.Name = "Guilty Gear Xrd Rev 2";
                    news.Reddit = FromReddit("GuiltyGear");
                    news.Twitter = FromTwitter("Guilty Gear Rev 2");
                    break;
            }
            
            return news;
        }

        #region Reddit
        private IList<RedditThread> FromReddit(string subreddit)
        {
            var client = new RestSharp.RestClient("https://www.reddit.com/");
            var request = new RestSharp.RestRequest("/r/{subreddit}/new/.json");
            request.AddParameter("limit", "25");           
            request.AddUrlSegment("subreddit", subreddit); // replaces matching token in request.Resource

            RestSharp.IRestResponse response = client.Execute(request);
            var content = response.Content;

            dynamic resultDynamic = JsonConvert.DeserializeObject(content);
            var result = GetChildrenList(resultDynamic.data.children);

            //return Json(result, JsonRequestBehavior.AllowGet);
            return result;
        }

        private List<RedditThread> GetChildrenList(dynamic children)
        {
            var resList = new List<RedditThread>();
            foreach (var item in children)
            {
                var dataItem = item.data;
                
                var itemModel = SetRedditThreadProperties(_factory.BuildRedditThread(), dataItem);
           
                resList.Add(itemModel);
            }

            return resList;
        }

        private DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        private RedditThread SetRedditThreadProperties(RedditThread thread, dynamic data)
        {         
            if(thread != null & data != null)
            {
                thread.Author = data.author;
                thread.Domain = data.domain;

                var createdAt = FromUnixTime((long)data.created);
                thread.CreatedDate = String.Format("{0:HH:mm dd.MM.yy}", createdAt);

                thread.Url = data.url;
                thread.Title = data.title;
                thread.ThumbnailLink = data.thumbnail.ToString().StartsWith("self") ? String.Empty : data.thumbnail;
            }          

            return thread;
        }
        #endregion

        #region Twitter
        private IList<Tweet> FromTwitter(string query)
        {
            int maxSearchEntriesToReturn =  25;
            string searchQuery = query;

            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = "6Jhl8frURygqtUAnzQUYpwt9d",
                    ConsumerSecret = "Z6ws6X9O1hrhMM5ymBOz8eTpRJOMO7tZUvc9yrUPKRr0STdyX9"
                    //AccessToken = ConfigurationManager.AppSettings["2388920497-9ss4FuS5Ik9FRW3QsOIkflywnekY12tpWLtAs7C"],
                    //AccessTokenSecret = ConfigurationManager.AppSettings["vVGc97JZCaQ6dxk2puSH9SSt6BDjzUdmutuzZqI0eyh44"]
                }
            };

            IList<Search> searchResponse;

            using (var twitterContext = new TwitterContext(auth))
            {
                 searchResponse = twitterContext.Search.Where(s => s.Type == SearchType.Search &&
                                s.Count == maxSearchEntriesToReturn &&
                                s.Query == searchQuery) //&& s.SearchLanguage.Equals("en")
                                .ToList();
            }          
                                
            IList<Tweet> result;

            if (searchResponse != null)
            {
                var temp = searchResponse.Where(t => t.Statuses != null)
                   .Select(t => t.Statuses)
                   .SingleOrDefault();

                result = temp.Select(t => new Tweet
                {
                    UserName = t.User.Name,
                    CreateDate = String.Format("{0:HH:mm dd.MM.yy}", t.CreatedAt),
                    Text = t.Text,
                    Link = "https://twitter.com/" + t.User.Name+"/status/"+t.StatusID
                })
                .ToList();

                return result;
            }
            else
            {
                result = new List<Tweet>();

                return result;
            }          
        }
      #endregion
    }
}