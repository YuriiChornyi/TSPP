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
        public async Task<IActionResult> Index(int ?id)
        {
            return View();
        }

    }
}
