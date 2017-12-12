using System;
using System.Collections.Generic;

namespace TSPP.Models.DB
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Comments> Comments { get; set; }
    }
}
