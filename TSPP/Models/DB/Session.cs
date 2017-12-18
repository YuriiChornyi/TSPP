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
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int HallId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int MovieId { get; set; }

        public Hall Hall { get; set; }
        public Movie Movie { get; set; }
        public ICollection<CinemaSession> CinemaSession { get; set; }
    }
}
