using Microsoft.AspNet.FriendlyUrls;
using System.Web.Routing;

namespace AmazEng_WAPP
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            routes.MapPageRoute(
                 "DefaultRoute",
                 "",
                 "~/Home.aspx"
             );
            routes.MapPageRoute(
                  "HomeRoute",
                  "Home",
                  "~/Home.aspx"
              );

        }
    }
}
