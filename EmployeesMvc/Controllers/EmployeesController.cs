using EmployeesMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesMvc.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeeService service;

        public EmployeesController()
        {
            service= new EmployeeService();
        }

        [HttpGet(""),HttpGet(nameof(Index))]
        public IActionResult Index()
        {
            service.LoadXML();
            return View(service.GetAll());
        }

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

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            return View(service.GetById(id));
        }
    }
}
