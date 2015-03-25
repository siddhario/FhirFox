using System;
using Hl7.Fhir.Model;

namespace FhirFox.Services
{
    public interface IObjectMapper
    {
        object GetDbObject(Base FhirModel);
        Base GetFhirObject(object dbObject);
    }
}
