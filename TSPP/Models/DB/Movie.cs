using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSPP.Models.DB
{
    public partial class Movie
    {
        public Movie()
        {
            Comments = new HashSet<Comments>();
            Session = new HashSet<Session>();
        }
        [HiddenInput(DisplayValue = false)]
        public int MovieId { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 10)]
        [Display(Name = "Movie name")]
        public string Name { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 10)]
        [Display(Name = "Discription")]
        public string Discription { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 10)]
        [Display(Name = "Discription")]
        public int Length { get; set; }

        public byte[] Img { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Tecnology")]
        public string Tecnology { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public ICollection<Session> Session { get; set; }
    }
}
