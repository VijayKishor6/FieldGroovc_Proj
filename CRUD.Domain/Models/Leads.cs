using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Models
{
    public class Leads
    {
        [Key]
        public int LeadsId { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public string? AccountType { get; set; }
        public string? Status { get; set; }
        public string? ProjectName { get; set; }
        public bool IsOpportunity { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public string? UpdatedBy { get; set; }
    }

}
