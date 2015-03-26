namespace FhirFox.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrative.PATIENT_PHOTO")]
    public partial class PATIENT_PHOTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientPhotoId { get; set; }

        [StringLength(64)]
        public string PatientId { get; set; }

        [StringLength(50)]
        public string ContentType { get; set; }

        [StringLength(30)]
        public string Language { get; set; }

        public string Url { get; set; }

        public int? Size { get; set; }

        public byte[] Data { get; set; }

        public byte[] Hash { get; set; }

        public virtual PATIENT PATIENT { get; set; }
    }
}
