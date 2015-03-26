namespace FhirFox.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrative.PATIENT_ADDRESS")]
    public partial class PATIENT_ADDRESS
    {
        [Required]
        [StringLength(64)]
        public string PatientId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientAddressId { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        [StringLength(4)]
        public string Use { get; set; }

        public string Text { get; set; }

        public DateTime? PeriodStart { get; set; }

        public DateTime? PeriodEnd { get; set; }

        public virtual PATIENT PATIENT { get; set; }
    }
}
