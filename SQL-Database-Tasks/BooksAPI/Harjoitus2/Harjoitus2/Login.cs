using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harjoitus2
{
    public class Login
    {
        [Key]
        public string? Pincode { get; set; }
        public string? Nickname { get; set; }

    }
}
