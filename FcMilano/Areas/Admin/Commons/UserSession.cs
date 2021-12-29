using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FcMilano.Areas.Admin.Commons
{
    [Serializable]
    public class UserSession
    {
        public string UserName { set; get; }
    }

}