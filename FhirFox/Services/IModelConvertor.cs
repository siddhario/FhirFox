using System;
using Hl7.Fhir.Model;

namespace FhirFox.Services
{
    public interface IModelConvertor
    {
        object GetDbObject(Base FhirModel);
        Base GetFhirObject(object dbObject);
    }
}
