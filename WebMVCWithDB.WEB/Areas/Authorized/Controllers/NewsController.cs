﻿using System.Collections.Generic;
using System.Web.Mvc;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels;
using WebMVCWithDB.WEB.Areas.Authorized.Models.ApiModels.NewsType;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Factory;
using WebMVCWithDB.WEB.Areas.Authorized.Services;
using WebMVCWithDB.WEB.Areas.Authorized.Services.Api;

namespace WebMVCWithDB.WEB.Areas.Authorized.Controllers
{
    public class NewsController : Controller
    {
        IApiService _service;
        public NewsController(IApiService service)
        {
            //Невозможно создать экземпляр интерфейса. Object type 'WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces.ISearchBook'
            _service = service;
        }

        // GET: Authorized/News/All
        public ActionResult Index(NewsTypes? type)
        {
            var model = new NewsViewModel();

            if (type == null)
                model.News = _service.GetAllNews();
            else
                model.News = new List<ISingleTypeNews> { _service.GetNews(type.Value) };

            return View(model);
        }

        public ActionResult News(NewsTypes type)
        {
            var data = _service.GetNews(NewsTypes.StreetFighter);

            return View(data);
        }
    }
}