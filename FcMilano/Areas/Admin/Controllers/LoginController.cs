using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FcMilano.Areas.Admin.Models;
using FcMilano.Areas.Admin.Commons;



namespace FcMilano.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {   
        [HttpGet]
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            if (Membership.ValidateUser(model.UserName, model.Password) && ModelState.IsValid)
            {
                //luu session de check hien thi
                User user = new AccountDAO().GetUserByUserName(model.UserName, model.Password);
                SessionHelper.SetSession(new UserSession() { userStatic = user });
                //session de kiem tra dang nhap
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                ModelState.AddModelError("", "UserName hoặc password không đúng");
            }
            return View(model);
        }




        // GET: Admin/Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
