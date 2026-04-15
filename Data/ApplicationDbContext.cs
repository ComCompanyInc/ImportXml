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
    }
}
