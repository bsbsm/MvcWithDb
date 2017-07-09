using System.Collections.Generic;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.NewsType;

namespace WebMVCWithDB.WEB.Areas.Authorized.Services.Api
{
    public interface IApiService
    {
        IEnumerable<ISingleTypeNews> GetAllNews();
        ISingleTypeNews GetNews(NewsTypes type);
    }
}