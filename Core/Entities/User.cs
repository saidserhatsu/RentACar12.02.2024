using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User:Entity<int> 
    {
        public string FirstName { get; set; }=null;
        public string LastName { get; set; } = null;
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; } // hashing
        public byte[] PasswordSalt { get; set; } // salting

        public bool Approved { get; set; }

    }
}
