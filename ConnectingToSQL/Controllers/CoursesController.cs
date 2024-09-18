using ConnectingToSQL.Models;
using ConnectingToSQL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConnectingToSQL.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext context;

        public CoursesController(ApplicationDbContext context)
        {
            this.context = context;

        }

        public IActionResult Index()
        {
            var courses = context.Courses.ToList();
            return View(courses);
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(CourseToDb courseToDb)
        {
            Course course = new Course()
            {
                Name = courseToDb.Name,
                ModuleName = courseToDb.ModuleName,
                Description = courseToDb.Description,
            };

            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index" , "Courses");
       }

    }
}
