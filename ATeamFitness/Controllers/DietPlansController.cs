﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATeamFitness.Data;
using ATeamFitness.Models;
using System.Security.Claims;

namespace ATeamFitness.Controllers
{
    [ApiController]
    public class DietPlansController : Controller
    {
       

        private readonly ApplicationDbContext _context;

        public DietPlansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DietPlans
        public async Task<IActionResult> Index()
        {


            var applicationDbContext = _context.DietPlans.Include(c => c.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }


           

        // GET: DietPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietPlan = await _context.DietPlans
                .FirstOrDefaultAsync(m => m.PlanId == id);
            if (dietPlan == null)
            {
                return NotFound();
            }

            return View(dietPlan);
        }

        // GET: DietPlans/Create
        public IActionResult Create()
        {
            DietPlan dietPlan = new DietPlan();
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View(dietPlan);
        }

        // POST: DietPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanId,DietType,FitnessGoal,FoodOptionA,FoodOptionB,FoodOptionC")] DietPlan dietPlans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dietPlans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dietPlans);
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<DietPlan>> PostTodoItem(DietPlan dietPlan)
        {
            _context.DietPlans.Add(dietPlan);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(DietPlan), new { id = dietPlan.PlanId }, dietPlan);
        }

        // GET: DietPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietPlans = await _context.DietPlans.FindAsync(id);
            if (dietPlans == null)
            {
                return NotFound();
            }
            return View(dietPlans);
        }

        // POST: DietPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlanId,DietType,FitnessGoal,FoodOptionA,FoodOptionB,FoodOptionC")] DietPlan dietPlans)
        {
            if (id != dietPlans.PlanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dietPlans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DietPlansExists(dietPlans.PlanId))
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
            return View(dietPlans);
        }

        // GET: DietPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dietPlans = await _context.DietPlans
                .FirstOrDefaultAsync(m => m.PlanId == id);
            if (dietPlans == null)
            {
                return NotFound();
            }

            return View(dietPlans);
        }

        // POST: DietPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dietPlans = await _context.DietPlans.FindAsync(id);
            _context.DietPlans.Remove(dietPlans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DietPlansExists(int id)
        {
            return _context.DietPlans.Any(e => e.PlanId == id);
        }
    }
}
