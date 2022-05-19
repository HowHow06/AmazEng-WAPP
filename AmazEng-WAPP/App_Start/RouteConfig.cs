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
                  "~/Explore.aspx"
              );
            routes.MapPageRoute(
                 "ResultRoute",
                 "Result/{SearchKey}",
                 "~/Result.aspx",
                 false,
                 new RouteValueDictionary { { "SearchKey", string.Empty } }
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
                "ForgotRoute",
                "Forgot",
                "~/Forgot.aspx"
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


            routes.MapPageRoute(
                "AdminDashboardRoute",
                "Admin/",
                "~/AdminPages/Dashboard.aspx"
            );

            routes.MapPageRoute(
                "AdminLoginRoute",
                "Admin/Login",
                "~/AdminPages/Login.aspx"
            );

            routes.MapPageRoute(
               "AdminForgotRoute",
               "Admin/Forgot",
               "~/AdminPages/Forgot.aspx"
           );

            routes.MapPageRoute(
              "AdminMembersRoute",
              "Admin/Members",
              "~/AdminPages/ManageMembers.aspx"
          );

            routes.MapPageRoute(
              "AdminViewMemberRoute",
              "Admin/Member/{Id}/{Mode}",
              "~/AdminPages/MemberPages/ViewMember.aspx",
              false,
              new RouteValueDictionary { { "Mode", string.Empty } }
          );

            routes.MapPageRoute(
              "AdminNewMemberRoute",
              "Admin/CreateMember/{Mode}",
              "~/AdminPages/MemberPages/ViewMember.aspx",
              false,
              new RouteValueDictionary { { "Mode", "New" } }
          );

            routes.MapPageRoute(
              "AdminIdiomsRoute",
              "Admin/Idioms",
              "~/AdminPages/ManageMembers.aspx"
          );

            routes.MapPageRoute(
              "AdminIdiomTagsRoute",
              "Admin/IdiomTags",
              "~/AdminPages/ManageMembers.aspx"
          );

            routes.MapPageRoute(
              "AdminAdminsRoute",
              "Admin/Admins",
              "~/AdminPages/ManageMembers.aspx"
          );

            routes.MapPageRoute(
              "AdminMessagesRoute",
              "Admin/Messages",
              "~/AdminPages/ManageMembers.aspx"
          );

            routes.MapPageRoute(
              "AdminReportsRoute",
              "Admin/Reports",
              "~/AdminPages/ManageMembers.aspx"
          );
        }
    }
}
