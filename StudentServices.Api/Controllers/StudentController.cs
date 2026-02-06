using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentServices.Api.Models;
using StudentServices.Api.Models.Data;
using System.Data.Common;


namespace StudentServices.Api.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;

        public StudentController(AppDbContext db)
        {
            _db = db;
        }

        //(in-memory only) private static readonly List<student1> _students = new();
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _db.Students.AsNoTracking().ToListAsync();
            return View(students);
        }

        
        [HttpGet]
        public IActionResult Create() => View();
        
        [HttpPost]
        public async Task<IActionResult> Create(student1 student)
        {
            if (!ModelState.IsValid) return View(student);
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
       

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var student = await _db.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            //if (id < 0 || id >= student1.Count) return NotFound();
            if (student == null)
                return NotFound();
            return View(student);
        }
    }
}
