using System;
namespace FhirFox.Services
{
   public interface IFhirService
    {
        System.Threading.Tasks.Task Add(Hl7.Fhir.Model.Base resource);
        System.Threading.Tasks.Task DeleteResourceById(string id, string type);
        System.Threading.Tasks.Task<Hl7.Fhir.Model.Base> GetAll(string type);
        System.Threading.Tasks.Task<Hl7.Fhir.Model.Base> GetResourceById(string id, string type);
        System.Threading.Tasks.Task Modify(Hl7.Fhir.Model.Base resource, string type, string id);
    }
}
