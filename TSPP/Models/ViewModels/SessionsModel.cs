using System;

namespace TSPP.Models.ViewModels
{
    public class SessionsModel
    {
        public SessionsModel(int sessionId, DateTime date, int hallId, int movieId, string movieName, byte[] movieImg, int cinemaId, string cinemaName)
        {
            SessionId = sessionId;
            Date = date;
            HallId = hallId;
            MovieId = movieId;
            MovieName = movieName;
            MovieImg = movieImg;
            CinemaId = cinemaId;
            CinemaName = cinemaName;
        }
        public int SessionId { get; set; }
        public DateTime Date { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public byte[] MovieImg { get; set; }
        public int CinemaId { get; set; }
        public string CinemaName { get; set; }
    }
}
