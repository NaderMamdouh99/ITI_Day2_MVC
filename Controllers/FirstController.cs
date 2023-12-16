using Day_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day_2.Controllers
{
    public class FirstController : Controller
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee(){Id= 1, Name="Nader"},
            new Employee(){Id= 2, Name ="Ali" },
            new Employee(){Id= 3, Name = "Hossam"}
        };

        #region Assignment
            //Crud Operation
        #endregion

        // Get All Emplyee
        [HttpGet]
        public ActionResult Employees()
        {

            return View(employees);
        }
        // Get View Emplyee
        [HttpGet]
        public ActionResult ADD()
        {
            return View();
        }

        // Add Employee in list Employe and View Employees
        [HttpPost]
        public ActionResult AddEmployee(int id, string name)
        {
            bool found = false;
            foreach (var item in employees)
            {
                if (item.Id == id)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                employees.Add(new Employee() {Id = id ,Name = name });
                return RedirectToAction("Employees");
            }
            else
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "ID Aleardy Exist");
            }

        }
        // Delete Emolyee
        public ActionResult Delete(int id)
        {
            Employee employee = employees.Where(C=>C.Id == id).Select(C=>C).FirstOrDefault();
            employees.Remove(employee);
            return RedirectToAction("Employees");
            
        }
        // Update to Edit Data
        public ActionResult Update(int id)
        {
            Employee employee = employees.Find(C => C.Id == id);
            return View(employee);
        }
        // Edite Data and View Employees
        public ActionResult Edit(int id ,string name)
        {
            Employee employee = employees.Find(C => C.Id == id);
            employee.Id = id;
            employee.Name = name;
            return RedirectToAction("Employees");
        }
    }
}