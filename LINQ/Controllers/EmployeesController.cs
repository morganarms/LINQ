using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LINQ.Models;

namespace LINQ.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly LINQDBContext _context;

        public EmployeesController(LINQDBContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,Email,Gender,DepartmentId,Salary,Age")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,FirstName,LastName,Email,Gender,DepartmentId,Salary,Age")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }

        //FROM each object in the collection WHERE the condition is met SELECT that object
        public IActionResult BasicQuerySyntax() {
            // retrieve employees with salary between 15000-50000
            var emp_data = from e in _context.Employee
                           where e.Salary >= 15000 && e.Salary <= 50000
                           select e;

            return View(emp_data);
        }

        public IActionResult MethodExpression()
        {
            // retrieve employees with salary between 15000-50000
            var emp_data = _context.Employee
                .Where(e => e.Salary >= 15000 && e.Salary <= 50000)
                .ToList();

            return View(emp_data);
        }

        public IActionResult WhyLINQ()
        {
            var emp_data = _context.Employee.ToList();
            int count = 0;
            var queryempdata = new List<Employee>();

            foreach (var item in emp_data)
            {
                if(item.Salary >= 15000 && item.Salary <= 50000)
                {
                    queryempdata.Add(item);
                    count += 1;
                    ViewBag.emp_count = count;
                }
            }

            return View(queryempdata);
        }

        public IActionResult WhereOperator()
        {
            // retrieve employees with salary between 15000-50000
            var emp_data = from e in _context.Employee
                           where e.Salary > 15000 && e.Age <= 30
                           select e;

            return View(emp_data);
        }

        public IActionResult OrderBy()
        {
            var emp_data = _context.Employee
                    .Where(s => s.Salary > 15000)
                    .OrderBy(e => e.Age)
                    .ToList();

            return View(emp_data);
        }

        public IActionResult GroupBy()
        {
            var emp_data = _context.Employee.ToList();

            return View(emp_data);
        }
    }
}
