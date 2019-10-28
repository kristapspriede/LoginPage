using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RegistrationLogin.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }
        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is required!")]
        public string UserName { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required!")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required!")]
        public string LastName { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Confirm password")]
        [Compare("Password", ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}