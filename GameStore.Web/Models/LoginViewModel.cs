using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameStore.Web.Models
{
    public class LoginViewModel
    {

        //[Required]
        public string Email { get; set; }
        //[Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}