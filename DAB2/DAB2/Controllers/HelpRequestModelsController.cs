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
    public class HelpRequestModelsController : Controller
    {
        private readonly HelpContext _context;

        public HelpRequestModelsController(HelpContext context)
        {
            _context = context;
        }

        // GET: HelpRequestModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.HelpRequestModel.ToListAsync());
        }

        // GET: HelpRequestModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpRequestModel = await _context.HelpRequestModel
                .FirstOrDefaultAsync(m => m.HelpRequestId == id);
            if (helpRequestModel == null)
            {
                return NotFound();
            }

            return View(helpRequestModel);
        }

        // GET: HelpRequestModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HelpRequestModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HelpRequestId")] HelpRequestModel helpRequestModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(helpRequestModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(helpRequestModel);
        }

        // GET: HelpRequestModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpRequestModel = await _context.HelpRequestModel.FindAsync(id);
            if (helpRequestModel == null)
            {
                return NotFound();
            }
            return View(helpRequestModel);
        }

        // POST: HelpRequestModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HelpRequestId")] HelpRequestModel helpRequestModel)
        {
            if (id != helpRequestModel.HelpRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(helpRequestModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HelpRequestModelExists(helpRequestModel.HelpRequestId))
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
            return View(helpRequestModel);
        }

        // GET: HelpRequestModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpRequestModel = await _context.HelpRequestModel
                .FirstOrDefaultAsync(m => m.HelpRequestId == id);
            if (helpRequestModel == null)
            {
                return NotFound();
            }

            return View(helpRequestModel);
        }

        // POST: HelpRequestModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var helpRequestModel = await _context.HelpRequestModel.FindAsync(id);
            _context.HelpRequestModel.Remove(helpRequestModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HelpRequestModelExists(int id)
        {
            return _context.HelpRequestModel.Any(e => e.HelpRequestId == id);
        }
    }
}
