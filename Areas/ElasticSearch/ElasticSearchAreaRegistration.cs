using System.Web.Mvc;

namespace WebApplication5.Areas.ElasticSearch
{
    public class ElasticSearchAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ElasticSearch";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ElasticSearch_default",
                "ElasticSearch/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}