using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDotNet.DAL
{
    class MyInitializer : CreateDatabaseIfNotExists<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            base.Seed(context);

        }
    }
    class UsersContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<Expences> Expences { get; set; }
        public DbSet<IncomeType> IncomeType { get; set; }
        public DbSet<ExpencesType> ExpencesType { get; set; }
        public UsersContext() : base("name=MoneyManagingDB") 
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists());
            Database.SetInitializer(new MyInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Expences>().HasKey(x => x.Id);
            modelBuilder.Entity<Expences>().Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);


            modelBuilder.Entity<Income>().HasKey(x => x.Id);
            modelBuilder.Entity<Income>().Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
