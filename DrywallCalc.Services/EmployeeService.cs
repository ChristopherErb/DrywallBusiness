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

        private readonly String _userId;

        public EmployeeService (String userId)
        {
            _userId = userId;
        }

        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity =
                new Employee()
                {
                    Employee_Id = Guid.NewGuid().ToString(),
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

        //See all employees
         public IEnumerable<EmployeeListItem> GetEmployees()
         {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Employees
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

      
        public EmployeeDetail GetEmployeeById(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                   ctx
                    .Employees
                    .Single(e => e.Employee_Id == _userId);

                    return
                        new EmployeeDetail
                        {
                            Title = entity.Title,
                            FullName = entity.FullName,
                            PayRate = entity.PayRate,
                            HireDate = entity.HireDate

                        };
            }

        }
             public bool UpdateEmployee(EmployeeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Employees
                    .Single(e => e.Employee_Id == model.Employee_Id);

                entity.Title = model.Title;
                entity.FullName = model.FullName;
                entity.PayRate = (decimal)model.PayRate;

                return ctx.SaveChanges() == 1;
            
            };



         }

        public bool DeleteEmployee(int Employee_Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employees
                        .Single(e => e.Employee_Id == _userId);

                ctx.Employees.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
