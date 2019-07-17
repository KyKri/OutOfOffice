using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace OutOfOffice.Models
{
    public class FormViewModel
    {
        public Request Request { get; set; }
        public List<SelectListItem> RequestType { get; set; }
        public List<SelectListItem> Status { get; set; }
    }
}