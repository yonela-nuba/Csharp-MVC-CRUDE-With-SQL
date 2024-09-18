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
            if(!ModelState.IsValid)
            {
                return View(courseToDb);
            }
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

        public IActionResult Edit(int id)
        {
            var course = context.Courses.Find(id);
            if(course == null)
            {
                return RedirectToAction("Index", "Courses");
            }

            CourseToDb courseToDb = new CourseToDb()
            {
                Name = course.Name,
                ModuleName = course.ModuleName,
                Description = course.Description,
            };

            ViewData["CourseId"] = course.Id;

            return View(courseToDb);

        }
        [HttpPost]
        public IActionResult Edit(int id,CourseToDb courseToDb) 
        {
            var course = context.Courses.Find(id);
            if( course == null)
            {
                return RedirectToAction("Index", "Courses");
            }

            if(!ModelState.IsValid)
            {
                ViewData["CourseId"] = course.Id;
                return View(courseToDb);
            }

            course.Name = courseToDb.Name;
            course.ModuleName = courseToDb.ModuleName;
            course.Description = courseToDb.Description;

            context.SaveChanges();
            return RedirectToAction("Index", "Courses");
        }

        public IActionResult Delete(int id)
        {
            var course = context.Courses.Find(id);
            if(course == null)
            {
                return RedirectToAction("Index", "Courses");
            }

            context.Courses.Remove(course);
            context.SaveChanges(true);
            return RedirectToAction("Index", "Courses");

        }



    }
}
