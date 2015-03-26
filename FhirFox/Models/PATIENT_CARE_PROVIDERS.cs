namespace FhirFox.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrative.PATIENT_CARE_PROVIDERS")]
    public partial class PATIENT_CARE_PROVIDERS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientCareProviderId { get; set; }

        [Required]
        [StringLength(64)]
        public string PatientId { get; set; }

        public string OrganizationId { get; set; }

        public string PractitionerId { get; set; }

        public virtual PATIENT PATIENT { get; set; }
    }
}
