using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSPP.Models.DB;
using TSPP.Areas.Admin.Models;
using System.IO;

namespace TSPP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddInfoController : Controller
    {
        private readonly Cinema1Context _context;

        public AddInfoController(Cinema1Context context)
        {
            _context = context;
        }
        public ActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(MovieAddModel mam)
        {
            Movie m = new Movie() { Name = mam.moviename, Discription = mam.discription, Length = Convert.ToInt32(mam.length), Tecnology = mam.technology };
            if (mam.image != null)
            {
                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(mam.image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)mam.image.Length);
                }
                // установка массива байтов
                m.Img = imageData;
            }
            _context.Movie.Add(m);
            _context.SaveChanges();
            return RedirectToAction("AddMovie");
        }

        public ActionResult AddCinema()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCinema(string cinemaname, string address)
        {
            Cinema c = new Cinema() { Name = cinemaname, Address = address, SessionId = 7 };
            _context.Cinema.Add(c);
            _context.SaveChanges();
            return RedirectToAction("AddMovie");
        }



        public ActionResult AddSession()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSession(string movieid, string hallid, string datetime)
        {
            Session s = new Session() { MovieId = Convert.ToInt32(movieid), HallId = Convert.ToInt32(hallid), DateTime = Convert.ToDateTime(datetime) };
            _context.Session.Add(s);
            _context.SaveChanges();
            return RedirectToAction("AddMovie");
        }
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(string name, string email, string password, bool isadmin)
        {
            var res = _context.Users.Where(x => x.Email == email).Select(x => x.UserId).ToList();
            if (res.Count != 0)
            {
                return RedirectToAction("AddMovie");
            }
            else
            {
                Users u = new Users() { Name = name, Email = email, Password = password, IsAdmin = isadmin };
            _context.Users.Add(u);
                _context.SaveChanges();
                return RedirectToAction("AddMovie");
            }

        }


    }
}