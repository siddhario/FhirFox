/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     3/26/2015 3:29:15 PM                         */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMINISTRATIVE.PATIENT_ADDRESS') and o.name = 'FK_Patient_Address')
alter table ADMINISTRATIVE.PATIENT_ADDRESS
   drop constraint FK_Patient_Address
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMINISTRATIVE.PATIENT_CARE_PROVIDERS') and o.name = 'FK_Patient_Care_Providers')
alter table ADMINISTRATIVE.PATIENT_CARE_PROVIDERS
   drop constraint FK_Patient_Care_Providers
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMINISTRATIVE.PATIENT_COMMUNICATION') and o.name = 'FK_Patient_Communications')
alter table ADMINISTRATIVE.PATIENT_COMMUNICATION
   drop constraint FK_Patient_Communications
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMINISTRATIVE.PATIENT_CONTACT') and o.name = 'FK_Patient_Contacts')
alter table ADMINISTRATIVE.PATIENT_CONTACT
   drop constraint FK_Patient_Contacts
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMINISTRATIVE.PATIENT_CONTACT_RELATIONSHIP') and o.name = 'FK_Patient_Contact_Relationships')
alter table ADMINISTRATIVE.PATIENT_CONTACT_RELATIONSHIP
   drop constraint FK_Patient_Contact_Relationships
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMINISTRATIVE.PATIENT_CONTACT_TELECOM') and o.name = 'FK_Patient_Contact_Telecoms')
alter table ADMINISTRATIVE.PATIENT_CONTACT_TELECOM
   drop constraint FK_Patient_Contact_Telecoms
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMINISTRATIVE.PATIENT_IDENTIFIER') and o.name = 'FK_Patient_Identifiers')
alter table ADMINISTRATIVE.PATIENT_IDENTIFIER
   drop constraint FK_Patient_Identifiers
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMINISTRATIVE.PATIENT_LINK') and o.name = 'FK_Patient_Links')
alter table ADMINISTRATIVE.PATIENT_LINK
   drop constraint FK_Patient_Links
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMINISTRATIVE.PATIENT_NAME') and o.name = 'FK_Patient_Names')
alter table ADMINISTRATIVE.PATIENT_NAME
   drop constraint FK_Patient_Names
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMINISTRATIVE.PATIENT_PHOTO') and o.name = 'FK_Patient_Photos')
alter table ADMINISTRATIVE.PATIENT_PHOTO
   drop constraint FK_Patient_Photos
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMINISTRATIVE.PATIENT_RACE') and o.name = 'FK_Patient_Races')
alter table ADMINISTRATIVE.PATIENT_RACE
   drop constraint FK_Patient_Races
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ADMINISTRATIVE.PATIENT_TELECOM') and o.name = 'FK_Patient_Telecoms')
alter table ADMINISTRATIVE.PATIENT_TELECOM
   drop constraint FK_Patient_Telecoms
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRATIVE.PATIENT')
            and   type = 'U')
   drop table ADMINISTRATIVE.PATIENT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRATIVE.PATIENT_ADDRESS')
            and   type = 'U')
   drop table ADMINISTRATIVE.PATIENT_ADDRESS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRATIVE.PATIENT_CARE_PROVIDERS')
            and   type = 'U')
   drop table ADMINISTRATIVE.PATIENT_CARE_PROVIDERS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRATIVE.PATIENT_COMMUNICATION')
            and   type = 'U')
   drop table ADMINISTRATIVE.PATIENT_COMMUNICATION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRATIVE.PATIENT_CONTACT')
            and   type = 'U')
   drop table ADMINISTRATIVE.PATIENT_CONTACT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRATIVE.PATIENT_CONTACT_RELATIONSHIP')
            and   type = 'U')
   drop table ADMINISTRATIVE.PATIENT_CONTACT_RELATIONSHIP
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRATIVE.PATIENT_CONTACT_TELECOM')
            and   type = 'U')
   drop table ADMINISTRATIVE.PATIENT_CONTACT_TELECOM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRATIVE.PATIENT_IDENTIFIER')
            and   type = 'U')
   drop table ADMINISTRATIVE.PATIENT_IDENTIFIER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRATIVE.PATIENT_LINK')
            and   type = 'U')
   drop table ADMINISTRATIVE.PATIENT_LINK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRATIVE.PATIENT_NAME')
            and   type = 'U')
   drop table ADMINISTRATIVE.PATIENT_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRATIVE.PATIENT_PHOTO')
            and   type = 'U')
   drop table ADMINISTRATIVE.PATIENT_PHOTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRATIVE.PATIENT_RACE')
            and   type = 'U')
   drop table ADMINISTRATIVE.PATIENT_RACE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ADMINISTRATIVE.PATIENT_TELECOM')
            and   type = 'U')
   drop table ADMINISTRATIVE.PATIENT_TELECOM
