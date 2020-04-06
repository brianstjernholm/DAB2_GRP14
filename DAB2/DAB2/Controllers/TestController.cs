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
    public class TestController : Controller
    {
        private readonly HelpContext _context;

        public TestController(HelpContext context)
        {
            _context = context;
        }

        // GET: Test
        public async Task<IActionResult> Index()
        {
            var helpContext = _context.StudentAssignmentModel.Include(s => s.Assignment).Include(s => s.Student);
            return View(await helpContext.ToListAsync());
        }

        // GET: Test/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAssignmentModel = await _context.StudentAssignmentModel
                .Include(s => s.Assignment)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (studentAssignmentModel == null)
            {
                return NotFound();
            }

            return View(studentAssignmentModel);
        }

        // GET: Test/Create
        public IActionResult Create()
        {
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId");
            ViewData["AuId"] = new SelectList(_context.Students, "AuId", "AuId");
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentAssignmentModelId,AuId,AssignmentId")] StudentAssignmentModel studentAssignmentModel)
        {
            var student = _context.Students.Where(s => s.AuId == studentAssignmentModel.AuId).FirstOrDefault();
            var assignment = _context.Assignments.Where(a => a.AssignmentId == studentAssignmentModel.AssignmentId).FirstOrDefault();

            //if (student == null || assignment == null)
            //{
            //    return null;
            //}

            var stm = new StudentAssignmentModel();
            stm.Student = student;
            stm.Assignment = assignment;


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

        // GET: Test/Edit/5
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

        // POST: Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentAssignmentModelId,AuId,AssignmentId")] StudentAssignmentModel studentAssignmentModel)
        {
            if (id != studentAssignmentModel.AssignmentId)
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
                    if (!StudentAssignmentModelExists(studentAssignmentModel.AssignmentId))
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

        // GET: Test/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //var sam = _context.StudentAssignmentModel.Where(s => s.StudentAssignmentModelId == id).FirstOrDefault();

            if (id == null)
            {
                return NotFound();
            }

            var studentAssignmentModel = await _context.StudentAssignmentModel
                .Include(s => s.Assignment)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.AssignmentId == id);
            if (studentAssignmentModel == null)
            {
                return NotFound();
            }

            return View(studentAssignmentModel); //studentAssignmentModel
        }

        // POST: Test/Delete/5
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
            return _context.StudentAssignmentModel.Any(e => e.AssignmentId == id);
        }
    }
}
