using CharityEvents.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event_Band>().HasKey(eb => new
            {
                eb.EventId,
                eb.BandId
            });

            //join model in c#
            modelBuilder.Entity<Event_Band>().HasOne(b => b.Band).WithMany(eb => eb.Events_Bands).HasForeignKey(b => b.BandId);//def band side
            modelBuilder.Entity<Event_Band>().HasOne(b => b.Event).WithMany(eb => eb.Events_Bands).HasForeignKey(b => b.EventId);//def event side



            base.OnModelCreating(modelBuilder);//generate def auth
        }

        //define table names for each model
        public DbSet<Event> Events { get; set; }

        public DbSet<Event_Band> Events_Bands { get; set; }

        public DbSet<Band> Bands { get; set; }

        public DbSet<CharityCause> CharityCauses { get; set; }

        //orders table
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
