using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApp.Models

    // What we are doing below is we are adding all properties from the IdentityUser class, and we are adding an additional
    // property called FullName which displays in the table
{
    public class ApplicationUser : IdentityUser
    {

        public string Fullname { get; set; }
    }
}
