﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class DotNetCoreExampleDB : DbContext
    {
        public DotNetCoreExampleDB(DbContextOptions<DotNetCoreExampleDB> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //burası app settings te saklanmalı.
            optionsBuilder.UseSqlServer(
                "Data Source = localhost;Initial Catalog=DotNetCoreExampleDB;Integrated Security=true;TrustServerCertificate=True");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Meet> Meets { get; set; }
        public DbSet<MeetUser> MeetUser { get; set; }

        //entityler modellenirken FluentApi kullanıldı.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<MeetUser>()
                .HasKey(mu => new { mu.MeetId, mu.UserId });

            modelBuilder.Entity<MeetUser>()
                .HasOne(mu => mu.Meet)
                .WithMany(m => m.MeetUsers)
                .HasForeignKey(mu => mu.MeetId);

            modelBuilder.Entity<MeetUser>()
                .HasOne(mu => mu.User)
                .WithMany(u => u.MeetUsers)
                .HasForeignKey(mu => mu.UserId);
            modelBuilder.Entity<Meet>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Document>()
                .HasOne(d => d.Meet)
                .WithMany(m => m.Documents)
                .HasForeignKey(d => d.MeetId);
        }
    }
}
