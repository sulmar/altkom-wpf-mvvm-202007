﻿using Altkom.WPFMVVM.DbServices.Configurations;
using Altkom.WPFMVVM.Fakers;
using Altkom.WPFMVVM.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.WPFMVVM.DbServices
{
    //public class MigrationsContextFactory : IDbContextFactory<MyContext>
    //{
    //    public MyContext Create()
    //    {
    //        return new MyContext("MyConnection", new MyInitializer();
    //    }
    //}

    // PM> Install-Package EntityFramework
    public class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Models.Action> Actions { get; set; }
        public DbSet<Models.Event> Events { get; set; }
        public DbSet<Models.Part> Parts { get; set; }

        public MyContext()
            : base("MyConnection")
        {
        }

        public MyContext(string connectionString, IDatabaseInitializer<MyContext> strategy)
            : base(connectionString)
        {
            System.Data.Entity.Database.SetInitializer(strategy);

            Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Fluent API
            //modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(50).IsRequired();
            //modelBuilder.Entity<Product>().Property(p => p.Color).HasMaxLength(50);
            //modelBuilder.Entity<Product>().Property(p => p.CMYKColor.C).HasColumnName("C");
            //modelBuilder.Entity<Product>().Property(p => p.CMYKColor.M).HasColumnName("M");
            //modelBuilder.Entity<Product>().Property(p => p.CMYKColor.Y).HasColumnName("Y");
            //modelBuilder.Entity<Product>().Property(p => p.CMYKColor.K).HasColumnName("K");

            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ActionConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new PartConfiguration());

            base.OnModelCreating(modelBuilder);
        }        
    }
}
