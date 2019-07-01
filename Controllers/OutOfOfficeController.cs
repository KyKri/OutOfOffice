using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace OutOfOffice.Controllers
{
    public class OutOfOfficeController : Controller
    {
        // Get OutOfOffice
        public string Index() {
            return "Welcome to Out of Office";
        }
    }
}