namespace FhirFox.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrative.PATIENT_LINK")]
    public partial class PATIENT_LINK
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientLinkId { get; set; }

        [Required]
        [StringLength(64)]
        public string PatientId { get; set; }

        [Required]
        [StringLength(64)]
        public string Other { get; set; }

        [Required]
        [StringLength(7)]
        public string Type { get; set; }

        public virtual PATIENT PATIENT { get; set; }
    }
}
