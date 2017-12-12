using System;
using System.Collections.Generic;

namespace TSPP.Models.DB
{
    public partial class Cinema
    {
        public Cinema()
        {
            CinemaSession = new HashSet<CinemaSession>();
            Comments = new HashSet<Comments>();
        }

        public int CinemaId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int SessionId { get; set; }

        public ICollection<CinemaSession> CinemaSession { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
