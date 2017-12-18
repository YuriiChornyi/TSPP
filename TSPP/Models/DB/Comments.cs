using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TSPP.Models.DB
{
    public partial class Comments
    {
        [HiddenInput(DisplayValue = false)]
        public int CommentId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int CinemaId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int MovieId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }
        [UIHint("MultilineText")]
        [Required]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        public Cinema Cinema { get; set; }
        public Movie Movie { get; set; }
        public Users User { get; set; }
    }
}
