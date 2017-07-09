using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.Reddit
{
    public class RedditThread
    {
        [XmlIgnore]
        [JsonIgnore]
        public string Author { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public string Domain { get; set; }
        public string Id { get; set; }
        public string CreatedDate { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailLink { get; set; }
    }
}