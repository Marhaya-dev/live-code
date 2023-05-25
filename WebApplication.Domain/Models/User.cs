using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int ClientId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }     
    }
}
