using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DWF;

namespace account.Models
{
    public class Account : database
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool Admin_Permission { get; set; }
    }
}