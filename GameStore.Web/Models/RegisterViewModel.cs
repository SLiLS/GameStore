using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameStore.Web.Models
{
    public class RegisterViewModel
    {
        //[Required]
        public string Email { get; set; }
        //[Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //[Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        //[Required]
        public string Address { get; set; }
        //[Required]
        public string Name { get; set; }
    }
}