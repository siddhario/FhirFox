using System;
namespace FhirFox.Services
{
    public interface IModelConvertor
    {
        object GetDbObject(Hl7.Fhir.Model.Base FhirModel);
        Hl7.Fhir.Model.Base GetFhirObject(object dbObject);
    }
}
