namespace FhirFox.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrative.PATIENT_NAME")]
    public partial class PATIENT_NAME
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientNameId { get; set; }

        [Required]
        [StringLength(64)]
        public string PatientId { get; set; }

        [StringLength(10)]
        public string Use { get; set; }

        public string Text { get; set; }

        public string Family { get; set; }

        public string Given { get; set; }

        public string Prefix { get; set; }

        public string Suffix { get; set; }

        public DateTime? PeriodStart { get; set; }

        public DateTime? PeriodEnd { get; set; }

        public virtual PATIENT PATIENT { get; set; }
    }
}
