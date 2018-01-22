using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSPP.Models.DB;
using TSPP.Models.ViewModels;

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
            var cookie = Request.Cookies["User"];
            if (cookie != null)
            {
                ViewBag.UserId = cookie;
            }
            return View(await _context.Movie.ToListAsync());
        }
        public async Task<IActionResult> Index1(int? id)
        {
            var cookie = Request.Cookies["User"];
            if (cookie!=null)
            {
                ViewBag.UserId = cookie;
            }
            if (id != null)
            {
                var res1 = _context.Movie.Where(x => x.MovieId == id).Select(x=>x); //(from movi in _context.Movie where movi.MovieId == id select movi);
                var res2 = _context.Comments.Count(x=>x.MovieId==id);//Where(x => x.MovieId == id).Select(x => x);
                var res0 = from _coments in _context.Comments
                           join movies in res1 on _coments.MovieId equals movies.MovieId
                           select new
                           {
                               MovieId = movies.MovieId,
                               MovieName = movies.Name,
                               Discription = movies.Discription,
                               Length = movies.Length,
                               Img = movies.Img,
                               Tecnology = movies.Tecnology,
                               CommentId = _coments.CommentId,
                               CommentText = _coments.Comment,
                               UserId = _coments.UserId
                           };
                var res00 = from _user in _context.Users
                            join _usename in res0 on _user.UserId equals _usename.UserId
                            select new
                            {
                                MovieId = _usename.MovieId,
                                MovieName = _usename.MovieName,
                                Discription = _usename.Discription,
                                Length = _usename.Length,
                                Img = _usename.Img,
                                Tecnology = _usename.Tecnology,
                                CommentId = _usename.CommentId,
                                CommentText = _usename.CommentText,
                                UserId = _usename.UserId,
                                UserName = _user.Name
                            };

                //var res select new 
               
                MovieModel mm = null;
                List<Comment1> list = new List<Comment1>();
                if (res2 == 0)
                {
                    foreach (var item in res1)
                    {
                        mm = new MovieModel(item.MovieId, item.Name, item.Discription, item.Length, item.Img, item.Tecnology, list);
                    }
                }
                else
                {
                    foreach (var item in res00)
                    {
                        Comment1 ctx = new Comment1(item.CommentId, item.CommentText, item.UserId, item.UserName);
                        list.Add(ctx);
                        mm = new MovieModel(item.MovieId, item.MovieName, item.Discription, item.Length, item.Img, item.Tecnology, list);
                    }
                }
               
                return View(mm);
            }
            else
            {
                return RedirectToAction("Index","Movies");
            }

        }


        [HttpPost]
        public ActionResult Comment(string comment,int UserId,int MovieId)
        {
            Comments c = new Comments();
            c.Comment = comment;
            c.CinemaId = 1;
            c.MovieId = MovieId;
            c.UserId = UserId;
            _context.Comments.Add(c);
            _context.SaveChanges();
            return RedirectToAction("Index1", "Movies", new { id = MovieId });
        }
        public ActionResult Show()
        {
            ViewBag.Movies = _context.Movie.Select(x => x).ToList<Movie>();
            return View();
        }
    }
}
