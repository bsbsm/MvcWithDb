using System.Web.Mvc;

namespace WebMVCWithDB.WEB.Areas.Authorized
{
    public class AuthorizedAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Authorized";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Authorized_default",
                "Authorized/{controller}/{action}/{id}",
                new { controller = "Main", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}