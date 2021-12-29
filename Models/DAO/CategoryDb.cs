﻿using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
   public class CategoryDb
    {
       MilanoShopDbContext context;
       public CategoryDb()
       {
           context = new MilanoShopDbContext();
       }

       public List<Category> GetCategories(int id)
       {
           SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@id",id)
           };
           return context.Database.SqlQuery<Category>("PSP_Category_Select @id", param).ToList();
       }

       public Category GetCategoryByID(int id)
       {
           SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@id",id)
           };
           return context.Database.SqlQuery<Category>("PSP_Category_Select @id", param).SingleOrDefault();
       }

       public int InsertAndUpdateCategory( Category cat)
       {
           SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@id",cat.ID),
                new SqlParameter("@Name",cat.Name),
                 new SqlParameter("@MetaTitle",cat.MetaTitle)
                 //...Them cho du thuonc tinsh
           };
           return context.Database.ExecuteSqlCommand("PSP_Category_InsertAndUpdate @id,@Name", param);
       }
       public int DeleteCategory(long id)
       {
           SqlParameter[] param = new SqlParameter[]{
               new SqlParameter("@id",id)
              
           };
           return context.Database.ExecuteSqlCommand("PSP_Category_Delete @id", param);
       }
    }
}
