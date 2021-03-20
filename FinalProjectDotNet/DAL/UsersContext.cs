using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDotNet.DAL
{
    class MyInitializer : DropCreateDatabaseIfModelChanges<UsersContext>
    {
        protected override void Seed(UsersContext context)
        {
            base.Seed(context);

            User test = new User { Login = "Test", WalletAmount = 3000 };

            List<ExpencesType> expencesTypes = new List<ExpencesType>
            {
                new ExpencesType { Name = "Transport" },
                new ExpencesType { Name = "Gym" },
                new ExpencesType { Name = "Food" },
                new ExpencesType { Name = "Another" }
            };

            List<IncomeType> incomeTypes = new List<IncomeType>
            {
                new IncomeType { Name="Sallary" },
                new IncomeType { Name="Gift" },
                new IncomeType { Name="Another" }
            };

            context.User.Add(test);
            context.ExpencesType.AddRange(expencesTypes);
            context.IncomeType.AddRange(incomeTypes);
            context.SaveChanges();
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

            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<User>().HasKey(x => x.Id);
            //modelBuilder.Entity<User>().Property(x => x.Id)
            //    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            ////modelBuilder.Entity<User>().HasIndex(x => x.Login).IsUnique();

            //modelBuilder.Entity<Expences>().HasKey(x => x.Id);
            //modelBuilder.Entity<Expences>().Property(x => x.Id)
            //    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);


            //modelBuilder.Entity<Income>().HasKey(x => x.Id);
            //modelBuilder.Entity<Income>().Property(x => x.Id)
            //    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
