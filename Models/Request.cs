using System;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Models
{
    public class Request 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ApproverEmail { get; set; }
        public string RequestType { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LeaveDateTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ReturnDateTime { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
    }
}