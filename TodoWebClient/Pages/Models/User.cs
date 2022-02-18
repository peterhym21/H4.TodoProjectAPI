using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoWebClient.Pages.Models
{
    public class User
    {
        public string? Name { get; set; }    
        public string? Email { get; set; }
        public string? ProfileImage { get; set; }

        public string Expiration { get; set; }
        public string Authentication { get; set; }

    }
}
