using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApp.Models
{
    public class CustomerModel : DbContext
    {
        public int  CUstomerID { get; set; }
        public string Name { get; set; }
    }
}
