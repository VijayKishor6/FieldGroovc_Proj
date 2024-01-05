using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;


namespace CRUD.Domain.Models
{
    public class Register 
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int UserID { get; set; }
       
        [Required]
        public string?  Name { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Createdby { get; set; } 
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public string? Updatedby { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool IsAdmin { get; set; }     
      
    }

 
}
