using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSPP.Models.DB;

namespace TSPP.Controllers
{
    public class MoviesController : Controller
    {
        private readonly Cinema1Context _context;

        public MoviesController(Cinema1Context context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }
        public async Task<IActionResult> Index1(int ?id)
        {
            var res = _context.Movie.Select(x => x).ToList();
            List<Movie> res1=null;
            if (id!=null)
            {
                res1 = res.Select(x => x).Where(x => x.MovieId == id).ToList();
            }
            ViewBag.Movie = res1;
            return View(res1);
        }

    }
}
