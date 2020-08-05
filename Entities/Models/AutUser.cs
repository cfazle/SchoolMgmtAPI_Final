using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
  public  class AutUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

