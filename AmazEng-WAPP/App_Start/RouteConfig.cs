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
                 "Result",
                 "~/Result.aspx"
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
                "IdiomRoute",
                "Idiom/{Id}",
                "~/IdiomDetail.aspx"
            );

            routes.MapPageRoute(
               "ManagePasswordRoute",
               "ManagePassword",
               "~/ManagePassword.aspx"
           );
            routes.MapPageRoute(
              "ManageProfileRoute",
              "ManageProfile",
              "~/ManageProfile.aspx"
          );
            routes.MapPageRoute(
             "ManageLibraryRoute",
             "ManageLibrary",
             "~/ManageLibrary.aspx"
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
              "~/AdminPages/ManageIdioms.aspx"
          );

            routes.MapPageRoute(
             "AdminViewIdiomRoute",
             "Admin/Idiom/{Id}/{Mode}",
             "~/AdminPages/IdiomPages/ViewIdiom.aspx",
             false,
             new RouteValueDictionary { { "Mode", string.Empty } }
         );

            routes.MapPageRoute(
              "AdminNewIdiomRoute",
              "Admin/CreateIdiom/{Mode}",
              "~/AdminPages/IdiomPages/ViewIdiom.aspx",
              false,
              new RouteValueDictionary { { "Mode", "New" } }
          );

            routes.MapPageRoute(
              "AdminTagsRoute",
              "Admin/Tags",
              "~/AdminPages/ManageTags.aspx"
          );

            routes.MapPageRoute(
             "AdminViewTagRoute",
             "Admin/Tag/{Id}/{Mode}",
             "~/AdminPages/TagPages/ViewTag.aspx",
             false,
             new RouteValueDictionary { { "Mode", string.Empty } }
         );

            routes.MapPageRoute(
              "AdminNewTagRoute",
              "Admin/CreateTag/{Mode}",
              "~/AdminPages/TagPages/ViewTag.aspx",
              false,
              new RouteValueDictionary { { "Mode", "New" } }
          );

            routes.MapPageRoute(
              "AdminAdminsRoute",
              "Admin/Admins",
              "~/AdminPages/ManageAdmins.aspx"
          );

            // Do copy contents from ViewMembers page
            routes.MapPageRoute(
              "AdminViewAdminRoute",
              "Admin/AdminList/{Id}/{Mode}",
              "~/AdminPages/ViewAdmin.aspx",
              false,
              new RouteValueDictionary { { "Mode", string.Empty } }
          );

            routes.MapPageRoute(
              "AdminNewAdminRoute",
              "Admin/CreateAdmin/{Mode}",
              "~/AdminPages/ViewAdmin.aspx",
              false,
              new RouteValueDictionary { { "Mode", "New" } }
          );

            routes.MapPageRoute(
              "AdminMessagesRoute",
              "Admin/Messages",
              "~/AdminPages/ManageMessages.aspx"
          );


            routes.MapPageRoute(
              "AdminViewMessageRoute",
              "Admin/Message/{Id}",
              "~/AdminPages/MessagePages/ViewMessage.aspx"
          );

            routes.MapPageRoute(
              "AdminFeedbacksRoute",
              "Admin/Feedbacks",
              "~/AdminPages/ManageFeedbacks.aspx"
          );

            routes.MapPageRoute(
             "AdminViewFeedbackRoute",
             "Admin/Feedback/{Id}",
             "~/AdminPages/FeedbackPages/ViewFeedback.aspx"
         );
        }
    }
}
