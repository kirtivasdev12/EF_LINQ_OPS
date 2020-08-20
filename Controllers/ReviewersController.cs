using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EF_LINQ_OPS.DataAccess;
using EF_LINQ_OPS.Models;

namespace EF_LINQ_OPS.Controllers
{
    public class ReviewersController : Controller
    {
        private readonly AppDBContext _context;

        public ReviewersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Reviewers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reviewers.ToListAsync());
        }

        // GET: Reviewers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewer = await _context.Reviewers
                .FirstOrDefaultAsync(m => m.reviewer_id == id);
            if (reviewer == null)
            {
                return NotFound();
            }

            return View(reviewer);
        }

        // GET: Reviewers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reviewers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("reviewer_id,f_name,l_name,city,state,num_review")] Reviewer reviewer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviewer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reviewer);
        }

        // GET: Reviewers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewer = await _context.Reviewers.FindAsync(id);
            if (reviewer == null)
            {
                return NotFound();
            }
            return View(reviewer);
        }

        // POST: Reviewers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("reviewer_id,f_name,l_name,city,state,num_review")] Reviewer reviewer)
        {
            if (id != reviewer.reviewer_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewerExists(reviewer.reviewer_id))
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
            return View(reviewer);
        }

        // GET: Reviewers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewer = await _context.Reviewers
                .FirstOrDefaultAsync(m => m.reviewer_id == id);
            if (reviewer == null)
            {
                return NotFound();
            }

            return View(reviewer);
        }

        // POST: Reviewers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviewer = await _context.Reviewers.FindAsync(id);
            _context.Reviewers.Remove(reviewer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewerExists(int id)
        {
            return _context.Reviewers.Any(e => e.reviewer_id == id);
        }
    }
}
