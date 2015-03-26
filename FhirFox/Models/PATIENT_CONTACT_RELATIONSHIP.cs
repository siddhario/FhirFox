namespace FhirFox.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrative.PATIENT_CONTACT_RELATIONSHIP")]
    public partial class PATIENT_CONTACT_RELATIONSHIP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientContactRelationshipId { get; set; }

        public int PatientContactId { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public string Text { get; set; }

        public virtual PATIENT_CONTACT PATIENT_CONTACT { get; set; }
    }
}
