using emlakBizim.Identity;
using emlakBizim.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace emlakBizim.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        //get
        public ActionResult SifreDegistir()
        {
            return View();
        }

        //post
        [HttpPost]
        [Authorize]
        public ActionResult SifreDegistir(SifreDegistirme model)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.ChangePassword(User.Identity.GetUserId(), model.oldPassword, model.newPassword);

                return View("Update");
            }

            return View(model);
        }

        //get
        public ActionResult Profil()
        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
            var user = UserManager.FindById(id);

            var data = new ProfilGuncelleme()
            {
                id = user.Id,
                name = user.name,
                userName = user.UserName,
                surname = user.surname,
                email = user.Email
            };

            return View(data);
        }

        //post
        [HttpPost]
        public ActionResult Profil(ProfilGuncelleme model)
        {
            var user = UserManager.FindById(model.id);
            user.name = model.name;
            user.surname = model.surname;
            user.UserName = model.userName;
            user.Email = model.email;

            UserManager.Update(user);

            return View("Update");
        }

        //get
        public ActionResult Login()
        {
            return View();
        }

        //post
        [HttpPost]
        public ActionResult Login(Login model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.userName, model.password);
                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();

                    authProperties.IsPersistent = model.rememberMe;
                    authManager.SignIn(authProperties, identityclaims);

                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı yok!");
                }
            }

            return View(model);
        }

        public ActionResult LogOut()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.name = register.name;
                user.UserName = register.userName;
                user.surname = register.surname;
                user.Email = register.email;

                var result = UserManager.Create(user, register.password);

                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }

                    return RedirectToAction("Login", "Account");
                } 
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma Hatası!");
                }

            }

            return View(register);
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}