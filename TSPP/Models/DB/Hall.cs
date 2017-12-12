using System;
using System.Collections.Generic;

namespace TSPP.Models.DB
{
    public partial class Hall
    {
        public Hall()
        {
            Session = new HashSet<Session>();
        }

        public int HallId { get; set; }
        public int Number { get; set; }
        public int SeatsCount { get; set; }

        public ICollection<Session> Session { get; set; }
    }
}
