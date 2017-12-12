using System;
using System.Collections.Generic;

namespace TSPP.Models.DB
{
    public partial class Movie
    {
        public Movie()
        {
            Comments = new HashSet<Comments>();
            Session = new HashSet<Session>();
        }

        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int Length { get; set; }
        public byte[] Img { get; set; }
        public string Tecnology { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public ICollection<Session> Session { get; set; }
    }
}
