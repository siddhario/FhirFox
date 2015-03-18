using FhirFox.Models;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FhirFox.Services;

namespace FhirFox.Services
{
    public class FhirService : IFhirService
    {
        private FhirDbContext _dbContext;
        private IModelConvertor _modelConvertor;

        public FhirService(FhirDbContext dbContext, IModelConvertor modelConvertor)
        {
            _dbContext = dbContext;
            _modelConvertor = modelConvertor;
        }

        public virtual async Task<Base> GetResourceById(string id, string type)
        {
            var omgwtf = await _dbContext.Set(Type.GetType("FhirFox.Models.DB" + type)).FindAsync(id);
            Base fhirObject = _modelConvertor.GetFhirObject(omgwtf);
            return fhirObject;
        }

        public async Task DeleteResourceById(string id, string type)
        {
            DbSet dbset = _dbContext.Set(Type.GetType("FhirFox.Models.DB" + type));
            var omgwtf = await dbset.FindAsync(id);
            dbset.Remove(omgwtf);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<Base> GetAll(string type)
        {
            Bundle b = new Bundle();
            List<object> list = await _dbContext.Set(Type.GetType("FhirFox.Models.DB" + type)).ToListAsync();
            foreach (var p in list)
            {
                Bundle.BundleEntryComponent be = new Bundle.BundleEntryComponent();
                be.Resource = (Resource)_modelConvertor.GetFhirObject(p);
                b.Entry.Add(be);
            }
            return b;
        }

        public async Task Add(Base resource)
        {
            object dbObject = _modelConvertor.GetDbObject(resource);
            _dbContext.Set(dbObject.GetType()).Add(dbObject);
            await _dbContext.SaveChangesAsync();
        }


        public async Task Modify(Base resource, string type, string id)
        {
            var dbobject = _modelConvertor.GetDbObject(resource);
            _dbContext.Entry(dbobject).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}