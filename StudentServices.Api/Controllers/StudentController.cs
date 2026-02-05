using Microsoft.AspNetCore.Mvc;
using StudentServices.Api.Models;


namespace StudentServices.Api.Controllers
{
    public class StudentController : Controller
    {
        private static readonly List<student1> _students = new();

        [HttpGet]
        public IActionResult  Index()
        {
            return View(_students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(student1 student)
        {
            _students.Add(student);
           // if (!ModelState.IsValid)
              //  return View(student);

            // For now, just show a success page (later we’ll save to DB)
            // return RedirectToAction("Details", student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id < 0 || id >= _students.Count) return NotFound();
            return View(_students[id]);
        }
    }
}
