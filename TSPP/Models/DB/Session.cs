using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TSPP.Models.DB
{
    public partial class Session
    {
        public Session()
        {
            CinemaSession = new HashSet<CinemaSession>();
        }
        [HiddenInput(DisplayValue = false)]
        public int SessionId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        public int HallId { get; set; }
        public int MovieId { get; set; }

        public Hall Hall { get; set; }
        public Movie Movie { get; set; }
        public ICollection<CinemaSession> CinemaSession { get; set; }
    }
}
