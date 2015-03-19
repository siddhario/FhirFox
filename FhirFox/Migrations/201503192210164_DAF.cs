namespace FhirFox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DAF : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DBPatients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Pin = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        Gender = c.String(),
                        BirthDate = c.DateTime(),
                        Deceased = c.Boolean(),
                        MaritalStatus = c.String(),
                        ContactPersonFirstName = c.String(),
                        ContactPersonLastName = c.String(),
                        ContactPersonAddress = c.String(),
                        ContactPersonPhone = c.String(),
                        Active = c.Boolean(),
                        Race = c.String(),
                        Ethnicity = c.String(),
                        Religion = c.String(),
                        MothersMaidenName = c.String(),
                        PlaceOfBirth = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DBPatients");
        }
    }
}
