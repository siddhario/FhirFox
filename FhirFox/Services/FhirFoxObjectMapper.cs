using FhirFox.Models;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FhirFox.Services
{
    public class FhirFoxObjectMapper : IObjectMapper
    {
        public object GetDbObject(Hl7.Fhir.Model.Base FhirModel)
        {            
            throw new NotImplementedException();
        }

        public Hl7.Fhir.Model.Base GetFhirObject(object dbObject)
        {

            if (dbObject == null)
                return null;


            var type = System.Data.Entity.Core.Objects.ObjectContext.GetObjectType(dbObject.GetType());

            switch (type.Name)
            {
                case "PATIENT"://VIEW MODEL TO DB MODEL CUSTOM LOGIC
                    {
                        Patient fhirPatient = new Patient();
                        PATIENT dbPatient = dbObject as PATIENT;

                        #region Simple elements

                        fhirPatient.Id = dbPatient.PatientId;

                        fhirPatient.Active = dbPatient.Active;
                        if (dbPatient.DeceasedDateTime.HasValue)
                            fhirPatient.Deceased = new FhirDateTime(dbPatient.DeceasedDateTime.Value);
                        if (dbPatient.Deceased.HasValue)
                            fhirPatient.Deceased = new FhirBoolean(dbPatient.Deceased);


                        if (dbPatient.BirthDate.HasValue)
                            fhirPatient.BirthDate = dbPatient.BirthDate.Value.ToShortDateString();

                        if (dbPatient.MaritalStatus != null)
                            fhirPatient.MaritalStatus = new CodeableConcept("http://maritalstatus.fhir.com", dbPatient.MaritalStatus);



                        //GENDER
                        if (dbPatient.Gender != null)
                        {
                            switch (dbPatient.Gender)
                            {
                                case "male":
                                    {
                                        fhirPatient.Gender = AdministrativeGender.Male;
                                        break;
                                    }
                                case "female":
                                    {
                                        fhirPatient.Gender = AdministrativeGender.Female;
                                        break;
                                    }


                                case "other":
                                    {
                                        fhirPatient.Gender = AdministrativeGender.Other;
                                        break;
                                    }

                                case "unknown":
                                    {
                                        fhirPatient.Gender = AdministrativeGender.Unknown;
                                        break;
                                    }
                            }
                        }



                        #endregion

                        #region Name

                        foreach (PATIENT_NAME patientName in dbPatient.PATIENT_NAME)
                        {
                            HumanName hn = new HumanName();
                            if (patientName.Family != null)
                            {
                                string[] _family = Regex.Split(patientName.Family, Options.STRING_DELIMITER);
                                hn.Family = _family.AsEnumerable();
                            }
                            if (patientName.Given != null)
                            {
                                string[] _given = Regex.Split(patientName.Given, Options.STRING_DELIMITER);
                                hn.Given = _given.AsEnumerable();
                            }
                            if (patientName.Prefix != null)
                            {
                                string[] _prefix = Regex.Split(patientName.Prefix, Options.STRING_DELIMITER);
                                hn.Prefix = _prefix.AsEnumerable();
                            }
                            if (patientName.Suffix != null)
                            {
                                string[] _suffix = Regex.Split(patientName.Suffix, Options.STRING_DELIMITER);
                                hn.Suffix = _suffix.AsEnumerable();
                            }
                            if (patientName.PeriodStart.HasValue)
                            {
                                Period p = new Period();
                                p.Start = patientName.PeriodStart.Value.ToString("yyyy-MM-dd");
                                p.End = patientName.PeriodEnd.Value.ToString("yyyy-MM-dd");
                                hn.Period = p;
                            }
                            hn.Text = patientName.Text;
                            switch (patientName.Use)
                            {
                                case "official":
                                    {
                                        hn.Use = HumanName.NameUse.Official;
                                        break;
                                    }

                                case "anonymous":
                                    {

                                        hn.Use = HumanName.NameUse.Anonymous;
                                        break;
                                    }

                                case "maiden":
                                    {
                                        hn.Use = HumanName.NameUse.Maiden;
                                        break;
                                    }

                                case "nickname":
                                    {
                                        hn.Use = HumanName.NameUse.Nickname;
                                        break;
                                    }

                                case "old":
                                    {
                                        hn.Use = HumanName.NameUse.Old;
                                        break;
                                    }

                                case "temp":
                                    {
                                        hn.Use = HumanName.NameUse.Temp;
                                        break;
                                    }

                                case "usual":
                                    {
                                        hn.Use = HumanName.NameUse.Usual;
                                        break;
                                    }
                            }
                            hn.ElementId = patientName.PatientNameId.ToString();
                            fhirPatient.Name.Add(hn);
                        }

                        #endregion

                        #region Address

                        foreach (PATIENT_ADDRESS patientAddress in dbPatient.PATIENT_ADDRESS)
                        {
                            Address a = new Address();

                            Period p = new Period();
                            if (patientAddress.PeriodStart.HasValue)
                                p.Start = patientAddress.PeriodStart.Value.ToString("yyyy-MM-dd");
                            if (patientAddress.PeriodEnd.HasValue)
                                p.End = patientAddress.PeriodEnd.Value.ToString("yyyy-MM-dd");
                            a.Period = p;
                            a.PostalCode = patientAddress.PostalCode;

                            a.City = patientAddress.City;
                            a.Country = patientAddress.Country;
                            a.State = patientAddress.State;
                            if (patientAddress.Line != null)
                            {
                                string[] _lines = Regex.Split(patientAddress.Line, Options.STRING_DELIMITER);
                                a.Line = _lines.AsEnumerable();
                            }

                            switch (patientAddress.Use)
                            {
                                case "home":
                                    {
                                        a.Use = Address.AddressUse.Home;
                                        break;
                                    }
                                case "old":
                                    {
                                        a.Use = Address.AddressUse.Old;
                                        break;
                                    }
                                case "temp":
                                    {
                                        a.Use = Address.AddressUse.Temp;
                                        break;
                                    }
                                case "work":
                                    {
                                        a.Use = Address.AddressUse.Work;
                                        break;
                                    }
                            }
                            fhirPatient.Address.Add(a);
                        }

                        #endregion

                        #region Telecom

                        foreach (PATIENT_TELECOM patientTelecom in dbPatient.PATIENT_TELECOM)
                        {
                            ContactPoint cp = new ContactPoint();
                            Period p = new Period();
                            if (patientTelecom.PeriodStart.HasValue)
                                p.Start = patientTelecom.PeriodStart.Value.ToString("yyyy-MM-dd");
                            if (patientTelecom.PeriodEnd.HasValue)
                                p.End = patientTelecom.PeriodEnd.Value.ToString("yyyy-MM-dd");
                            cp.Period = p;

                            switch (patientTelecom.System)
                            {
                                case "email":
                                    {
                                        cp.System = ContactPoint.ContactPointSystem.Email;
                                        break;
                                    }
                                case "phone":
                                    {
                                        cp.System = ContactPoint.ContactPointSystem.Phone;
                                        break;
                                    }
                                case "fax":
                                    {
                                        cp.System = ContactPoint.ContactPointSystem.Fax;
                                        break;
                                    }
                                case "url":
                                    {
                                        cp.System = ContactPoint.ContactPointSystem.Url;
                                        break;
                                    }
                            }

                            switch (patientTelecom.Use)
                            {
                                case "email":
                                    {
                                        cp.Use = ContactPoint.ContactPointUse.Home;
                                        break;
                                    }
                                case "work":
                                    {
                                        cp.Use = ContactPoint.ContactPointUse.Work;
                                        break;
                                    }
                                case "mobile":
                                    {
                                        cp.Use = ContactPoint.ContactPointUse.Mobile;
                                        break;
                                    }
                                case "temp":
                                    {
                                        cp.Use = ContactPoint.ContactPointUse.Temp;
                                        break;
                                    }
                                case "old":
                                    {
                                        cp.Use = ContactPoint.ContactPointUse.Old;
                                        break;
                                    }
                            }

                            cp.Value = patientTelecom.Value;

                            fhirPatient.Telecom.Add(cp);
                        }

                        #endregion

                        #region Identifier

                        foreach (PATIENT_IDENTIFIER patientIdentifier in dbPatient.PATIENT_IDENTIFIER)
                        {
                            Identifier idf = new Identifier();
                            Period p = new Period();
                            if (patientIdentifier.PeriodStart.HasValue)
                                p.Start = patientIdentifier.PeriodStart.Value.ToString("yyyy-MM-dd");
                            if (patientIdentifier.PeriodEnd.HasValue)
                                p.Start = patientIdentifier.PeriodEnd.Value.ToString("yyyy-MM-dd");
                            idf.Period = p;
                            idf.Label = patientIdentifier.Label;
                            idf.System = patientIdentifier.System;
                            idf.Value = patientIdentifier.Value;
                            switch (patientIdentifier.Use)
                            {
                                case "official":
                                    {
                                        idf.Use = Identifier.IdentifierUse.Official;
                                        break;
                                    }

                                case "secondary":
                                    {
                                        idf.Use = Identifier.IdentifierUse.Secondary;
                                        break;
                                    }

                                case "temp":
                                    {
                                        idf.Use = Identifier.IdentifierUse.Temp;
                                        break;
                                    }

                                case "usual":
                                    {
                                        idf.Use = Identifier.IdentifierUse.Usual;
                                        break;
                                    }
                            }
                            if (patientIdentifier.Assigner != null)
                            {
                                ResourceReference rr = new ResourceReference();
                                rr.Reference = "/Organization/" + patientIdentifier.Assigner;
                                idf.Assigner = rr;
                            }

                            fhirPatient.Identifier.Add(idf);
                        }

                        #endregion

                        #region Contact

                        foreach (PATIENT_CONTACT patientContact in dbPatient.PATIENT_CONTACT)
                        {
                            Patient.ContactComponent cp = new Patient.ContactComponent();
                            Period p = new Period();
                            if (patientContact.PeriodStart.HasValue)
                                p.Start = patientContact.PeriodStart.Value.ToString("yyyy-MM-dd");
                            if (patientContact.PeriodEnd.HasValue)
                                p.End = patientContact.PeriodEnd.Value.ToString("yyyy-MM-dd");
                            cp.Period = p;

                            HumanName hn = new HumanName();
                            p = new Period();
                            if (patientContact.NamePeriodStart.HasValue)
                                p.Start = patientContact.NamePeriodStart.Value.ToString("yyyy-MM-dd");
                            if (patientContact.NamePeriodEnd.HasValue)
                                p.End = patientContact.NamePeriodEnd.Value.ToString("yyyy-MM-dd");
                            hn.Period = p;

                            if (patientContact.NameFamily != null)
                            {
                                string[] _family = Regex.Split(patientContact.NameFamily, Options.STRING_DELIMITER);
                                hn.Family = _family.AsEnumerable();
                            }
                            if (patientContact.NameGiven != null)
                            {
                                string[] _given = Regex.Split(patientContact.NameGiven, Options.STRING_DELIMITER);
                                hn.Given = _given.AsEnumerable();
                            }
                            if (patientContact.NamePrefix != null)
                            {
                                string[] _prefix = Regex.Split(patientContact.NamePrefix, Options.STRING_DELIMITER);
                                hn.Prefix = _prefix.AsEnumerable();
                            }
                            if (patientContact.NameSuffix != null)
                            {
                                string[] _suffix = Regex.Split(patientContact.NameSuffix, Options.STRING_DELIMITER);
                                hn.Suffix = _suffix.AsEnumerable();
                            }
                            hn.Text = patientContact.NameText;

                            switch (patientContact.NameUse)
                            {
                                case "official":
                                    {
                                        hn.Use = HumanName.NameUse.Official;
                                        break;
                                    }

                                case "anonymous":
                                    {

                                        hn.Use = HumanName.NameUse.Anonymous;
                                        break;
                                    }

                                case "maiden":
                                    {
                                        hn.Use = HumanName.NameUse.Maiden;
                                        break;
                                    }

                                case "nickname":
                                    {
                                        hn.Use = HumanName.NameUse.Nickname;
                                        break;
                                    }

                                case "old":
                                    {
                                        hn.Use = HumanName.NameUse.Old;
                                        break;
                                    }

                                case "temp":
                                    {
                                        hn.Use = HumanName.NameUse.Temp;
                                        break;
                                    }

                                case "usual":
                                    {
                                        hn.Use = HumanName.NameUse.Usual;
                                        break;
                                    }
                            }

                            cp.Name = hn;

                            if (patientContact.Gender != null)
                            {
                                switch (patientContact.Gender)
                                {
                                    case "male":
                                        {
                                            cp.Gender = AdministrativeGender.Male;
                                            break;
                                        }
                                    case "female":
                                        {
                                            cp.Gender = AdministrativeGender.Female;
                                            break;
                                        }


                                    case "other":
                                        {
                                            cp.Gender = AdministrativeGender.Other;
                                            break;
                                        }

                                    case "unknown":
                                        {
                                            cp.Gender = AdministrativeGender.Unknown;
                                            break;
                                        }
                                }
                            }

                            Address a = new Address();

                            p = new Period();
                            if (patientContact.AddressPeriodStart.HasValue)
                                p.Start = patientContact.AddressPeriodStart.Value.ToString("yyyy-MM-dd");
                            if (patientContact.AddressPeriodEnd.HasValue)
                                p.End = patientContact.AddressPeriodEnd.Value.ToString("yyyy-MM-dd");
                            a.Period = p;
                            a.PostalCode = patientContact.AddressPostalCode;

                            a.City = patientContact.AddressCity;
                            a.Country = patientContact.AddressCountry;
                            a.State = patientContact.AddressState;
                            if (patientContact.AddressLine != null)
                            {
                                string[] _lines = Regex.Split(patientContact.AddressLine, Options.STRING_DELIMITER);
                                a.Line = _lines.AsEnumerable();
                            }

                            switch (patientContact.AddressUse)
                            {
                                case "home":
                                    {
                                        a.Use = Address.AddressUse.Home;
                                        break;
                                    }
                                case "old":
                                    {
                                        a.Use = Address.AddressUse.Old;
                                        break;
                                    }
                                case "temp":
                                    {
                                        a.Use = Address.AddressUse.Temp;
                                        break;
                                    }
                                case "work":
                                    {
                                        a.Use = Address.AddressUse.Work;
                                        break;
                                    }
                            }
                            cp.Address = a;
                        }

                        #endregion


                        ////CARE PROVIDER REFERENCE
                        //ResourceReference rr = new ResourceReference();
                        //rr.Reference = "/Practitioner/org1";
                        //fhirPatient.CareProvider = new List<ResourceReference>() { rr };                 


                        //if (dbPatient.ContactPersonFirstName != null || dbPatient.ContactPersonLastName != null)
                        //{
                        //    fhirPatient.Contact = new List<Patient.ContactComponent>() 
                        //    { 
                        //        new Patient.ContactComponent() 
                        //        { 
                        //            Name = HumanName.ForFamily(dbPatient.ContactPersonLastName).WithGiven(dbPatient.ContactPersonFirstName), 
                        //            Address = new Address() { Line = new List<string>() { dbPatient.ContactPersonAddress }},
                        //            Telecom = new List<ContactPoint>() { new ContactPoint(){ System = ContactPoint.ContactPointSystem.Phone, Value = dbPatient.ContactPersonPhone } }
                        //        } 
                        //    };
                        //}

                        //if (dbPatient.Race != null)
                        //    fhirPatient.Extension.Add(new Extension() { Url = "http://hl7.org/fhir/ExtensionDefinition/us-core-race", Value = new CodeableConcept("http://hl7.org/fhir/ExtensionDefinition/us-core-race", dbPatient.Race) });
                        //if (dbPatient.Religion != null)
                        //    fhirPatient.Extension.Add(new Extension() { Url = "http://hl7.org/fhir/ExtensionDefinition/us-core-religion", Value = new CodeableConcept("http://hl7.org/fhir/ExtensionDefinition/us-core-religion", dbPatient.Religion) });
                        //if (dbPatient.MothersMaidenName != null)
                        //    fhirPatient.Extension.Add(new Extension() { Url = "http://hl7.org/fhir/ExtensionDefinition/patient-mothers-maiden-name", Value = new FhirString(dbPatient.MothersMaidenName) });
                        //if (dbPatient.Ethnicity != null)
                        //    fhirPatient.Extension.Add(new Extension() { Url = "http://hl7.org/fhir/ExtensionDefinition/us-core-ethnicity", Value = new CodeableConcept("http://hl7.org/fhir/ExtensionDefinition/us-core-ethnicity", dbPatient.Ethnicity) });

                        //if (dbPatient.PlaceOfBirth != null)
                        //    fhirPatient.Extension.Add(new Extension() { Url = "http://hl7.org/fhir/ExtensionDefinition/us-core-birth-place", Value = new Address() { Line = new List<string>() { dbPatient.PlaceOfBirth } } });



                        return fhirPatient;
                    }
                default:
                    return null;
            }
        }
    }
}