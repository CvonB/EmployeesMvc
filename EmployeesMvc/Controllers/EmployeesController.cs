using EmployeesMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesMvc.Controllers
{
    public class EmployeesController : Controller
    {
        IEmployeeService service;
        public EmployeesController(IEmployeeService service)
        {
            this.service = service;
        }


        [HttpGet(""),HttpGet(nameof(Index))]
        public IActionResult Index()
        {
            //service.LoadFromFile();
            return View(service);
        }

        //[HttpGet("index/{count}")]
        //public IActionResult Index(int count)
        //{
        //    //service.LoadFromFile();
        //    return View(service.GetAll());
        //}

        [HttpGet(nameof(Create))]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost(nameof(Create))]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View();
            service.Add(employee);
            return RedirectToAction(nameof(Index));
        }

        
        [HttpPost(nameof(Invade))]
        public IActionResult Invade()
        {
            service.Invade();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost(nameof(Genocide))]
        public IActionResult Genocide()
        {
            service.Genocide();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            return View(service.GetById(id));
        }

        [HttpPost("details/{id}")]
        public IActionResult Details(Employee employee)
        {
            service.Kill(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
