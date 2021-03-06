﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using NailsApp.Data.MigrationNails;
using NailsApp.Data.Models;

namespace NailsApp.Data.DAL
{
    public class AppNailsDbContext: DbContext
    {
        public AppNailsDbContext() : base("name=DefaultConnection")
        {
        }

        public AppNailsDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppNailsDbContext, Configuration>());
        }

        public DbSet<City> Citys { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<NailsService> NailsServices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
