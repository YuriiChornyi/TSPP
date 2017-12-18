using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSPP.Models.DB;

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
        public IActionResult AddMovie(Movie m)
        {
            _context.Movie.Add(m);
            _context.SaveChangesAsync();
            return View();
        }
    }
}