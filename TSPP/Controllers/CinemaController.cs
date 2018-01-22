using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSPP.Models.DB;

namespace TSPP.Controllers
{
    public class CinemaController : Controller
    {
        private readonly Cinema1Context _context;

        public CinemaController(Cinema1Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cookie = Request.Cookies["User"];
            if (cookie != null)
            {
                ViewBag.UserId = cookie;
            }
            return View(_context.Cinema);

        }

        public IActionResult Info(int? id)
        {
            var cookie = Request.Cookies["User"];
            if (cookie != null)
            {
                ViewBag.UserId = cookie;
            }
            if (id != null)
            {
                // var res = _context.Cinema.Select(x => x).Where(x => x.CinemaId == id);
                List<Cinema> c = _context.Cinema.Where(x => x.CinemaId == id).ToList();
                Cinema s = c[0];
                return View(s);
            }
            else
            {
                return RedirectToPage("Error");
            }



        }
    }
}