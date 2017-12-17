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
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ScaffoldColumn(true)]
        public bool IsAdmin { get; set; }

        public ICollection<Comments> Comments { get; set; }
    }
}
