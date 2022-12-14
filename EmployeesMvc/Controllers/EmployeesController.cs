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

        public static int ID { get; set; } = 1;
        public static Company CurrentCompany { get; set; }



        [HttpGet(""), HttpGet($"{nameof(Index)}")]
        public async Task<IActionResult> Index()
        {
            //service.LoadFromFile();
            CurrentCompany = await service.GetCompanyById(ID);
            var model = await service.GetAllEmployees(ID);
            return View(model);
        }


        [HttpGet(nameof(Create))]
        public async Task<IActionResult> Create()
        {
            //var model = await service.GetEmployeeByCompany(ID);
            return View();
        }

        [HttpPost(nameof(Create))]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View();
            employee.CompanyId= ID;
            await service.Add(employee);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet(nameof(AddCompany))]
        public async Task<IActionResult> AddCompany()
        {
            return View();
        }

        [HttpPost(nameof(AddCompany))]
        public async Task<IActionResult> AddCompany(Company company)
        {
            if (!ModelState.IsValid)
                return View();
            await service.AddCompany(company);
            ID = company.Id;
            return RedirectToAction(nameof(Create));
        }

        [HttpGet(nameof(Company))]
        public async Task<IActionResult> Company()
        {
            var model = await service.GetAllCompanies();
            return View(model);
        }

        [HttpGet(nameof(Company) + "/{id}")]
        public async Task<IActionResult> Company(int id)
        {
            if (!ModelState.IsValid)
                return View();
            ID = id;
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
