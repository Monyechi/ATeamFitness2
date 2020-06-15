using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATeamFitness.Data;
using ATeamFitness.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ATeamFitness.Controllers
    
{
    
    [Authorize(Roles = "Customer")]
    
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

        [HttpGet("{id}")]
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
        public async Task<IActionResult> Create([Bind("PlanId,DietType,FitnessGoal,FoodOptionA,FoodOptionB,FoodOptionC,Identity UserId")] DietPlan dietPlan)
        {
            if (ModelState.IsValid)
            {
                if (dietPlan.PlanId == 0)
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    dietPlan.IdentityUserId = userId;
                    _context.DietPlans.Add(dietPlan);
                }

                else
                {
                    var dietPlanInDb = _context.DietPlans.Single(c => c.PlanId == dietPlan.PlanId);
                    dietPlanInDb.DietType = dietPlan.DietType;
                    dietPlanInDb.FitnessGoal = dietPlan.FitnessGoal;
                    dietPlanInDb.FoodOptionA = dietPlan.FoodOptionA;
                    dietPlanInDb.FoodOptionB = dietPlan.FoodOptionB;
                    dietPlanInDb.FoodOptionC = dietPlan.FoodOptionC;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = dietPlan.PlanId.ToString() });

            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "PlanId", "PlanId", dietPlan.IdentityUserId);
            return View(dietPlan);




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
        public async Task<IActionResult> Edit(int id, [Bind("PlanId,DietType,FitnessGoal,FoodOptionA,FoodOptionB,FoodOptionC,Identity UserId")]DietPlan dietPlan)
        {
           if(id != dietPlan.PlanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var dietPlanInDb = _context.DietPlans.Single(c => c.PlanId == dietPlan.PlanId);
                    dietPlanInDb.DietType = dietPlan.DietType;
                    dietPlanInDb.FitnessGoal = dietPlan.FitnessGoal;
                    dietPlanInDb.FoodOptionA = dietPlan.FoodOptionA;
                    dietPlanInDb.FoodOptionB = dietPlan.FoodOptionB;
                    dietPlanInDb.FoodOptionC = dietPlan.FoodOptionC;

                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if ( !DietPlansExists (dietPlan.PlanId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = dietPlan.PlanId.ToString() });
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "PlanId", "PlanId", dietPlan.IdentityUserId);
            return View(dietPlan);
        }

        // GET: DietPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: DietPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dietPlan = await _context.DietPlans.FindAsync(id);
            _context.DietPlans.Remove(dietPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DietPlansExists(int id)
        {
            return _context.DietPlans.Any(e => e.PlanId == id);
        }
    }
}
