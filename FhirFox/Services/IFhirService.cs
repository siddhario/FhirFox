using System;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
namespace FhirFox.Services
{
    public interface IFhirService
    {
        Task Add(Base resource);
        Task DeleteResourceById(string id, string type);
        Task<Base> GetAll(string type);
        Task<Base> GetResourceById(string id, string type);
        Task Modify(Base resource, string type, string id);
    }
}
