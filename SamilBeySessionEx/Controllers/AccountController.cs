using Microsoft.AspNetCore.Mvc;
using SamilBeySessionEx.Models;

namespace SamilBeySessionEx.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            var user = Data.Users.Where(i=>i.Username== model.Username).FirstOrDefault();
            if(user != null)
            {
                if (user.Password == model.Password)
                {
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "user", user);
                    Data.LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session,"user");
                    return RedirectToAction("Index", "Home");
                }
                  
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            User user = null;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "user", user);
            Data.LoginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            return RedirectToAction("Index", "Home");
        }
    }
}
