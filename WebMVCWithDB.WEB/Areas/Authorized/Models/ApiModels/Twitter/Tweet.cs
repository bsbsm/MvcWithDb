using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.Twitter
{
    public class Tweet
    {
        public string UserName { get; set; }
        public string Text { get; set; }
        public string CreateDate { get; set; }
        public string Link { get; set; }
    }
}