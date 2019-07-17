using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OutOfOffice.Models;

namespace OutOfOffice.Controllers
{
    public class OutOfOfficeController : Controller
    {
        private readonly OutOfOfficeContext _context;

        public OutOfOfficeController(OutOfOfficeContext context)
        {
            _context = context;
        }

        // GET: OutOfOffice
        public async Task<IActionResult> Index(string requestStatus, string searchString, string sortOrder)
        {
            IQueryable<string> statusQuery = from r in _context.Request orderby r.Status select r.Status;

            var requests = from r in _context.Request select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                requests = requests.Where(s => s.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(requestStatus))
            {
                requests = requests.Where(t => t.Status == requestStatus);
            }

            ViewData["NameSort"] = String.IsNullOrEmpty(sortOrder) ? "nameDesc" : "";

            switch(sortOrder)
            {
                case "nameDesc": 
                    requests = requests.OrderByDescending(r => r.Name);
                    break;
                default:
                    requests = requests.OrderBy(r => r.Name);
                    break;
            }

            var statusViewModel = new StatusViewModel
            {
                Status = new SelectList(await statusQuery.Distinct().ToListAsync()),
                Requests = await requests.ToListAsync()
            };

            return View(statusViewModel);
        }

        // GET: OutOfOffice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: OutOfOffice/Create
        public IActionResult Create()
        {
            FormViewModel model = new FormViewModel();
            model.RequestType = new List<SelectListItem>
            {
                new SelectListItem { Text = "Jury Duty", Value = "Jury Duty" },
                new SelectListItem { Text = "Sick Leave", Value = "Sick Leave" },
                new SelectListItem { Text = "Vacation", Value = "Vacation" }
            };
            model.Status = new List<SelectListItem>
            {
                new SelectListItem { Text = "Pending", Value = "Pending" }
            };

            return View(model);
        }

        // POST: OutOfOffice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,ApproverName,ApproverEmail,RequestType,LeaveDateTime,ReturnDateTime,Reason,Status")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: OutOfOffice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            FormViewModel model = new FormViewModel();
            model.RequestType = new List<SelectListItem>
            {
                new SelectListItem { Text = "Jury Duty", Value = "Jury Duty" },
                new SelectListItem { Text = "Sick Leave", Value = "Sick Leave" },
                new SelectListItem { Text = "Vacation", Value = "Vacation" }
            };
            model.Status = new List<SelectListItem>
            {
                new SelectListItem { Text = "Pending", Value = "Pending" },
                new SelectListItem { Text = "Approved", Value = "Approved" },
                new SelectListItem { Text = "Declined", Value = "Declined" },
                new SelectListItem { Text = "Cancelled", Value = "Cancelled" }
            };
            model.Request = request;

            return View(model);
        }

        // POST: OutOfOffice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,ApproverEmail,RequestType,LeaveDateTime,ReturnDateTime,Reason,Status")] Request request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: OutOfOffice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: OutOfOffice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Request.FindAsync(id);
            _context.Request.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Request.Any(e => e.Id == id);
        }
    }
}
