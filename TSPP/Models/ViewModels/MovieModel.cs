using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSPP.Models.ViewModels
{
    public class MovieModel
    {
        public MovieModel( int movieId, string movieName, string discription, int length, byte[] img, string technology,List<Comment1> cc)
        {
            c = cc;
            MovieId = movieId;
            MovieName = movieName;
            Discription = discription;
            Length = length;
            Img = img;
            Tecnology = technology;
        }

        public List<Comment1> c { get; set; }
        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public string Discription { get; set; }

        public int Length { get; set; }

        public byte[] Img { get; set; }

        public string Tecnology { get; set; }
    }

    public class Comment1
    {
        public Comment1(int commentId, string commentText, int userId, string userName)
        {
            CommentId = commentId;
            CommentText = commentText;
            UserId = userId;
            UserName = userName;
        }
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
