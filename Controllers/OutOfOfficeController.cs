using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace OutOfOffice.Controllers
{
    public class OutOfOfficeController : Controller
    {
        // Get OutOfOffice
        public IActionResult Index() {
            return View();
        }
    }
}