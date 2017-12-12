using System;
using System.Collections.Generic;

namespace TSPP.Models.DB
{
    public partial class Comments
    {
        public int CommentId { get; set; }
        public int CinemaId { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }

        public Cinema Cinema { get; set; }
        public Movie Movie { get; set; }
        public Users User { get; set; }
    }
}
