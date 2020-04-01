using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAB2.Data;
using DAB2.Models;

namespace DAB2.Controllers
{
    public class StudentAssignmentModelsController : Controller
    {
        private readonly HelpContext _context;

        public StudentAssignmentModelsController(HelpContext context)
        {
            _context = context;
        }

        // GET: StudentAssignmentModels
        public async Task<IActionResult> Index()
        {
            var helpContext = _context.StudentAssignmentModel.Include(s => s.Assignments).Include(s => s.Students);
            return View(await helpContext.ToListAsync());
        }

        // GET: StudentAssignmentModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAssignmentModel = await _context.StudentAssignmentModel
                .Include(s => s.Assignments)
                .Include(s => s.Students)
                .FirstOrDefaultAsync(m => m.AuId == id);
            if (studentAssignmentModel == null)
            {
                return NotFound();
            }

            return View(studentAssignmentModel);
        }

        // GET: StudentAssignmentModels/Create
        public IActionResult Create()
        {
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId");
            ViewData["AuId"] = new SelectList(_context.Students, "AuId", "AuId");
            return View();
        }

        // POST: StudentAssignmentModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentAssignmentModelId,AuId,AssignmentId")] StudentAssignmentModel studentAssignmentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentAssignmentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId", studentAssignmentModel.AssignmentId);
            ViewData["AuId"] = new SelectList(_context.Students, "AuId", "AuId", studentAssignmentModel.AuId);
            return View(studentAssignmentModel);
        }

        // GET: StudentAssignmentModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAssignmentModel = await _context.StudentAssignmentModel.FindAsync(id);
            if (studentAssignmentModel == null)
            {
                return NotFound();
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId", studentAssignmentModel.AssignmentId);
            ViewData["AuId"] = new SelectList(_context.Students, "AuId", "AuId", studentAssignmentModel.AuId);
            return View(studentAssignmentModel);
        }

        // POST: StudentAssignmentModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentAssignmentModelId,AuId,AssignmentId")] StudentAssignmentModel studentAssignmentModel)
        {
            if (id != studentAssignmentModel.AuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentAssignmentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentAssignmentModelExists(studentAssignmentModel.AuId))
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
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId", studentAssignmentModel.AssignmentId);
            ViewData["AuId"] = new SelectList(_context.Students, "AuId", "AuId", studentAssignmentModel.AuId);
            return View(studentAssignmentModel);
        }

        // GET: StudentAssignmentModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAssignmentModel = await _context.StudentAssignmentModel
                .Include(s => s.Assignments)
                .Include(s => s.Students)
                .FirstOrDefaultAsync(m => m.AuId == id);
            if (studentAssignmentModel == null)
            {
                return NotFound();
            }

            return View(studentAssignmentModel);
        }

        // POST: StudentAssignmentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentAssignmentModel = await _context.StudentAssignmentModel.FindAsync(id);
            _context.StudentAssignmentModel.Remove(studentAssignmentModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentAssignmentModelExists(int id)
        {
            return _context.StudentAssignmentModel.Any(e => e.AuId == id);
        }
    }
}
