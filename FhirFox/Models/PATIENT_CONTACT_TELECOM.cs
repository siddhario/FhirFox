namespace FhirFox.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrative.PATIENT_CONTACT_TELECOM")]
    public partial class PATIENT_CONTACT_TELECOM
    {
        public int PatientContactId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientContactTelecomId { get; set; }

        [StringLength(5)]
        public string System { get; set; }

        public string Value { get; set; }

        [StringLength(6)]
        public string Use { get; set; }

        public DateTime? PeriodStart { get; set; }

        public DateTime? PeriodEnd { get; set; }

        public virtual PATIENT_CONTACT PATIENT_CONTACT { get; set; }
    }
}
