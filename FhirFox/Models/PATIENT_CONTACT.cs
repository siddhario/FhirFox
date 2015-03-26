namespace FhirFox.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrative.PATIENT_CONTACT")]
    public partial class PATIENT_CONTACT
    {
        public PATIENT_CONTACT()
        {
            PATIENT_CONTACT_RELATIONSHIP = new HashSet<PATIENT_CONTACT_RELATIONSHIP>();
            PATIENT_CONTACT_TELECOM = new HashSet<PATIENT_CONTACT_TELECOM>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientContactId { get; set; }

        [Required]
        [StringLength(64)]
        public string PatientId { get; set; }

        [StringLength(7)]
        public string Gender { get; set; }

        public DateTime? PeriodStart { get; set; }

        public DateTime? PeriodEnd { get; set; }

        [StringLength(10)]
        public string NameUse { get; set; }

        public string NameText { get; set; }

        public string NameFamily { get; set; }

        public string NameGiven { get; set; }

        public string NamePrefix { get; set; }

        public string NameSuffix { get; set; }

        public string NamePeriodStart { get; set; }

        public string NamePeriodEnd { get; set; }

        [StringLength(4)]
        public string AddressUse { get; set; }

        public string AddressText { get; set; }

        public string AddressLine { get; set; }

        public string AddressCity { get; set; }

        public string AddressState { get; set; }

        public string AddressPostalCode { get; set; }

        public string AddressCountry { get; set; }

        public DateTime? AddressPeriodStart { get; set; }

        public DateTime? AddressPeriodEnd { get; set; }

        public virtual PATIENT PATIENT { get; set; }

        public virtual ICollection<PATIENT_CONTACT_RELATIONSHIP> PATIENT_CONTACT_RELATIONSHIP { get; set; }

        public virtual ICollection<PATIENT_CONTACT_TELECOM> PATIENT_CONTACT_TELECOM { get; set; }
    }
}
