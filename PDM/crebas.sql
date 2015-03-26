/*==============================================================*/
/* DBMS name:      Sybase SQL Anywhere 11                       */
/* Created on:     3/26/2015 8:26:24 AM                         */
/*==============================================================*/


if exists(select 1 from sys.sysforeignkey where role='FK_Patient_Address') then
    alter table ADMINISTRATIVE.PATIENT_ADDRESS
       delete foreign key FK_Patient_Address
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_Patient_Care_Providers') then
    alter table ADMINISTRATIVE.PATIENT_CARE_PROVIDERS
       delete foreign key FK_Patient_Care_Providers
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_Patient_Communications') then
    alter table ADMINISTRATIVE.PATIENT_COMMUNICATION
       delete foreign key FK_Patient_Communications
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_Patient_Contacts') then
    alter table ADMINISTRATIVE.PATIENT_CONTACT
       delete foreign key FK_Patient_Contacts
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_Patient_Contact_Relationships') then
    alter table ADMINISTRATIVE.PATIENT_CONTACT_RELATIONSHIP
       delete foreign key FK_Patient_Contact_Relationships
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_Patient_Contact_Telecoms') then
    alter table ADMINISTRATIVE.PATIENT_CONTACT_TELECOM
       delete foreign key FK_Patient_Contact_Telecoms
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_Patient_Identifiers') then
    alter table ADMINISTRATIVE.PATIENT_IDENTIFIER
       delete foreign key FK_Patient_Identifiers
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_Patient_Links') then
    alter table ADMINISTRATIVE.PATIENT_LINK
       delete foreign key FK_Patient_Links
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_Patient_Names') then
    alter table ADMINISTRATIVE.PATIENT_NAME
       delete foreign key FK_Patient_Names
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_Patient_Photos') then
    alter table ADMINISTRATIVE.PATIENT_PHOTO
       delete foreign key FK_Patient_Photos
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_Patient_Races') then
    alter table ADMINISTRATIVE.PATIENT_RACE
       delete foreign key FK_Patient_Races
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_Patient_Telecoms') then
    alter table ADMINISTRATIVE.PATIENT_TELECOM
       delete foreign key FK_Patient_Telecoms
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT'
     and table_type in ('BASE', 'GBL TEMP')
     and creator=user_id('ADMINISTRATIVE')
) then
    drop table ADMINISTRATIVE.PATIENT
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_ADDRESS'
     and table_type in ('BASE', 'GBL TEMP')
     and creator=user_id('ADMINISTRATIVE')
) then
    drop table ADMINISTRATIVE.PATIENT_ADDRESS
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_CARE_PROVIDERS'
     and table_type in ('BASE', 'GBL TEMP')
     and creator=user_id('ADMINISTRATIVE')
) then
    drop table ADMINISTRATIVE.PATIENT_CARE_PROVIDERS
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_COMMUNICATION'
     and table_type in ('BASE', 'GBL TEMP')
     and creator=user_id('ADMINISTRATIVE')
) then
    drop table ADMINISTRATIVE.PATIENT_COMMUNICATION
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_CONTACT'
     and table_type in ('BASE', 'GBL TEMP')
     and creator=user_id('ADMINISTRATIVE')
) then
    drop table ADMINISTRATIVE.PATIENT_CONTACT
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_CONTACT_RELATIONSHIP'
     and table_type in ('BASE', 'GBL TEMP')
     and creator=user_id('ADMINISTRATIVE')
) then
    drop table ADMINISTRATIVE.PATIENT_CONTACT_RELATIONSHIP
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_CONTACT_TELECOM'
     and table_type in ('BASE', 'GBL TEMP')
     and creator=user_id('ADMINISTRATIVE')
) then
    drop table ADMINISTRATIVE.PATIENT_CONTACT_TELECOM
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_IDENTIFIER'
     and table_type in ('BASE', 'GBL TEMP')
     and creator=user_id('ADMINISTRATIVE')
) then
    drop table ADMINISTRATIVE.PATIENT_IDENTIFIER
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_LINK'
     and table_type in ('BASE', 'GBL TEMP')
     and creator=user_id('ADMINISTRATIVE')
) then
    drop table ADMINISTRATIVE.PATIENT_LINK
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_NAME'
     and table_type in ('BASE', 'GBL TEMP')
     and creator=user_id('ADMINISTRATIVE')
) then
    drop table ADMINISTRATIVE.PATIENT_NAME
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_PHOTO'
     and table_type in ('BASE', 'GBL TEMP')
     and creator=user_id('ADMINISTRATIVE')
) then
    drop table ADMINISTRATIVE.PATIENT_PHOTO
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_RACE'
     and table_type in ('BASE', 'GBL TEMP')
     and creator=user_id('ADMINISTRATIVE')
) then
    drop table ADMINISTRATIVE.PATIENT_RACE
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_TELECOM'
     and table_type in ('BASE', 'GBL TEMP')
     and creator=user_id('ADMINISTRATIVE')
) then
    drop table ADMINISTRATIVE.PATIENT_TELECOM
