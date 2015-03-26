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
        private DbContext _dbContext;
        private IObjectMapper _mapper;

        public FhirService(FhirFoxDbContext dbContext, IObjectMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public virtual async Task<Base> GetResourceById(string id, string type)
        {
            var omgwtf = await _dbContext.Set(Type.GetType("FhirFox.Models." + type.ToUpper())).FindAsync(id);
            Base fhirObject = _mapper.GetFhirObject(omgwtf);
            return fhirObject;
        }

        public virtual async Task DeleteResourceById(string id, string type)
        {
            DbSet dbset = _dbContext.Set(Type.GetType("FhirFox.Models." + type.ToUpper()));
            var omgwtf = await dbset.FindAsync(id);
            dbset.Remove(omgwtf);
            await _dbContext.SaveChangesAsync();
        }


        public virtual async Task<Base> GetAll(string type)
        {
            Bundle b = new Bundle();
       
            List<object> list = await _dbContext.Set(Type.GetType("FhirFox.Models." + type.ToUpper())).ToListAsync();
            foreach (var p in list)
            {
                Bundle.BundleEntryComponent be = new Bundle.BundleEntryComponent();
                be.Resource = (Resource)_mapper.GetFhirObject(p);
                b.Entry.Add(be);
            }
            return b;
        }

        public virtual async Task Add(Base resource)
        {
            ((DomainResource)resource).Id = Guid.NewGuid().ToString();//???? WHERE TO PUT THIS?

            object dbObject = _mapper.GetDbObject(resource);

            _dbContext.Set(dbObject.GetType()).Add(dbObject);
            await _dbContext.SaveChangesAsync();
        }


        public virtual async Task Modify(Base resource, string type, string id)
        {
            var dbobject = _mapper.GetDbObject(resource);
            _dbContext.Entry(dbobject).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}