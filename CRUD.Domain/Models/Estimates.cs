using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Models
{
    public enum Status
    {
        EstimateAccepted=1,
        EstimateRejected=2,
        EstimateVoid=3,
        ReadyForWorkOrder=4
    }
    public class Estimates
    {
        [Key]
        public string EstimateId { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }

        [ForeignKey("Leads")]
        public int LeadsId { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public string? Name { get; set; }
        public string? LineItemIds { get; set; }
        public bool? CustomerAccepted { get; set; }
        public string? Notes { get; set; }
        public string? LocationId { get; set; }
        public bool? DefaultEstimate { get; set; }
        public string? Type { get; set; }
        public int? Number { get; set; }
        public Status Status { get; set; }
        public DateTime? DateModified { get; set; } = DateTime.Now;
        public string? Fineprint { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.Now;
        public bool? ChangeOrder { get; set; }
        public bool? ReadyForWorkOrder { get; set; }
        public int? Duration { get; set; }
        public string? SignerName { get; set; }
        public string? SignerTitle { get; set; }
        public string? SignerSignature { get; set; }
        public string? SignatureStyle { get; set; }
        public DateTime? DateSigned { get; set; } = DateTime.Now;
        public bool? Locked { get; set; }
        public bool? Dead { get; set; }
        public string? CreatedBy { get; set; }
        public bool? HidePhaseTotal { get; set; }
        public bool? DisplayDiscountAmountOnPrintable { get; set; }
        public DateTime? DateCustomerAccepted { get; set; } = DateTime.Now;
        public bool? HideEstimateTotal { get; set; }
        public decimal? DepositAmount { get; set; }
        public string? DepositAmountUnit { get; set; }
        public string? DepositNote { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaidDate { get; set; } = DateTime.Now;
        public string? PayaVaultId { get; set; }
        public string? PaymentMethodPreview { get; set; }
        public string? PayaVaultLocationId { get; set; }
        public string? Token { get; set; }
    }
}
