using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSPP.Models.DB
{
    public partial class Hall
    {
        public Hall()
        {
            Session = new HashSet<Session>();
        }
        [HiddenInput(DisplayValue = false)]
        public int HallId { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int SeatsCount { get; set; }

        public ICollection<Session> Session { get; set; }
    }
}
