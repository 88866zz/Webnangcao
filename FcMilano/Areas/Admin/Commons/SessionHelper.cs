using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FcMilano.Areas.Admin.Commons
{
    public class SessionHelper
    {
        public static void SetSession(UserSession session)
        {
            HttpContext.Current.Session["SessionLogin"] = session;
        }

        public static UserSession GetSession()
        {
            return HttpContext.Current.Session["SessionLogin"] as UserSession;
        }

    }
}