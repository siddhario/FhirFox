namespace FhirFox.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrative.PATIENT_TELECOM")]
    public partial class PATIENT_TELECOM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientTelecomId { get; set; }

        [Required]
        [StringLength(64)]
        public string PatientId { get; set; }

        [StringLength(5)]
        public string System { get; set; }

        public string Value { get; set; }

        [StringLength(6)]
        public string Use { get; set; }

        public DateTime? PeriodStart { get; set; }

        public DateTime? PeriodEnd { get; set; }

        public virtual PATIENT PATIENT { get; set; }
    }
}
