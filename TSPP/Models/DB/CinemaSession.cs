using System;
using System.Collections.Generic;

namespace TSPP.Models.DB
{
    public partial class CinemaSession
    {
        public int CinemaSessionId { get; set; }
        public int CinemaId { get; set; }
        public int SessionId { get; set; }

        public Cinema Cinema { get; set; }
        public Session CinemaNavigation { get; set; }
    }
}
