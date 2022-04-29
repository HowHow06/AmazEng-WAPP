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
                 "~/Default.aspx"
             );
            routes.MapPageRoute(
                  "HomeRoute",
                  "Home",
                  "~/Default.aspx"
              );

        }
    }
}
