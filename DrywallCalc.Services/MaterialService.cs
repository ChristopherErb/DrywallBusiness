using DrywallCalc.Data;
using DrywallCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrywallCalc.Services
{
    public class MaterialService
    {
        private readonly Guid _userId;

        public MaterialService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateMaterial(MaterialCreate  model)
        {
            var entity =
                new Material()
                {

                    MatOwnerID = _userId,
                    JobTitle = model.JobTitle,
                    ManagerId = model.ManagerId
    };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Materials.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }


        public IEnumerable<MaterialListItem> GetMaterials()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Materials
                    .Where(e => e.MatOwnerID == _userId)
                    .Select(
                        e =>
                            new MaterialListItem
                            {
                               ManagerId = e.ManagerId,
                               JobTitle = e.JobTitle
                            }
                        );
                return query.ToArray();
            }
        }


    }
}
