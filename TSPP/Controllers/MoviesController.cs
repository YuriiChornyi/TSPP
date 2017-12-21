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
            return View(await _context.Movie.ToListAsync());
        }
        public async Task<IActionResult> Index1(int? id)
        {
            var res = _context.Movie.Select(x => x).ToList();
            List<Movie> res1 = null;
            List<Comments> res2 = null;
            if (id != null)
            {
                res1 = res.Select(x => x).Where(x => x.MovieId == id).ToList();
                res2 = _context.Comments.Where(x => x.MovieId == id).ToList();
            }
            var res0 = from _coments in _context.Comments
                       join movies in _context.Movie on _coments.MovieId equals movies.MovieId
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
            MovieModel mm=null;
            List<Comment1> list = new List<Comment1>();
            foreach (var item in res00)
            {
                Comment1 ctx= new Comment1(item.CommentId, item.CommentText, item.UserId, item.UserName);
                list.Add(ctx);
                mm =new MovieModel(item.MovieId,item.MovieName,item.Discription,item.Length,item.Img,item.Tecnology,list);
            }
          return View(mm);
        }

    }
}
