using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace OutOfOffice.Models
{
    public class StatusViewModel
    {
        public List<Request> Requests { get; set; }
        public SelectList Status { get; set; }
        public string RequestStatus { get; set; }
        public string SearchString { get; set; }
    }
}