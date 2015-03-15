using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hl7.Fhir.Model;
using System.Threading.Tasks;
using FhirFox.Models;
using FhirFox.Services;

namespace FhirFox.Controllers
{
    [RoutePrefix("fhir")]
    public class FhirController : ApiController
    {
        FhirService _fhirService = new FhirService(new FhirDbContext(),new ModelConvertor());


        [Route("{type}")]
        public async Task<Base> Get(string type)
        {
            return await _fhirService.GetAll(type);
        }

        [Route("{type}/{id}")]
        public async Task<Base> Get(string id, string type)
        {
            return await _fhirService.GetResourceById(id, type);
        }


        [Route("{type}")]
        public async Task Post(Base value, string type)
        {
            await _fhirService.Add(value);
        }


        [Route("{type}/{id}")]
        public async Task Put(Base value, string type,string id)
        {
            await _fhirService.Modify(value,type,id);
        }


        

        [Route("{type}/{id}")]
        public async Task Delete(string id,string type)
        {
            await _fhirService.DeleteResourceById(id, type);
        }
    }
}
