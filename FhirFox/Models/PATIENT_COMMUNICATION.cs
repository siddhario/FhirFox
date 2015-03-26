namespace FhirFox.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrative.PATIENT_COMMUNICATION")]
    public partial class PATIENT_COMMUNICATION
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientCommunicationId { get; set; }

        [Required]
        [StringLength(64)]
        public string PatientId { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public string Text { get; set; }

        public virtual PATIENT PATIENT { get; set; }
    }
}
