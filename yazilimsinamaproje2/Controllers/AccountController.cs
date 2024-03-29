﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yazilimsinamaproje2.Identity;
using yazilimsinamaproje2.Models;

namespace yazilimsinamaproje2.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<ApplicationUser> userManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            userManager =new UserManager<ApplicationUser>(userStore);
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register() 
        {        
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;

                var result = userManager.Create(user,model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                } 
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("",error);
                    }
                }


            }
            return View(model);
        }
    }
}