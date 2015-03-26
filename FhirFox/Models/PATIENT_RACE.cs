namespace FhirFox.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrative.PATIENT_RACE")]
    public partial class PATIENT_RACE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientRaceId { get; set; }

        [Required]
        [StringLength(64)]
        public string PatientId { get; set; }

        [Required]
        [StringLength(6)]
        public string Code { get; set; }

        public string Text { get; set; }

        public virtual PATIENT PATIENT { get; set; }
    }
}
