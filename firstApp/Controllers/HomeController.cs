using firstApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace firstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<string> datas = new List<string>
        {
            "Ayxan","Zaur"
        };

        static List<Student> Students = new List<Student> {
            new Student{ Name="Ayxan",Surname="Axundov"},
            new Student{ Name="Zaur",Surname="Ceferov"},
            new Student{ Name="Senan",Surname="Memmedov"},
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Group group = new Group { Id = 5, Number = "5214" };

            IndexViewModel model = new IndexViewModel {
                Group = group,
                students = Students
            };

            return View(model);
        }



        public IActionResult GetById(int id) {
            var student = Students.FirstOrDefault(i => i.Id == id);
            return View(student);
        }
        [HttpPost]
        public IActionResult AddStudent(Student student) {
            Students.Add(student);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult RemoveStudentById(int id) {
            var stdentId = Students.FirstOrDefault(i => i.Id == id);
            Students.Remove(stdentId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateStdent(int id) {
            var stdentId = Students.FirstOrDefault(i => i.Id == id);
            return View(stdentId);
        }
        [HttpPost]

        public IActionResult UpdateStdentAct(Student student) {
            var std = Students.Where(x=>x.Id==student.Id).FirstOrDefault();
            std.Name=student.Name;
            std.Surname=student.Surname;


            return RedirectToAction("Index");

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
