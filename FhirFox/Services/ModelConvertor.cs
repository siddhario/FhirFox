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

                 
                        dbPatient.Active = fhirPatient.Active;
                        if (fhirPatient.Deceased!=null)
                            dbPatient.Deceased = ((FhirBoolean)fhirPatient.Deceased).Value;

                        switch (fhirPatient.Gender)
                        {
                            case AdministrativeGender.Male:
                                {
                                    dbPatient.Gender = "M";
                                    break;
                                }
                            case AdministrativeGender.Female:
                                {
                                    dbPatient.Gender = "Ž";
                                    break;
                                }
                            default:
                                {
                                    dbPatient.Gender = null;
                                    break;
                                }
                        }

                        if (fhirPatient.Name.Count > 0)
                        {
                            if (fhirPatient.Name[0].Given.Count() > 0)
                                dbPatient.FirstName = fhirPatient.Name[0].Given.ElementAt(0);
                            if (fhirPatient.Name[0].Family.Count() > 0)
                                dbPatient.LastName = fhirPatient.Name[0].Family.ElementAt(0);
                        }
                        if (fhirPatient.Address.Count > 0)
                        {
                            if (fhirPatient.Address[0].Line.Count() > 0)
                                dbPatient.Address = fhirPatient.Address[0].Line.ElementAt(0);
                            dbPatient.City = fhirPatient.Address[0].City;
                        }
                        if (fhirPatient.Identifier.Count > 0)
                            dbPatient.Pin = fhirPatient.Identifier[0].Value;

                        ContactPoint emailAddress = fhirPatient.Telecom.Where(t => t.System == ContactPoint.ContactPointSystem.Email).ToList().FirstOrDefault();
                        ContactPoint phoneNumber = fhirPatient.Telecom.Where(t => t.System == ContactPoint.ContactPointSystem.Phone).ToList().FirstOrDefault();
                        if (emailAddress != null)
                            dbPatient.EmailAddress = emailAddress.Value;
                        if (phoneNumber != null)
                            dbPatient.PhoneNumber = phoneNumber.Value;

                        if (fhirPatient.BirthDate != null)
                            dbPatient.BirthDate = DateTime.Parse(fhirPatient.BirthDate);

                        if (fhirPatient.MaritalStatus != null && fhirPatient.MaritalStatus.Coding.Count > 0)
                            dbPatient.MaritalStatus = fhirPatient.MaritalStatus.Coding.ElementAt(0).Code;


                        if (fhirPatient.Contact.Count > 0)
                        {
                            Patient.ContactComponent cc = fhirPatient.Contact.ElementAt(0);
                            if (cc.Name != null)
                            {
                                if (cc.Name.Family.Count() > 0)
                                    dbPatient.ContactPersonLastName = cc.Name.Family.ElementAt(0);
                                if (cc.Name.Given.Count() > 0)
                                    dbPatient.ContactPersonFirstName = cc.Name.Given.ElementAt(0);
                            }
                            if (cc.Address != null && cc.Address.Line.Count() > 0)
                                dbPatient.ContactPersonAddress = cc.Address.Line.ElementAt(0);

                            if (cc.Telecom.Count > 0)
                                dbPatient.PhoneNumber = cc.Telecom.ElementAt(0).Value;
                        }

                        foreach (Extension ex in fhirPatient.Extension)
                        {
                            switch (ex.Url)
                            {
                                case "http://hl7.org/fhir/ExtensionDefinition/us-core-race":
                                    {
                                        dbPatient.Race = ((CodeableConcept)ex.Value).Coding[0].Code;
                                        break;
                                    }

                                case "http://hl7.org/fhir/ExtensionDefinition/us-core-religion":
                                    {
                                        dbPatient.Religion = ((CodeableConcept)ex.Value).Coding[0].Code;
                                        break;
                                    }

                                case "http://hl7.org/fhir/ExtensionDefinition/us-core-ethnicity":
                                    {
                                        dbPatient.Ethnicity = ((CodeableConcept)ex.Value).Coding[0].Code;
                                        break;
                                    }
                                case "http://hl7.org/fhir/ExtensionDefinition/patient-mothers-maiden-name":
                                    {
                                        dbPatient.MothersMaidenName = ((CodeableConcept)ex.Value).Coding[0].Code;
                                        break;
                                    }
                                case "http://hl7.org/fhir/ExtensionDefinition/us-core-birth-place":
                                    {
                                        dbPatient.PlaceOfBirth = ((Address)ex.Value).Line.ToList().ElementAt(0);
                                        break;
                                    }
                            }
                        }

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
                        fhirPatient.Address.Add(new Address() { City = dbPatient.City, Line = new List<string>() { dbPatient.Address } });
                        fhirPatient.Active = dbPatient.Active;
                        fhirPatient.Deceased = new FhirBoolean(dbPatient.Deceased);

                        //CARE PROVIDER REFERENCE
                        ResourceReference rr = new ResourceReference();
                        rr.Reference = "/Practitioner/org1";
                        fhirPatient.CareProvider = new List<ResourceReference>() { rr };                 
                 

                        //GENDER
                        switch (dbPatient.Gender)
                        {
                            case "M":
                                {
                                    fhirPatient.Gender = AdministrativeGender.Male;
                                    break;
                                }
                            case "Ž":
                                {
                                    fhirPatient.Gender = AdministrativeGender.Female;
                                    break;
                                }
                            default:
                                {
                                    fhirPatient.Gender = AdministrativeGender.Unknown;
                                    break;
                                }
                        }

                        fhirPatient.Identifier = new List<Identifier>() { new Identifier("http://pin.fhir.com", dbPatient.Pin) };

                        //EMAIL,PHONE
                        if (dbPatient.EmailAddress != null || dbPatient.PhoneNumber != null)
                        {
                            List<ContactPoint> contactPoints = new List<ContactPoint>();
                            if (dbPatient.PhoneNumber != null)
                                contactPoints.Add(new ContactPoint() { System = ContactPoint.ContactPointSystem.Phone, Value = dbPatient.PhoneNumber });
                            if (dbPatient.EmailAddress != null)
                                contactPoints.Add(new ContactPoint() { System = ContactPoint.ContactPointSystem.Email, Value = dbPatient.EmailAddress });
                            fhirPatient.Telecom = contactPoints;
                        }



                        if (dbPatient.BirthDate.HasValue)
                            fhirPatient.BirthDate = dbPatient.BirthDate.Value.ToShortDateString();

                        if (dbPatient.MaritalStatus != null)
                            fhirPatient.MaritalStatus = new CodeableConcept("http://maritalstatus.fhir.com", dbPatient.MaritalStatus);


                        if (dbPatient.ContactPersonFirstName != null || dbPatient.ContactPersonLastName != null)
                        {
                            fhirPatient.Contact = new List<Patient.ContactComponent>() 
                            { 
                                new Patient.ContactComponent() 
                                { 
                                    Name = HumanName.ForFamily(dbPatient.ContactPersonLastName).WithGiven(dbPatient.ContactPersonFirstName), 
                                    Address = new Address() { Line = new List<string>() { dbPatient.ContactPersonAddress }},
                                    Telecom = new List<ContactPoint>() { new ContactPoint(){ System = ContactPoint.ContactPointSystem.Phone, Value = dbPatient.ContactPersonPhone } }
                                } 
                            };
                        }

                        if (dbPatient.Race != null)
                            fhirPatient.Extension.Add(new Extension() { Url = "http://hl7.org/fhir/ExtensionDefinition/us-core-race", Value = new CodeableConcept("http://hl7.org/fhir/ExtensionDefinition/us-core-race", dbPatient.Race) });
                        if (dbPatient.Religion != null)
                            fhirPatient.Extension.Add(new Extension() { Url = "http://hl7.org/fhir/ExtensionDefinition/us-core-religion", Value = new CodeableConcept("http://hl7.org/fhir/ExtensionDefinition/us-core-religion", dbPatient.Religion) });
                        if (dbPatient.MothersMaidenName != null)
                            fhirPatient.Extension.Add(new Extension() { Url = "http://hl7.org/fhir/ExtensionDefinition/patient-mothers-maiden-name", Value = new FhirString(dbPatient.MothersMaidenName) });
                        if (dbPatient.Ethnicity != null)
                            fhirPatient.Extension.Add(new Extension() { Url = "http://hl7.org/fhir/ExtensionDefinition/us-core-ethnicity", Value = new CodeableConcept("http://hl7.org/fhir/ExtensionDefinition/us-core-ethnicity", dbPatient.Ethnicity) });

                        if (dbPatient.PlaceOfBirth != null)
                            fhirPatient.Extension.Add(new Extension() { Url = "http://hl7.org/fhir/ExtensionDefinition/us-core-birth-place", Value = new Address() { Line = new List<string>() { dbPatient.PlaceOfBirth } } });



                        return fhirPatient;
                    }
                default:
                    return null;
            }
        }

    }
}