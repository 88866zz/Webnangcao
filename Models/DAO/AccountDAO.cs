using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
using System.Linq;
using Models.DAO;
using Models.EF;

namespace Models
{
    public class AccountDAO: BaseModel
    {


        public bool Login(ref string err, string UserName, string Password)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@UserName",UserName),
                 new SqlParameter("@Password",Password)
            };

                return context.Database.SqlQuery<bool>("SP_Account_Login @UserName,@Password", param).SingleOrDefault();
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return false;
        }



        public User GetUserByUserName(string UserName, string Password)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@UserName",UserName),
                 new SqlParameter("@Password",Password)
            };

            return context.Database.SqlQuery<User>("SP_GetUserByUserName @UserName,@Password", param).SingleOrDefault();
        }
        
           

        

    }
}

 




