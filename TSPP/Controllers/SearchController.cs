using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TSPP.Models.DB;



namespace TSPP.Controllers
{
    public class SearchController : Controller
    {
        private readonly Cinema1Context _context;

        public SearchController(Cinema1Context context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult Search(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var res1 = _context.Cinema.Select(x => x).ToList();
                var res3 = _context.Movie.Select(x => x).ToList();
                List<Cinema> cinema = null;
                List<Movie> movie = null;
                List<Comments> comments = null;
                foreach (var item in res1)
                {
                    if (item.Name.ToLower().Contains(search.ToLower()))
                    {
                        cinema.Add(item);
                        comments = _context.Comments.Select(x => x).Where(x => x.CinemaId == cinema[0].CinemaId).ToList();
                    }
                }
                foreach (var item in res3)
                {
                    if (item.Name.ToLower().Contains(search.ToLower()))
                    {
                        movie.Add(item);
                        comments = _context.Comments.Select(x => x).Where(x => x.MovieId == movie[0].MovieId).ToList();
                    }
                }
                if (cinema == null && movie == null)
                {
                    ViewBag.Message = "Вибачте за вашим запитом нічого не знайдено";

                }
                else
                {
                    if (cinema!=null)
                    {
                        ViewBag.Data = cinema;
                    }
                    else
                    {
                        ViewBag.Data = movie;
                    }
                }
                ViewBag.Comments = comments;
            }
            else
            {
                
            }
           
            return View();
        }
    }
}