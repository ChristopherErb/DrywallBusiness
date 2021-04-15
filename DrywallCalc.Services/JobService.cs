using DrywallCalc.Data;
using DrywallCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrywallCalc.Services
{
    public class JobService
    {
        private readonly Guid _userId;



        public JobService(Guid userId)
        {
            _userId = userId;
        }



        public bool CreateJob(JobCreate model)
        {
            var entity =
                new Job()
                {


                    Owner = model.Owner,
                    Title = model.Title
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<JobListItem> GetJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Jobs
                    .Where(e => e.JobOwnerId == _userId)
                    .Select(
                        e =>
                            new JobListItem
                            {
                                CurrentJobId = e.CurrentJobId,
                                Title = e.Title,
                                Owner = e.Owner,
                            }
                        );
                return query.ToArray();
            }
        }

    }
}
