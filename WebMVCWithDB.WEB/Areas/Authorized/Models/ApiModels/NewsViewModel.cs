using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels
{
    public class NewsViewModel
    {
        public IEnumerable<NewsType.ISingleTypeNews> News { get; set; }
    }
}