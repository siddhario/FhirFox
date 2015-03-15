using FhirFox.Models;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FhirFox.Services
{
    public class FhirService
    {
        private FhirDbContext _dbContext;
        private ModelConvertor _modelConvertor;

        public FhirService(FhirDbContext dbContext, ModelConvertor modelConvertor)
        {
            _dbContext = dbContext;
            _modelConvertor = modelConvertor;
        }

        public async Task<Base> GetResourceById(string id, string type)
        {
            return await Task.Factory.StartNew<Base>(() =>
                {
                    Base fhirObject = null;
                    if (type.Equals("Patient"))
                    {
                        var omgwtf = _dbContext.Patients.Where(p => p.Id.Equals(id)).FirstOrDefault();
                        fhirObject = _modelConvertor.GetFhirObject(omgwtf);

                    }
                    return fhirObject;
                }
            );

        }

        public async Task DeleteResourceById(string id, string type)
        {
            object dbObject = _dbContext.Patients.Where(p => p.Id.Equals(id)).FirstOrDefault();
            _dbContext.Set(dbObject.GetType()).Remove(dbObject);
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
            try
            {
                object dbObject = _modelConvertor.GetDbObject(resource);
                _dbContext.Set(dbObject.GetType()).Add(dbObject);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
        }
    }
}