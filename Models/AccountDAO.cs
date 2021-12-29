using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AccountDAO
    {
        private MilanoShopDbContext context = null;
        public AccountDAO()
        {
            context = new MilanoShopDbContext();
        }
            public bool CheckLogin(ref string err, string userName, string passWord)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@UserName",userName),
                 new SqlParameter("@Password",passWord)
            };

                return context.Database.SqlQuery<bool>("Sp_Account_Login @UserName,@Password", param).SingleOrDefault();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return false;
        }
            public User GetUserByUserName(string userName, string passWord)
            {
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@UserName",userName),
                 new SqlParameter("@Password",passWord)
            };

                return context.Database.SqlQuery<User>("GetUserByUserName @UserName,@Password", param).SingleOrDefault();
            }


    }
}
