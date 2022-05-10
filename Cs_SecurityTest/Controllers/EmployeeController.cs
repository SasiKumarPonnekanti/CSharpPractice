using Microsoft.AspNetCore.Mvc;
using Cs_SecurityTest.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cs_SecurityTest.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            Employees emps = new Employees();   
            return View(emps);
        }
        public IActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            Employees emps = new Employees();
            emps.Add(emp);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Employees emps = new Employees();
           Employee employee = new Employee();
            employee = emps.Find(e=>e.EmpNo == id);
            return View(employee);

        }
        [HttpPost]
        public IActionResult Edit(int id,Employee employee)
        {
            Employees emps = new Employees();
            emps.Find(e => e.EmpNo == id).DeptName = employee.DeptName;
            emps.Find(e => e.EmpNo == id).Designation = employee.Designation;
            emps.Find(e => e.EmpNo == id).Salary = employee.Salary;
            emps.Find(e => e.EmpNo == id).EmpName = employee.EmpName;
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Employees emps = new Employees();
            Employee emp = emps.Find(e => e.EmpNo == id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult Delete(int id,Employee emp)
        {
            Employees emps = new Employees();
             emps.Remove(emp);
            return RedirectToAction("Index");

        }
    }
}
