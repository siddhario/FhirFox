/*==============================================================*/
/* DBMS name:      Sybase SQL Anywhere 11                       */
/* Created on:     3/25/2015 3:51:46 PM                         */
/*==============================================================*/


if exists(select 1 from sys.sysforeignkey where role='FK_PATIENT__REFERENCE_PATIENT') then
    alter table PATIENT_ADDRESS
       delete foreign key FK_PATIENT__REFERENCE_PATIENT
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_PATIENT__REFERENCE_PATIENT') then
    alter table PATIENT_CARE_PROVIDERS
       delete foreign key FK_PATIENT__REFERENCE_PATIENT
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_PATIENT__REFERENCE_PATIENT') then
    alter table PATIENT_COMMUNICATION
       delete foreign key FK_PATIENT__REFERENCE_PATIENT
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_PATIENT__REFERENCE_PATIENT') then
    alter table PATIENT_CONTACT
       delete foreign key FK_PATIENT__REFERENCE_PATIENT
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_PATIENT__REFERENCE_PATIENT_') then
    alter table PATIENT_CONTACT_RELATIONSHIP
       delete foreign key FK_PATIENT__REFERENCE_PATIENT_
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_PATIENT__REFERENCE_PATIENT_') then
    alter table PATIENT_CONTACT_TELECOM
       delete foreign key FK_PATIENT__REFERENCE_PATIENT_
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_PATIENT__REFERENCE_PATIENT') then
    alter table PATIENT_IDENTIFIER
       delete foreign key FK_PATIENT__REFERENCE_PATIENT
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_PATIENT__REFERENCE_PATIENT') then
    alter table PATIENT_LINK
       delete foreign key FK_PATIENT__REFERENCE_PATIENT
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_PATIENT__REFERENCE_PATIENT') then
    alter table PATIENT_NAME
       delete foreign key FK_PATIENT__REFERENCE_PATIENT
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_PATIENT__REFERENCE_PATIENT') then
    alter table PATIENT_PHOTO
       delete foreign key FK_PATIENT__REFERENCE_PATIENT
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_PATIENT__REFERENCE_PATIENT') then
    alter table PATIENT_RACE
       delete foreign key FK_PATIENT__REFERENCE_PATIENT
end if;

if exists(select 1 from sys.sysforeignkey where role='FK_PATIENT__REFERENCE_PATIENT') then
    alter table PATIENT_TELECOM
       delete foreign key FK_PATIENT__REFERENCE_PATIENT
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table PATIENT
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_ADDRESS'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table PATIENT_ADDRESS
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_CARE_PROVIDERS'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table PATIENT_CARE_PROVIDERS
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_COMMUNICATION'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table PATIENT_COMMUNICATION
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_CONTACT'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table PATIENT_CONTACT
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_CONTACT_RELATIONSHIP'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table PATIENT_CONTACT_RELATIONSHIP
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_CONTACT_TELECOM'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table PATIENT_CONTACT_TELECOM
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_IDENTIFIER'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table PATIENT_IDENTIFIER
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_LINK'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table PATIENT_LINK
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_NAME'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table PATIENT_NAME
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_PHOTO'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table PATIENT_PHOTO
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_RACE'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table PATIENT_RACE
end if;

if exists(
   select 1 from sys.systable 
   where table_name='PATIENT_TELECOM'
     and table_type in ('BASE', 'GBL TEMP')
) then
    drop table PATIENT_TELECOM
end if;

/*==============================================================*/
/* Table: PATIENT                                               */
/*==============================================================*/
create table PATIENT 
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
create table PATIENT_ADDRESS 
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
create table PATIENT_CARE_PROVIDERS 
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
create table PATIENT_COMMUNICATION 
(
   PatientCommunicationId int                            not null,
   PatientId            varchar(64)                    not null,
   Code                 varchar(50)                    not null,
   Text                 varchar(max)                   null,
   constraint PK_PATIENT_COMMUNICATION primary key clustered (PatientCommunicationId)
);

