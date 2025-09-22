using Microsoft.AspNetCore.Http;

namespace ECommerceALLInOne.Helpers
{
    public static class SessionExtentions
    {
        //read user id from session storage in browser
        public static int? GetUserId(this ISession session)
        {
            return session.GetInt32("UserId");
        }
        //save user IdId in session storage in browser
        public static void SetUserId(this ISession session, int userId)
        {
            session.SetInt32("UserId", userId);

        }
        public static string GetUserRole(this ISession session)
        {
            // null or undifined ? right : left
            return session.GetString("UserRole") ?? string.Empty;
        }
        //save user id in session storage in browser
        public static void SetUserRole(this ISession session, string userRole)
        {
            session.SetString("UserRole", userRole);

        }

        //remove user Id in session storage
        public static void ClearUser(this ISession session)
        {
            session.Remove("UserId");
            session.Remove("UserRole");
        }


    }

}
