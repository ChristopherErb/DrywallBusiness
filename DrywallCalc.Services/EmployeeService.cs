using DrywallCalc.Data;
using DrywallCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrywallCalc.Services
{
    public class EmployeeService
    {

        private readonly Guid _userId;

        public EmployeeService (Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity =
                new Employee()
                {
                    Employee_Id = _userId,
                    FullName = model.FullName,
                    Title = model.Title,
                    PayRate = model.PayRate,
                    HireDate = DateTimeOffset.Now

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        //See all employees created by X user
         public IEnumerable<EmployeeListItem> GetEmployees()
         {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Employees
                    .Where(e => e.Employee_Id == _userId)
                    .Select(
                        e => new EmployeeListItem
                        {
                            FullName = e.FullName,
                            Title = e.Title,
                            PayRate = e.PayRate,
                            HireDate = e.HireDate
                        }

                        );

                return query.ToArray();
            }    

         }







    }
}
