using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSPP.Areas.Admin.Models
{
    public class MovieAddModel
    {

        public string moviename { get; set; }
        public string discription { get; set; }
        public string length { get; set; }
        public string technology { get; set; }

        public IFormFile image { get; set; }
    }
}
