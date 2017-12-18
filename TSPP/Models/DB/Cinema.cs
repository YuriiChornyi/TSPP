using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TSPP.Models.DB
{
    public partial class Cinema
    {
        public Cinema()
        {
            CinemaSession = new HashSet<CinemaSession>();
            Comments = new HashSet<Comments>();
        }
        [HiddenInput(DisplayValue = false)]
        public int CinemaId { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 10)]
        [Display(Name = "Cinema name")]
        public string Name { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 10)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int SessionId { get; set; }

        public ICollection<CinemaSession> CinemaSession { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
