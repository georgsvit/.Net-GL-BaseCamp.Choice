using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Net_GL_BaseCamp.ChoiceA.Attributes;
using Net_GL_BaseCamp.ChoiceA.Data;
using Net_GL_BaseCamp.ChoiceA.Models;

namespace Net_GL_BaseCamp.ChoiceA.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public StudentsController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Students
        [ForAdmin]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: Students/Details/5
        [ForAdmin]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        [ForAdmin]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ForAdmin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Group")] Student student)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = student.Name, Email = $"{student.Name}@gmail.com", Group = student.Group };

                IdentityResult result = await _userManager.CreateAsync(user, "123456");

                if (result.Succeeded)
                {
                    student.AspNetUser = user;
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    await _userManager.AddClaimAsync(user, new Claim("studentId", student.Id.ToString()));
                    return RedirectToAction(nameof(Index));
                } else
                {
                    ModelState.AddModelError("Name", result.Errors.First().Description);
                }                
            }
            return View(student);
        }

        // GET: Students/Edit/5
        [ForAdmin]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ForAdmin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Group")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }

        // GET: Students/Delete/5
        [ForAdmin]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [ForAdmin]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

        [ForStudent]
        public IActionResult ChangeDisciplines(int id)
        {
            List<int> selectedIds = _context.Students.Include("StudentDisciplines").SingleOrDefault(s => s.Id == id).StudentDisciplines
                                                         .Select(sd => sd.DisciplineId)
                                                         .ToList();
            List<Discipline> selected = _context.Disciplines.Where(d => selectedIds.Contains(d.Id)).ToList();
            List<Discipline> unselected = _context.Disciplines.ToList().Except(selected).OrderBy(d => d.Title).ToList();

            return View(new ChangeDisciplinesModel(selected, unselected, id));
        }

        [HttpPost]
        [ForStudent]
        public IActionResult ChangeDisciplines(int studentId, int[] selected)
        {
            Student student = _context.Students.Include("StudentDisciplines").SingleOrDefault(s => s.Id == studentId);
            student.StudentDisciplines.Clear();
            student.StudentDisciplines = _context.Disciplines.Where(d => selected.Contains(d.Id)).Select(x => new StudentDiscipline(student, x)).ToList();
            _context.SaveChanges();
            return RedirectToAction("ChangeDisciplines");
        }

        public JsonResult ValidateName(string name)
        {
            if (_context.Students.Any(s => s.Name == name))
                return Json("This name is not unique.");
            return Json(true);
        }
    }
}
