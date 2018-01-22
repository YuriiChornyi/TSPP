using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TSPP.Models.DB;
using TSPP.Models.ViewModels;

namespace TSPP.Controllers
{
    public class SessionController : Controller
    {
        private readonly Cinema1Context _context;

        public SessionController(Cinema1Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var res = _context.Session.Select(x => x).ToList();
            var res1 = from _session in _context.Session
                       join _movie in _context.Movie on _session.MovieId equals _movie.MovieId
                       select new
                       {
                           SessionId = _session.SessionId,
                           Date = _session.DateTime,
                           MovieId = _movie.MovieId,
                           MovieName = _movie.Name,
                           MovieImg = _movie.Img,
                           HallId = _session.HallId
                       };
            var res2 = from _session in res1
                       join _cinemasession in _context.CinemaSession on _session.SessionId equals _cinemasession.SessionId
                       select new
                       {
                           CinemaId = _cinemasession.CinemaId,
                           SessionId = _session.SessionId
                       };

            var res3 = from _cinemasession in res2
                       join _cinema in _context.Cinema on _cinemasession.CinemaId equals _cinema.CinemaId
                       select new
                       {
                           SessionId = _cinemasession.SessionId,
                           CinemaId = _cinema.CinemaId,
                           CinemaName = _cinema.Name
                       };
            var res4 = from r1 in res1
                       join r3 in res3 on r1.SessionId equals r3.SessionId
                       select new
                       {
                           SessionId = r1.SessionId,
                           Date = r1.Date,
                           HallId = r1.HallId,
                           MovieId = r1.MovieId,
                           MovieName = r1.MovieName,
                           MovieImg = r1.MovieImg,
                           CinemaId = r3.CinemaId,
                           CinemaName = r3.CinemaName
                       };

            List<SessionsModel> list=new List<SessionsModel>();
            foreach (var item in res4)
            {
                SessionsModel s=new SessionsModel(item.SessionId,item.Date,item.HallId,item.MovieId,item.MovieName,item.MovieImg,item.CinemaId,item.CinemaName);
                list.Add(s);
            }
            var cookie = Request.Cookies["User"];
            if (cookie != null)
            {
                ViewBag.UserId = cookie;
            }

            return View(list);
        }
        public IActionResult Session()
        {
            return View();
        }
    }
}