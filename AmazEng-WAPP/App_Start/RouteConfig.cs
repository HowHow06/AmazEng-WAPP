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
            routes.MapPageRoute(
                  "AboutRoute",
                  "About",
                  "~/About.aspx"
              );
            routes.MapPageRoute(
                  "ExploreRoute",
                  "Explore",
                  "~/ExploreIdioms.aspx"
              );
            routes.MapPageRoute(
                  "ContactRoute",
                  "Contact",
                  "~/Contact.aspx"
              );
            routes.MapPageRoute(
                 "LoginRoute",
                 "Login",
                 "~/Login.aspx"
             );
            routes.MapPageRoute(
                "RegisterRoute",
                "Register",
                "~/Register.aspx"
            );
            routes.MapPageRoute(
                "SearchRoute",
                "Search",
                "~/Search.aspx"
            );
            routes.MapPageRoute(
                "IdiomRoute",
                "Idiom",
                "~/Idiom.aspx"
            );
            //more routes to go...
        }
    }
}