go

execute sp_revokedbaccess ADMINISTRATIVE
go

/*==============================================================*/
/* User: ADMINISTRATIVE                                         */
/*==============================================================*/
execute sp_grantdbaccess ADMINISTRATIVE
go

/*==============================================================*/
/* Table: PATIENT                                               */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT (
   PatientId            varchar(64)          not null,
   BirthDate            datetime             null,
   Deceased             bit                  null,
   DeceasedDateTime     datetime             null,
   MaritalStatus        char(1)              null,
   MultipleBirth        bit                  null,
   MultipleBirthOrder   int                  null,
   Active               bit                  null,
   MothersMaidenName    nvarchar(Max)        null,
   Ethnicity            nvarchar(Max)        null,
   Religion             nvarchar(Max)        null,
   Gender               varchar(7)           null
      constraint CKC_GENDER_PATIENT check (Gender is null or (Gender in ('male','female','other','unknown'))),
   ManagingOrganizationId varchar(64)          null,
   BirthPlaceAddressUse varchar(4)           null,
   BirthPlaceAddressText nvarchar(Max)        null,
   BirthPlaceAddressLine nvarchar(Max)        null,
   BirthPlaceAddressCity nvarchar(Max)        null,
   BirthPlaceAddressState nvarchar(Max)        null,
   BirthPlaceAddressPostalCode nvarchar(Max)        null,
   BirthPlaceAddressCountry nvarchar(Max)        null,
   BirthPlaceAddressPeriodStart datetime             null,
   BirthPlaceAddressPeriodEnd datetime             null,
   constraint PK_PATIENT primary key (PatientId)
)
go

/*==============================================================*/
/* Table: PATIENT_ADDRESS                                       */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_ADDRESS (
   PatientId            varchar(64)          not null,
   PatientAddressId     int                  not null,
   Line                 nvarchar(Max)        not null,
   City                 nvarchar(Max)        not null,
   State                nvarchar(Max)        not null,
   PostalCode           nvarchar(Max)        null,
   Country              nvarchar(Max)        not null,
   "Use"                varchar(4)           null,
   Text                 nvarchar(Max)        null,
   PeriodStart          datetime             null,
   PeriodEnd            datetime             null,
   constraint PK_PATIENT_ADDRESS primary key (PatientAddressId)
)
go

/*==============================================================*/
/* Table: PATIENT_CARE_PROVIDERS                                */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_CARE_PROVIDERS (
   PatientCareProviderId int                  not null,
   PatientId            varchar(64)          not null,
   OrganizationId       nvarchar(Max)        null,
   PractitionerId       nvarchar(Max)        null,
   constraint PK_PATIENT_CARE_PROVIDERS primary key (PatientCareProviderId)
)
go

/*==============================================================*/
/* Table: PATIENT_COMMUNICATION                                 */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_COMMUNICATION (
   PatientCommunicationId int                  not null,
   PatientId            varchar(64)          not null,
   Code                 varchar(50)          not null,
   Text                 nvarchar(Max)        null,
   constraint PK_PATIENT_COMMUNICATION primary key (PatientCommunicationId)
)
go

