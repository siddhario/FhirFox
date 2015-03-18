using FhirFox.Models;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FhirFox.Services
{
    public class ModelConvertor : FhirFox.Services.IModelConvertor
    {
        public object GetDbObject(Base FhirModel)
        {
            switch (FhirModel.TypeName)
            {
                case "Patient":
                    {
                        DBPatient dbPatient = new DBPatient();
                        Patient fhirPatient = FhirModel as Patient;
                        dbPatient.Id = fhirPatient.Id;
                        dbPatient.FirstName = fhirPatient.Name[0].Given.ElementAt(0);
                        dbPatient.LastName = fhirPatient.Name[0].Family.ElementAt(0);
                        dbPatient.Address = fhirPatient.Address[0].Line.ElementAt(0);
                        dbPatient.City = fhirPatient.Address[0].City;
                        return dbPatient;
                    }
                default:
                    return null;
            }
        }

        public Base GetFhirObject(object dbObject)
        {
            if (dbObject == null)
                return null;

            switch (dbObject.GetType().Name)
            {
                case "DBPatient"://VIEW MODEL TO DB MODEL CUSTOM LOGIC
                    {
                        Patient fhirPatient = new Patient();
                        DBPatient dbPatient = dbObject as DBPatient;
                        fhirPatient.Id = dbPatient.Id;
                        fhirPatient.Name.Add(HumanName.ForFamily(dbPatient.LastName).WithGiven(dbPatient.FirstName));
                        fhirPatient.Address.Add(new Address(){City = dbPatient.City,Line = new List<string>() { dbPatient.Address } });

                        return fhirPatient;
                    }
                default:
                    return null;
            }
        }

    }
}