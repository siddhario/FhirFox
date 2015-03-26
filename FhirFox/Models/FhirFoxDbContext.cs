namespace FhirFox.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FhirFoxDbContext : DbContext
    {
        public FhirFoxDbContext()
            : base("name=FhirFoxDbContext5")
        {
        }

        public virtual DbSet<PATIENT> PATIENTs { get; set; }
        public virtual DbSet<PATIENT_ADDRESS> PATIENT_ADDRESS { get; set; }
        public virtual DbSet<PATIENT_CARE_PROVIDERS> PATIENT_CARE_PROVIDERS { get; set; }
        public virtual DbSet<PATIENT_COMMUNICATION> PATIENT_COMMUNICATION { get; set; }
        public virtual DbSet<PATIENT_CONTACT> PATIENT_CONTACT { get; set; }
        public virtual DbSet<PATIENT_CONTACT_RELATIONSHIP> PATIENT_CONTACT_RELATIONSHIP { get; set; }
        public virtual DbSet<PATIENT_CONTACT_TELECOM> PATIENT_CONTACT_TELECOM { get; set; }
        public virtual DbSet<PATIENT_IDENTIFIER> PATIENT_IDENTIFIER { get; set; }
        public virtual DbSet<PATIENT_LINK> PATIENT_LINK { get; set; }
        public virtual DbSet<PATIENT_NAME> PATIENT_NAME { get; set; }
        public virtual DbSet<PATIENT_PHOTO> PATIENT_PHOTO { get; set; }
        public virtual DbSet<PATIENT_RACE> PATIENT_RACE { get; set; }
        public virtual DbSet<PATIENT_TELECOM> PATIENT_TELECOM { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PATIENT>()
                .Property(e => e.PatientId)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT>()
                .Property(e => e.MaritalStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT>()
                .Property(e => e.ManagingOrganizationId)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT>()
                .Property(e => e.BirthPlaceAddressUse)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT>()
                .HasMany(e => e.PATIENT_ADDRESS)
                .WithRequired(e => e.PATIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATIENT>()
                .HasMany(e => e.PATIENT_CARE_PROVIDERS)
                .WithRequired(e => e.PATIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATIENT>()
                .HasMany(e => e.PATIENT_COMMUNICATION)
                .WithRequired(e => e.PATIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATIENT>()
                .HasMany(e => e.PATIENT_CONTACT)
                .WithRequired(e => e.PATIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATIENT>()
                .HasMany(e => e.PATIENT_IDENTIFIER)
                .WithRequired(e => e.PATIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATIENT>()
                .HasMany(e => e.PATIENT_LINK)
                .WithRequired(e => e.PATIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATIENT>()
                .HasMany(e => e.PATIENT_NAME)
                .WithRequired(e => e.PATIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATIENT>()
                .HasMany(e => e.PATIENT_RACE)
                .WithRequired(e => e.PATIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATIENT>()
                .HasMany(e => e.PATIENT_TELECOM)
                .WithRequired(e => e.PATIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATIENT_ADDRESS>()
                .Property(e => e.PatientId)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_ADDRESS>()
                .Property(e => e.Use)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_CARE_PROVIDERS>()
                .Property(e => e.PatientId)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_COMMUNICATION>()
                .Property(e => e.PatientId)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_COMMUNICATION>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_CONTACT>()
                .Property(e => e.PatientId)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_CONTACT>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_CONTACT>()
                .Property(e => e.NameUse)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_CONTACT>()
                .Property(e => e.AddressUse)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_CONTACT>()
                .HasMany(e => e.PATIENT_CONTACT_RELATIONSHIP)
                .WithRequired(e => e.PATIENT_CONTACT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATIENT_CONTACT>()
                .HasMany(e => e.PATIENT_CONTACT_TELECOM)
                .WithRequired(e => e.PATIENT_CONTACT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATIENT_CONTACT_RELATIONSHIP>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_CONTACT_TELECOM>()
                .Property(e => e.System)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_CONTACT_TELECOM>()
                .Property(e => e.Use)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_IDENTIFIER>()
                .Property(e => e.PatientId)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_IDENTIFIER>()
                .Property(e => e.Use)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_IDENTIFIER>()
                .Property(e => e.Assigner)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_LINK>()
                .Property(e => e.PatientId)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_LINK>()
                .Property(e => e.Other)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_LINK>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_NAME>()
                .Property(e => e.PatientId)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_NAME>()
                .Property(e => e.Use)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_PHOTO>()
                .Property(e => e.PatientId)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_PHOTO>()
                .Property(e => e.ContentType)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_PHOTO>()
                .Property(e => e.Language)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_RACE>()
                .Property(e => e.PatientId)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_RACE>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_TELECOM>()
                .Property(e => e.PatientId)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_TELECOM>()
                .Property(e => e.System)
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT_TELECOM>()
                .Property(e => e.Use)
                .IsUnicode(false);
        }
    }
}