end if;

revoke connect from ADMINISTRATIVE;

/*==============================================================*/
/* User: ADMINISTRATIVE                                         */
/*==============================================================*/
grant connect to ADMINISTRATIVE identified by "";

/*==============================================================*/
/* Table: PATIENT                                               */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT 
(
   PatientId            varchar(64)                    not null,
   BirthDate            DateTime                       null,
   Deceased             bit                            null,
   DeceasedDateTime     datetime                       null,
   MaritalStatus        varchar(max)                   null,
   MultipleBirth        bit                            null,
   MultipleBirthOrder   int                            null,
   Active               bit                            null,
   MothersMaidenName    varchar(max)                   null,
   Ethnicity            varchar(max)                   null,
   Religion             varchar(max)                   null,
   Gender               varchar(7)                     null
      constraint CKC_GENDER_PATIENT check (Gender is null or (Gender in ('male','female','other','unknown'))),
   ManagingOrganizationId varchar(64)                    null,
   BirthPlaceAddressUse varchar(4)                     null,
   BirthPlaceAddressText varchar(max)                   null,
   BirthPlaceAddressLine varchar(max)                   null,
   BirthPlaceAddressCity varchar(max)                   null,
   BirthPlaceAddressState varchar(max)                   null,
   BirthPlaceAddressPostalCode varchar(max)                   null,
   BirthPlaceAddressCountry varchar(max)                   null,
   BirthPlaceAddressPeriodStart datetime                       null,
   BirthPlaceAddressPeriodEnd datetime                       null,
   constraint PK_PATIENT primary key clustered (PatientId)
);

/*==============================================================*/
/* Table: PATIENT_ADDRESS                                       */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_ADDRESS 
(
   PatientId            varchar(64)                    not null,
   PatientAddressId     int                            not null,
   Line                 varchar(max)                   not null,
   City                 varchar(max)                   not null,
   State                varchar(max)                   not null,
   PostalCode           varchar(max)                   not null,
   Country              varchar(max)                   not null,
   constraint PK_PATIENT_ADDRESS primary key clustered (PatientAddressId)
);

/*==============================================================*/
/* Table: PATIENT_CARE_PROVIDERS                                */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_CARE_PROVIDERS 
(
   PatientCareProviderId int                            not null,
   PatientId            varchar(64)                    not null,
   OrganizationId       varchar(max)                   null,
   PractitionerId       varchar(max)                   null,
   constraint PK_PATIENT_CARE_PROVIDERS primary key clustered (PatientCareProviderId)
);

/*==============================================================*/
/* Table: PATIENT_COMMUNICATION                                 */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_COMMUNICATION 
(
   PatientCommunicationId int                            not null,
   PatientId            varchar(64)                    not null,
   Code                 varchar(50)                    not null,
   Text                 varchar(max)                   null,
   constraint PK_PATIENT_COMMUNICATION primary key clustered (PatientCommunicationId)
);