execute sp_addextendedproperty 'MS_Description', 
   'http://tools.ietf.org/html/bcp47',
   'user', 'ADMINISTRATIVE', 'table', 'PATIENT_COMMUNICATION', 'column', 'Code'
go

/*==============================================================*/
/* Table: PATIENT_CONTACT                                       */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_CONTACT (
   PatientContactId     int                  not null,
   PatientId            varchar(64)          not null,
   Gender               varchar(7)           null,
   PeriodStart          datetime             null,
   PeriodEnd            datetime             null,
   NameUse              varchar(10)          null,
   NameText             nvarchar(Max)        null,
   NameFamily           nvarchar(Max)        null,
   NameGiven            nvarchar(Max)        null,
   NamePrefix           nvarchar(Max)        null,
   NameSuffix           nvarchar(Max)        null,
   NamePeriodStart      nvarchar(Max)        null,
   NamePeriodEnd        nvarchar(Max)        null,
   AddressUse           varchar(4)           null,
   AddressText          nvarchar(Max)        null,
   AddressLine          nvarchar(Max)        null,
   AddressCity          nvarchar(Max)        null,
   AddressState         nvarchar(Max)        null,
   AddressPostalCode    nvarchar(Max)        null,
   AddressCountry       nvarchar(Max)        null,
   AddressPeriodStart   datetime             null,
   AddressPeriodEnd     datetime             null,
   constraint PK_PATIENT_CONTACT primary key (PatientContactId)
)
go

/*==============================================================*/
/* Table: PATIENT_CONTACT_RELATIONSHIP                          */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_CONTACT_RELATIONSHIP (
   PatientContactRelationshipId int                  not null,
   PatientContactId     int                  not null,
   Code                 varchar(50)          not null,
   Text                 nvarchar(Max)        null,
   constraint PK_PATIENT_CONTACT_RELATIONSHI primary key (PatientContactRelationshipId)
)
go

execute sp_addextendedproperty 'MS_Description', 
   'V3 - 2.16.840.1.113883.5.111',
   'user', 'ADMINISTRATIVE', 'table', 'PATIENT_CONTACT_RELATIONSHIP', 'column', 'Code'
go

/*==============================================================*/
/* Table: PATIENT_CONTACT_TELECOM                               */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_CONTACT_TELECOM (
   PatientContactId     int                  not null,
   PatientContactTelecomId int                  not null,
   System               varchar(5)           null,
   Value                nvarchar(Max)        null,
   "Use"                varchar(6)           null,
   PeriodStart          datetime             null,
   PeriodEnd            datetime             null,
   constraint PK_PATIENT_CONTACT_TELECOM primary key (PatientContactTelecomId)
)
go

/*==============================================================*/
/* Table: PATIENT_IDENTIFIER                                    */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_IDENTIFIER (
   PatientIdentifierId  int                  not null,
   PatientId            varchar(64)          not null,
   System               nvarchar(Max)        not null,
   Value                nvarchar(Max)        not null,
   "Use"                varchar(9)           null,
   Label                nvarchar(Max)        null,
   PeriodStart          datetime             null,
   PeriodEnd            datetime             null,
   Assigner             varchar(64)          null,
   constraint PK_PATIENT_IDENTIFIER primary key (PatientIdentifierId)
)
go

/*==============================================================*/
/* Table: PATIENT_LINK                                          */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_LINK (
   PatientLinkId        int                  not null,
   PatientId            varchar(64)          not null,
   Other                varchar(64)          not null,
   Type                 varchar(7)           not null,
   constraint PK_PATIENT_LINK primary key (PatientLinkId)
)
go

execute sp_addextendedproperty 'MS_Description', 
   'http://hl7.org/fhir/link-type',
   'user', 'ADMINISTRATIVE', 'table', 'PATIENT_LINK', 'column', 'Type'
go

