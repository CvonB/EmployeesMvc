using EmployeesMvc.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeesMvc.Models.Entities;

namespace EmployeesMvc.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeeService service;
        public EmployeesController(EmployeeService service)
        {
            this.service = service;
        }


        [HttpGet(""),HttpGet(nameof(Index))]
        public async Task<IActionResult> Index()
        {
            //service.LoadFromFile();
            var model = await service.GetAll();
            return View(model);
        }


        [HttpGet(nameof(Create))]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View();
            await service.Add(employee);
            return RedirectToAction(nameof(Index));
        }

       

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await service.GetById(id);
            return View(model);
        }

        [HttpPost("details/{id}")]
        public IActionResult Details(Employee employee)
        {
            service.Kill(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
