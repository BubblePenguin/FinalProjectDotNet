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

            List<Expences> expences = new List<Expences>
            {
                new Expences { Date = DateTime.Now, Sum = 340, Type = expencesTypes[0], User = test },
                new Expences { Date = DateTime.Now, Sum = 403, Type = expencesTypes[1], User = test },
                new Expences { Date = DateTime.Now, Sum = 034, Type = expencesTypes[2], User = test },
                new Expences { Date = DateTime.Now, Sum = 340, Type = expencesTypes[3], User = test },
                new Expences { Date = DateTime.Now.AddDays(-7), Sum = 340, Type = expencesTypes[0], User = test },
                new Expences { Date = DateTime.Now.AddDays(-6), Sum = 403, Type = expencesTypes[1], User = test },
                new Expences { Date = DateTime.Now.AddDays(-6), Sum = 034, Type = expencesTypes[2], User = test },
                new Expences { Date = DateTime.Now.AddDays(-6), Sum = 340, Type = expencesTypes[3], User = test },
                new Expences { Date = DateTime.Now.AddDays(-20), Sum = 340, Type = expencesTypes[0], User = test },
                new Expences { Date = DateTime.Now.AddDays(-15), Sum = 403, Type = expencesTypes[1], User = test },
                new Expences { Date = DateTime.Now.AddDays(-17), Sum = 034, Type = expencesTypes[2], User = test },
                new Expences { Date = DateTime.Now.AddDays(-25), Sum = 340, Type = expencesTypes[3], User = test },
                new Expences { Date = DateTime.Now.AddDays(-54), Sum = 340, Type = expencesTypes[0], User = test },
                new Expences { Date = DateTime.Now.AddDays(-123), Sum = 403, Type = expencesTypes[1], User = test },
                new Expences { Date = DateTime.Now.AddDays(-127), Sum = 034, Type = expencesTypes[2], User = test },
                new Expences { Date = DateTime.Now.AddDays(-299), Sum = 340, Type = expencesTypes[3], User = test },
                new Expences { Date = DateTime.Now.AddDays(-5000), Sum = 340, Type = expencesTypes[0], User = test },
                new Expences { Date = DateTime.Now.AddDays(-7653), Sum = 403, Type = expencesTypes[1], User = test },
                new Expences { Date = DateTime.Now.AddDays(-5432), Sum = 034, Type = expencesTypes[2], User = test },
                new Expences { Date = DateTime.Now.AddDays(-543), Sum = 340, Type = expencesTypes[3], User = test }
            };

            List<Income> income = new List<Income>
            {
                new Income { Date = DateTime.Now, Sum = 340, Type = incomeTypes[0], User = test },
                new Income { Date = DateTime.Now, Sum = 403, Type = incomeTypes[1], User = test },
                new Income { Date = DateTime.Now, Sum = 034, Type = incomeTypes[2], User = test },
                new Income { Date = DateTime.Now.AddDays(-7), Sum = 340, Type = incomeTypes[0], User = test },
                new Income { Date = DateTime.Now.AddDays(-6), Sum = 403, Type = incomeTypes[1], User = test },
                new Income { Date = DateTime.Now.AddDays(-6), Sum = 034, Type = incomeTypes[2], User = test },
                new Income { Date = DateTime.Now.AddDays(-15), Sum = 340, Type = incomeTypes[0], User = test },
                new Income { Date = DateTime.Now.AddDays(-31), Sum = 403, Type = incomeTypes[1], User = test },
                new Income { Date = DateTime.Now.AddDays(-16), Sum = 034, Type = incomeTypes[2], User = test },
                new Income { Date = DateTime.Now.AddDays(-45), Sum = 340, Type = incomeTypes[0], User = test },
                new Income { Date = DateTime.Now.AddDays(-56), Sum = 403, Type = incomeTypes[1], User = test },
                new Income { Date = DateTime.Now.AddDays(-105), Sum = 034, Type = incomeTypes[2], User = test },
                new Income { Date = DateTime.Now.AddDays(-400), Sum = 340, Type = incomeTypes[0], User = test },
                new Income { Date = DateTime.Now.AddDays(-600), Sum = 403, Type = incomeTypes[1], User = test },
                new Income { Date = DateTime.Now.AddDays(-700), Sum = 034, Type = incomeTypes[2], User = test }
            };

            context.User.Add(test);
            context.ExpencesType.AddRange(expencesTypes);
            context.IncomeType.AddRange(incomeTypes);
            context.Expences.AddRange(expences);
            context.Income.AddRange(income);
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