/*==============================================================*/
/* Table: PATIENT_NAME                                          */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_NAME (
   PatientNameId        int                  not null,
   PatientId            varchar(64)          not null,
   "Use"                varchar(10)          null
      constraint CKC_USE_PATIENT_ check ("Use" is null or ("Use" in ('usual','official','temp','nickname','anonymous','old','maiden'))),
   Text                 nvarchar(Max)        null,
   Family               nvarchar(Max)        null,
   Given                nvarchar(Max)        null,
   Prefix               nvarchar(Max)        null,
   Suffix               nvarchar(Max)        null,
   PeriodStart          datetime             null,
   PeriodEnd            datetime             null,
   constraint PK_PATIENT_NAME primary key (PatientNameId)
)
go

/*==============================================================*/
/* Table: PATIENT_PHOTO                                         */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_PHOTO (
   PatientPhotoId       int                  not null,
   PatientId            varchar(64)          null,
   ContentType          varchar(50)          null,
   Language             varchar(30)          null,
   Url                  nvarchar(Max)        null,
   Size                 int                  null,
   Data                 binary varying(Max)  null,
   Hash                 binary varying(Max)  null,
   constraint PK_PATIENT_PHOTO primary key (PatientPhotoId)
)
go

execute sp_addextendedproperty 'MS_Description', 
   'http://www.rfc-editor.org/bcp/bcp13.txt',
   'user', 'ADMINISTRATIVE', 'table', 'PATIENT_PHOTO', 'column', 'ContentType'
go

execute sp_addextendedproperty 'MS_Description', 
   'http://tools.ietf.org/html/bcp47',
   'user', 'ADMINISTRATIVE', 'table', 'PATIENT_PHOTO', 'column', 'Language'
go

/*==============================================================*/
/* Table: PATIENT_RACE                                          */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_RACE (
   PatientRaceId        int                  not null,
   PatientId            varchar(64)          not null,
   Code                 varchar(6)           not null,
   Text                 nvarchar(Max)        null,
   constraint PK_PATIENT_RACE primary key (PatientRaceId)
)
go

/*==============================================================*/
/* Table: PATIENT_TELECOM                                       */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_TELECOM (
   PatientTelecomId     int                  not null,
   PatientId            varchar(64)          not null,
   System               varchar(5)           null,
   Value                nvarchar(Max)        null,
   "Use"                varchar(6)           null,
   PeriodStart          datetime             null,
   PeriodEnd            datetime             null,
   constraint PK_PATIENT_TELECOM primary key (PatientTelecomId)
)
go

alter table ADMINISTRATIVE.PATIENT_ADDRESS
   add constraint FK_Patient_Address foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
go

alter table ADMINISTRATIVE.PATIENT_CARE_PROVIDERS
   add constraint FK_Patient_Care_Providers foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
go

alter table ADMINISTRATIVE.PATIENT_COMMUNICATION
   add constraint FK_Patient_Communications foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
go

alter table ADMINISTRATIVE.PATIENT_CONTACT
   add constraint FK_Patient_Contacts foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
go

alter table ADMINISTRATIVE.PATIENT_CONTACT_RELATIONSHIP
   add constraint FK_Patient_Contact_Relationships foreign key (PatientContactId)
      references ADMINISTRATIVE.PATIENT_CONTACT (PatientContactId)
go

alter table ADMINISTRATIVE.PATIENT_CONTACT_TELECOM
   add constraint FK_Patient_Contact_Telecoms foreign key (PatientContactId)
      references ADMINISTRATIVE.PATIENT_CONTACT (PatientContactId)
go

alter table ADMINISTRATIVE.PATIENT_IDENTIFIER
   add constraint FK_Patient_Identifiers foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
go

alter table ADMINISTRATIVE.PATIENT_LINK
   add constraint FK_Patient_Links foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
go

alter table ADMINISTRATIVE.PATIENT_NAME
   add constraint FK_Patient_Names foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
go

alter table ADMINISTRATIVE.PATIENT_PHOTO
   add constraint FK_Patient_Photos foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
go

alter table ADMINISTRATIVE.PATIENT_RACE
   add constraint FK_Patient_Races foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
go

alter table ADMINISTRATIVE.PATIENT_TELECOM
   add constraint FK_Patient_Telecoms foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
go

