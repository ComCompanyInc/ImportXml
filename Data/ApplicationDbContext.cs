using BackendApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BaseData> BaseData { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<f031_ermo> F031_Ermos { get; set; }
        public DbSet<f032_trmo> F032_Trmos { get; set; }
        public DbSet<OrgDocument> OrgDocuments { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrgType> OrgTypes { get; set; }
        public DbSet<OspType> OspType { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<VidType> VidTypes { get; set; }
        public DbSet<OspType> OspTypes { get; set; }
        public DbSet<OidType> OidTypes { get; set; }
        public DbSet<f033_spmo> F033_Spmos { get; set; }
        public DbSet<f038_addrmp> F038_Addrmps { get; set; }
        public DbSet<OrgName> OrgNames { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<f037_licmo> F037_Licmos { get; set; }
        public DbSet<f019_PersAccOrg> f019_PersAccOrgs { get; set; }
        public DbSet<f002_smoEmp> F002_SmoEmps { get; set; }
        public DbSet<f002_InsInclude> InsIncludes { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<f002_smo_insAdvice> f002_smo_insAdvices { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<f005_StatOpl> F005_StatOpls { get; set; }
        public DbSet<ExpType> ExpTypes { get; set; }
        public DbSet<f006_VidExp> F006_VidExps { get; set; }
        public DbSet<VedomType> VedomType { get; set; }
        public DbSet<f007_Vedom> F007_Vedoms { get; set; }
        public DbSet<OmsType> OmsTypes { get; set; }
        public DbSet<f008_TipOms> F008_TipOms { get; set; }
        public DbSet<StatType> StatTypes { get; set; }
        public DbSet<f009_StatZl> F009_StatZls { get; set; }
        public DbSet<f010_Subecti> F010_Subects { get; set; }
    }
}
