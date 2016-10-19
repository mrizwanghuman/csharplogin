using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class UserData
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="This field is required.")]
        public string firstName { get; set; }
        [Required (ErrorMessage ="This field is required")]
        public string lastName { get; set; }
        [Required(ErrorMessage ="this is required.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}