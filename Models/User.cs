using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecom.Models
{ 
    [Table("User")]
    public class  User
    {    
        [Key]
    [ScaffoldColumn(false)]
    public int UserId { get; set; }
    [Required(ErrorMessage = "name is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "email is required")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required(ErrorMessage = "DOB is required")]
    public string Contact { get; set; }
    [Required(ErrorMessage = "Password  is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }    
}
}
