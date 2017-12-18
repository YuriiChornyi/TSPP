using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TSPP.Models.DB
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
        }
        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3)]
        [Display(Name = "User name")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 7)]
        [Display(Name = "Email")]
        [UIHint("Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6)]
        [Display(Name = "Password")]
        [UIHint("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [ScaffoldColumn(true)]
        public bool IsAdmin { get; set; }

        public ICollection<Comments> Comments { get; set; }
    }
}
