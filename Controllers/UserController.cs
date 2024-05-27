using Microsoft.AspNetCore.Mvc;
using KhumaloCraft.Models;

namespace KhumaloCraft.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
         public IActionResult About(Users user)
        {
            if (ModelState.IsValid)
            {
                var result = Users.insert_User(user);   
                if (result > 0)
                {
                    return RedirectToAction("Index", "Home");   
                }
            }
            return View(user);
        }
    }
}
