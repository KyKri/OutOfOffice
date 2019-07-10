using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutOfOffice.Models
{
    public class Request 
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Approver Email")]
        [StringLength(50)]
        [Required]
        public string ApproverEmail { get; set; }

        [Display(Name = "Request Type")]
        [Required]
        public string RequestType { get; set; }

        [Display(Name = "Leave Date Time")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime LeaveDateTime { get; set; }

        [Display(Name = "Return Date Time")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime ReturnDateTime { get; set; }
        
        [Required]
        public string Reason { get; set; }

        public string Status { get; set; }
    }
}