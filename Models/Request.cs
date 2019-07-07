using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutOfOffice.Models
{
    public class Request 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Approver Email")]
        public string ApproverEmail { get; set; }
        [Display(Name = "Request Type")]
        public string RequestType { get; set; }
        [Display(Name = "Leave Date Time")]
        [DataType(DataType.DateTime)]
        public DateTime LeaveDateTime { get; set; }
        [Display(Name = "Return Date Time")]
        [DataType(DataType.DateTime)]
        public DateTime ReturnDateTime { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
    }
}