comment on column ADMINISTRATIVE.PATIENT_COMMUNICATION.Code is 
'http://tools.ietf.org/html/bcp47';

/*==============================================================*/
/* Table: PATIENT_CONTACT                                       */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_CONTACT 
(
   PatientContactId     int                            not null,
   PatientId            varchar(64)                    not null,
   Gender               varchar(7)                     null,
   PeriodStart          datetime                       null,
   PeriodEnd            datetime                       null,
   NameUse              varchar(10)                    null,
   NameText             varchar(max)                   null,
   NameFamily           varchar(max)                   null,
   NameGiven            varchar(max)                   null,
   NamePrefix           varchar(max)                   null,
   NameSuffix           varchar(max)                   null,
   NamePeriodStart      varchar(max)                   null,
   NamePeriodEnd        varchar(max)                   null,
   AddressUse           varchar(4)                     null,
   AddressText          varchar(max)                   null,
   AddressLine          varchar(max)                   null,
   AddressCity          varchar(max)                   null,
   AddressState         varchar(max)                   null,
   AddressPostalCode    varchar(max)                   null,
   AddressCountry       varchar(max)                   null,
   AddressPeriodStart   datetime                       null,
   AddressPeriodEnd     datetime                       null,
   constraint PK_PATIENT_CONTACT primary key clustered (PatientContactId)
);

/*==============================================================*/
/* Table: PATIENT_CONTACT_RELATIONSHIP                          */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_CONTACT_RELATIONSHIP 
(
   PatientContactRelationshipId int                            not null,
   PatientContactId     int                            not null,
   Code                 varchar(50)                    not null,
   Text                 varchar(max)                   null,
   constraint PK_PATIENT_CONTACT_RELATIONSHI primary key clustered (PatientContactRelationshipId)
);

comment on column ADMINISTRATIVE.PATIENT_CONTACT_RELATIONSHIP.Code is 
'V3 - 2.16.840.1.113883.5.111';

/*==============================================================*/
/* Table: PATIENT_CONTACT_TELECOM                               */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_CONTACT_TELECOM 
(
   PatientContactId     int                            not null,
   PatientContactTelecomId int                            not null,
   System               varchar(5)                     null,
   Value                varchar(max)                   null,
   Use                  varchar(6)                     null,
   PeriodStart          datetime                       null,
   PeriodEnd            datetime                       null,
   constraint PK_PATIENT_CONTACT_TELECOM primary key clustered (PatientContactTelecomId)
);

/*==============================================================*/
/* Table: PATIENT_IDENTIFIER                                    */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_IDENTIFIER 
(
   PatientIdentifierId  int                            not null,
   PatientId            varchar(64)                    not null,
   System               varchar(max)                   not null,
   Value                varchar(max)                   not null,
   constraint PK_PATIENT_IDENTIFIER primary key clustered (PatientIdentifierId)
);

/*==============================================================*/
/* Table: PATIENT_LINK                                          */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_LINK 
(
   PatientLinkId        int                            not null,
   PatientId            varchar(64)                    not null,
   Other                varchar(64)                    not null,
   Type                 varchar(7)                     not null,
   constraint PK_PATIENT_LINK primary key clustered (PatientLinkId)
);

comment on column ADMINISTRATIVE.PATIENT_LINK.Type is 
'http://hl7.org/fhir/link-type';

