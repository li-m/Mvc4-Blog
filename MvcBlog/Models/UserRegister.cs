using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MvcBlog.Models
{
    public class UserRegister : User
    {
        /// <summary>
        /// Password
        /// </summary>
        [Display(Name = "Password", Description = "6 - 20characters")]
        [Required(ErrorMessage = "k")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "k")]
        [DataType(DataType.Password)]
        public new string Password { get; set; }

        /// <summary>
        /// Comfirm password
        /// </summary>
        [Display(Name = "Comfirm password", Description = "Re-enter your password")]
        [Compare("Password", ErrorMessage = "k")]
        [DataType(DataType.Password)]
        public string ComfirmPassword { get; set; }

        /// <summary>
        /// Captcha
        /// </summary>
        [Display(Name = "Captcha", Description = "Enter the characters you see")]
        [Required(ErrorMessage = "k")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "k")]
        public string Captcha { get; set; }
    }
}