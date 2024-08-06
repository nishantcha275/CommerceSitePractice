using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public  class LoginClass
    {
      

        public int Id { get; set; }
        [Required(ErrorMessage = "Username is requried!")]
        public string? Username { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is requried!")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }
    }

    public class Result
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public LoginClass? Data { get; set; }
    }
}