/*==============================================================*/
/* Table: PATIENT_NAME                                          */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_NAME 
(
   PatientNameId        int                            not null,
   PatientId            varchar(64)                    not null,
   Use                  varchar(10)                    null
      constraint CKC_USE_PATIENT_ check (Use is null or (Use in ('usual','official','temp','nickname','anonymous','old','maiden'))),
   Text                 varchar(max)                   null,
   Family               varchar(max)                   null,
   Given                varchar(max)                   null,
   Prefix               varchar(max)                   null,
   Suffix               varchar(max)                   null,
   PeriodStart          datetime                       null,
   PeriodEnd            datetime                       null,
   constraint PK_PATIENT_NAME primary key clustered (PatientNameId)
);

/*==============================================================*/
/* Table: PATIENT_PHOTO                                         */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_PHOTO 
(
   PatientPhotoId       int                            not null,
   PatientId            varchar(64)                    null,
   ContentType          varchar(50)                    null,
   Language             varchar(30)                    null,
   Url                  varchar(max)                   null,
   Size                 int                            null,
   Data                 binary                         null,
   Hash                 binary                         null,
   constraint PK_PATIENT_PHOTO primary key clustered (PatientPhotoId)
);

comment on column ADMINISTRATIVE.PATIENT_PHOTO.ContentType is 
'http://www.rfc-editor.org/bcp/bcp13.txt';

comment on column ADMINISTRATIVE.PATIENT_PHOTO.Language is 
'http://tools.ietf.org/html/bcp47';

/*==============================================================*/
/* Table: PATIENT_RACE                                          */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_RACE 
(
   PatientRaceId        int                            not null,
   PatientId            varchar(64)                    not null,
   Code                 varchar(6)                     not null,
   Text                 varchar(max)                   null,
   constraint PK_PATIENT_RACE primary key clustered (PatientRaceId)
);

/*==============================================================*/
/* Table: PATIENT_TELECOM                                       */
/*==============================================================*/
create table ADMINISTRATIVE.PATIENT_TELECOM 
(
   PatientTelecomId     int                            not null,
   PatientId            varchar(64)                    not null,
   System               varchar(5)                     null,
   Value                varchar(max)                   null,
   Use                  varchar(6)                     null,
   PeriodStart          datetime                       null,
   PeriodEnd            datetime                       null,
   constraint PK_PATIENT_TELECOM primary key clustered (PatientTelecomId)
);

alter table ADMINISTRATIVE.PATIENT_ADDRESS
   add constraint FK_Patient_Address foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table ADMINISTRATIVE.PATIENT_CARE_PROVIDERS
   add constraint FK_Patient_Care_Providers foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table ADMINISTRATIVE.PATIENT_COMMUNICATION
   add constraint FK_Patient_Communications foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table ADMINISTRATIVE.PATIENT_CONTACT
   add constraint FK_Patient_Contacts foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table ADMINISTRATIVE.PATIENT_CONTACT_RELATIONSHIP
   add constraint FK_Patient_Contact_Relationships foreign key (PatientContactId)
      references ADMINISTRATIVE.PATIENT_CONTACT (PatientContactId)
      on update restrict
      on delete restrict;

alter table ADMINISTRATIVE.PATIENT_CONTACT_TELECOM
   add constraint FK_Patient_Contact_Telecoms foreign key (PatientContactId)
      references ADMINISTRATIVE.PATIENT_CONTACT (PatientContactId)
      on update restrict
      on delete restrict;

alter table ADMINISTRATIVE.PATIENT_IDENTIFIER
   add constraint FK_Patient_Identifiers foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table ADMINISTRATIVE.PATIENT_LINK
   add constraint FK_Patient_Links foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table ADMINISTRATIVE.PATIENT_NAME
   add constraint FK_Patient_Names foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table ADMINISTRATIVE.PATIENT_PHOTO
   add constraint FK_Patient_Photos foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table ADMINISTRATIVE.PATIENT_RACE
   add constraint FK_Patient_Races foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table ADMINISTRATIVE.PATIENT_TELECOM
   add constraint FK_Patient_Telecoms foreign key (PatientId)
      references ADMINISTRATIVE.PATIENT (PatientId)
      on update restrict
      on delete restrict;

