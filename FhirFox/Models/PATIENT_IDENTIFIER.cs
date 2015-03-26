namespace FhirFox.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrative.PATIENT_IDENTIFIER")]
    public partial class PATIENT_IDENTIFIER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientIdentifierId { get; set; }

        [Required]
        [StringLength(64)]
        public string PatientId { get; set; }

        [Required]
        public string System { get; set; }

        [Required]
        public string Value { get; set; }

        [StringLength(9)]
        public string Use { get; set; }

        public string Label { get; set; }

        public DateTime? PeriodStart { get; set; }

        public DateTime? PeriodEnd { get; set; }

        [StringLength(64)]
        public string Assigner { get; set; }

        public virtual PATIENT PATIENT { get; set; }
    }
}
