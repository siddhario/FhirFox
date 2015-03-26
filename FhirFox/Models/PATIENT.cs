namespace FhirFox.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrative.PATIENT")]
    public partial class PATIENT
    {
        public PATIENT()
        {
            PATIENT_ADDRESS = new HashSet<PATIENT_ADDRESS>();
            PATIENT_CARE_PROVIDERS = new HashSet<PATIENT_CARE_PROVIDERS>();
            PATIENT_COMMUNICATION = new HashSet<PATIENT_COMMUNICATION>();
            PATIENT_CONTACT = new HashSet<PATIENT_CONTACT>();
            PATIENT_IDENTIFIER = new HashSet<PATIENT_IDENTIFIER>();
            PATIENT_LINK = new HashSet<PATIENT_LINK>();
            PATIENT_NAME = new HashSet<PATIENT_NAME>();
            PATIENT_PHOTO = new HashSet<PATIENT_PHOTO>();
            PATIENT_RACE = new HashSet<PATIENT_RACE>();
            PATIENT_TELECOM = new HashSet<PATIENT_TELECOM>();
        }

        [StringLength(64)]
        public string PatientId { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool? Deceased { get; set; }

        public DateTime? DeceasedDateTime { get; set; }

        [StringLength(1)]
        public string MaritalStatus { get; set; }

        public bool? MultipleBirth { get; set; }

        public int? MultipleBirthOrder { get; set; }

        public bool? Active { get; set; }

        public string MothersMaidenName { get; set; }

        public string Ethnicity { get; set; }

        public string Religion { get; set; }

        [StringLength(7)]
        public string Gender { get; set; }

        [StringLength(64)]
        public string ManagingOrganizationId { get; set; }

        [StringLength(4)]
        public string BirthPlaceAddressUse { get; set; }

        public string BirthPlaceAddressText { get; set; }

        public string BirthPlaceAddressLine { get; set; }

        public string BirthPlaceAddressCity { get; set; }

        public string BirthPlaceAddressState { get; set; }

        public string BirthPlaceAddressPostalCode { get; set; }

        public string BirthPlaceAddressCountry { get; set; }

        public DateTime? BirthPlaceAddressPeriodStart { get; set; }

        public DateTime? BirthPlaceAddressPeriodEnd { get; set; }

        public virtual ICollection<PATIENT_ADDRESS> PATIENT_ADDRESS { get; set; }

        public virtual ICollection<PATIENT_CARE_PROVIDERS> PATIENT_CARE_PROVIDERS { get; set; }

        public virtual ICollection<PATIENT_COMMUNICATION> PATIENT_COMMUNICATION { get; set; }

        public virtual ICollection<PATIENT_CONTACT> PATIENT_CONTACT { get; set; }

        public virtual ICollection<PATIENT_IDENTIFIER> PATIENT_IDENTIFIER { get; set; }

        public virtual ICollection<PATIENT_LINK> PATIENT_LINK { get; set; }

        public virtual ICollection<PATIENT_NAME> PATIENT_NAME { get; set; }

        public virtual ICollection<PATIENT_PHOTO> PATIENT_PHOTO { get; set; }

        public virtual ICollection<PATIENT_RACE> PATIENT_RACE { get; set; }

        public virtual ICollection<PATIENT_TELECOM> PATIENT_TELECOM { get; set; }
    }
}