comment on column PATIENT_COMMUNICATION.Code is 
'http://tools.ietf.org/html/bcp47';

/*==============================================================*/
/* Table: PATIENT_CONTACT                                       */
/*==============================================================*/
create table PATIENT_CONTACT 
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
create table PATIENT_CONTACT_RELATIONSHIP 
(
   PatientContactRelationshipId int                            not null,
   PatientContactId     int                            not null,
   Code                 varchar(50)                    not null,
   Text                 varchar(max)                   null,
   constraint PK_PATIENT_CONTACT_RELATIONSHI primary key clustered (PatientContactRelationshipId)
);

comment on column PATIENT_CONTACT_RELATIONSHIP.Code is 
'V3 - 2.16.840.1.113883.5.111';

/*==============================================================*/
/* Table: PATIENT_CONTACT_TELECOM                               */
/*==============================================================*/
create table PATIENT_CONTACT_TELECOM 
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
create table PATIENT_IDENTIFIER 
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
create table PATIENT_LINK 
(
   PatientLinkId        int                            not null,
   PatientId            varchar(64)                    not null,
   Other                varchar(64)                    not null,
   Type                 varchar(7)                     not null,
   constraint PK_PATIENT_LINK primary key clustered (PatientLinkId)
);

comment on column PATIENT_LINK.Type is 
'http://hl7.org/fhir/link-type';

/*==============================================================*/
/* Table: PATIENT_NAME                                          */
/*==============================================================*/
create table PATIENT_NAME 
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
create table PATIENT_PHOTO 
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

comment on column PATIENT_PHOTO.ContentType is 
'http://www.rfc-editor.org/bcp/bcp13.txt';

comment on column PATIENT_PHOTO.Language is 
'http://tools.ietf.org/html/bcp47';

/*==============================================================*/
/* Table: PATIENT_RACE                                          */
/*==============================================================*/
create table PATIENT_RACE 
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
create table PATIENT_TELECOM 
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

alter table PATIENT_ADDRESS
   add constraint FK_PATIENT__REFERENCE_PATIENT foreign key (PatientId)
      references PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table PATIENT_CARE_PROVIDERS
   add constraint FK_PATIENT__REFERENCE_PATIENT foreign key (PatientId)
      references PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table PATIENT_COMMUNICATION
   add constraint FK_PATIENT__REFERENCE_PATIENT foreign key (PatientId)
      references PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table PATIENT_CONTACT
   add constraint FK_PATIENT__REFERENCE_PATIENT foreign key (PatientId)
      references PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table PATIENT_CONTACT_RELATIONSHIP
   add constraint FK_PATIENT__REFERENCE_PATIENT_ foreign key (PatientContactId)
      references PATIENT_CONTACT (PatientContactId)
      on update restrict
      on delete restrict;

alter table PATIENT_CONTACT_TELECOM
   add constraint FK_PATIENT__REFERENCE_PATIENT_ foreign key (PatientContactId)
      references PATIENT_CONTACT (PatientContactId)
      on update restrict
      on delete restrict;

alter table PATIENT_IDENTIFIER
   add constraint FK_PATIENT__REFERENCE_PATIENT foreign key (PatientId)
      references PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table PATIENT_LINK
   add constraint FK_PATIENT__REFERENCE_PATIENT foreign key (PatientId)
      references PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table PATIENT_NAME
   add constraint FK_PATIENT__REFERENCE_PATIENT foreign key (PatientId)
      references PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table PATIENT_PHOTO
   add constraint FK_PATIENT__REFERENCE_PATIENT foreign key (PatientId)
      references PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table PATIENT_RACE
   add constraint FK_PATIENT__REFERENCE_PATIENT foreign key (PatientId)
      references PATIENT (PatientId)
      on update restrict
      on delete restrict;

alter table PATIENT_TELECOM
   add constraint FK_PATIENT__REFERENCE_PATIENT foreign key (PatientId)
      references PATIENT (PatientId)
      on update restrict
      on delete restrict;

