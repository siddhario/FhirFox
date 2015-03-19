namespace FhirFox.Models
{
    using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

    public class FhirDbContext : DbContext
    {
        // Your context has been configured to use a 'FhirDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FhirFox.Models.FhirDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FhirDbContext' 
        // connection string in the application configuration file.
        public FhirDbContext()
            : base("name=FhirDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<DBPatient> Patients { get; set; }
    }

    public class DBPatient
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Pin { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? Deceased { get; set; }
        public string MaritalStatus { get; set; }
        public string ContactPersonFirstName {get;set;}
        public string ContactPersonLastName { get; set; }
        public string ContactPersonAddress { get; set; }
        public string ContactPersonPhone { get; set; }
        public bool? Active { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }
        public string Religion { get; set; }
        public string MothersMaidenName { get; set; }
        public string PlaceOfBirth { get; set; }       
    }
}
