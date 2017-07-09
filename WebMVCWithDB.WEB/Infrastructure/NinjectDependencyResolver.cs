using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCWithDB.DAL.EFContexts;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Books.Interfaces;
using WebMVCWithDB.WEB.Areas.Authorized.Models.Factory;
using WebMVCWithDB.WEB.Areas.Authorized.Services.Api;
using WebMVCWithDB.WEB.Areas.Authorized.Services.Books;

namespace WebMVCWithDB.WEB.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IBooksService>().To<BooksService>();
            kernel.Bind<IApiService>().To<ApiService>();
            kernel.Bind<IModelsFactory>().To<ModelsFactory>();
        }
    }
}