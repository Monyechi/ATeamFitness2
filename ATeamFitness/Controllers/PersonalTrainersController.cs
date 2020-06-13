using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATeamFitness.Data;
using ATeamFitness.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ATeamFitness.Controllers
{
    [Authorize(Roles = "Trainer")]
    public class PersonalTrainersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalTrainersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonalTrainers
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var personalTrainer = _context.PersonalTrainers.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (personalTrainer == null)
            {
                return RedirectToAction("Create");
            }

            return View(personalTrainer);
        }

        // GET: PersonalTrainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalTrainer = await _context.PersonalTrainers
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.PersonalTrainerId == id);
            if (personalTrainer == null)
            {
                return NotFound();
            }

            return View(personalTrainer);
        }

        // GET: PersonalTrainers/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: PersonalTrainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonalTrainerId,Name,ZipCode,Specialization,Schedule,WorkoutCalendar,Bio,TrainerLocation,Rating,IdentityUserId")] PersonalTrainer personalTrainer,Random random)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                personalTrainer.IdentityUserId = userId;
                personalTrainer.TimeBlockId = GenerateRandomAlphanumericString();
                _context.Add(personalTrainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", personalTrainer.IdentityUserId);
            return View(personalTrainer);
        }

        // GET: PersonalTrainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalTrainer = await _context.PersonalTrainers.FindAsync(id);
            if (personalTrainer == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", personalTrainer.IdentityUserId);
            return View(personalTrainer);
        }

        // POST: PersonalTrainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonalTrainerId,Name,ZipCode,Specialization,Schedule,WorkoutCalendar,Bio,TrainerLocation,Rating,IdentityUserId")] PersonalTrainer personalTrainer)
        {
            if (id != personalTrainer.PersonalTrainerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalTrainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalTrainerExists(personalTrainer.PersonalTrainerId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", personalTrainer.IdentityUserId);
            return View(personalTrainer);
        }

        // GET: PersonalTrainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalTrainer = await _context.PersonalTrainers
                .Include(p => p.IdentityUser)
                .FirstOrDefaultAsync(m => m.PersonalTrainerId == id);
            if (personalTrainer == null)
            {
                return NotFound();
            }

            return View(personalTrainer);
        }

        // POST: PersonalTrainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalTrainer = await _context.PersonalTrainers.FindAsync(id);
            _context.PersonalTrainers.Remove(personalTrainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalTrainerExists(int id)
        {
            return _context.PersonalTrainers.Any(e => e.PersonalTrainerId == id);
        }

        [HttpGet]
        public async Task<IActionResult> CreateTimeBlock()
        {
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTimeBlock(int id, [Bind("TimeBlockId,Date,Time,Location")] TimeBlock timeBlock)
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var personalTrainer = _context.PersonalTrainers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            TimeBlock newTimeBlock = new TimeBlock();
            newTimeBlock = timeBlock;
            newTimeBlock.TimeBlockIdentifier = personalTrainer.TimeBlockId;
            _context.TimeBlocks.Add(newTimeBlock);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ViewTimeBlocks()
        {

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var personalTrainer = _context.PersonalTrainers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var personalTrainerTimeBlocks = _context.TimeBlocks.Where(c => c.TimeBlockIdentifier == personalTrainer.TimeBlockId).ToList();
            

            return View(personalTrainerTimeBlocks);
        }
        public string GenerateRandomAlphanumericString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[50];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }


    }
    
}
