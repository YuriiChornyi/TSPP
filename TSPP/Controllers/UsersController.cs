using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSPP.Models.DB;

namespace TSPP.Controllers
{
    public class UsersController : Controller
    {
        private readonly Cinema1Context _context;

        public UsersController(Cinema1Context context)
        {
            _context = context;
        }

        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult Exit()
        {
            Response.Cookies.Delete("User");
            return RedirectToAction("Index", "Movies");
        }

        [HttpPost]
        public ActionResult LogIn(Users u)
        {
            var users = _context.Users.Select(x => x).ToList();
            foreach (var item in users)
            {
                if (item.Email == u.Email)
                {
                    if (item.Password == u.Password)
                    {
                        if (item.IsAdmin)
                        {
                            return RedirectToAction("AddMovie", "AddInfo", new { area = "Admin" });
                        }
                        else
                        {
                            CookieOptions option = new CookieOptions();
                            option.Expires = DateTime.Now.AddDays(2);

                            Response.Cookies.Append("User", item.UserId.ToString(), option);

                            //Request.Cookies["User"]
                            return RedirectToAction("Index", "Movies");
                        }

                    }
                }
            }
            return View();
        }
        // GET: Users
        public async Task<IActionResult> Index()
        {
            var cookie = Request.Cookies["User"];
            if (cookie != null)
            {
                ViewBag.UserId = cookie;
            }
            return View(await _context.Users.ToListAsync());
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users u)
        {
            var users = _context.Users.Where(x => x.Email == u.Email).Select(x => x.UserId).ToList();
            if (users.Count!=0)
            {
                ViewBag.Message = "Такий користувач вже зареєстрований";
                return RedirectToAction("LogIn", "Users");
            }
            else
            {
                Users ur = new Users() { Name = u.Name, Email = u.Email, Password = u.Password, IsAdmin = false };
                _context.Users.Add(ur);
                _context.SaveChanges();
                ViewBag.Message = "Ви успішно зареєструвались";
                return RedirectToAction("LogIn", "Users");

            }
           
        }
    }
}
