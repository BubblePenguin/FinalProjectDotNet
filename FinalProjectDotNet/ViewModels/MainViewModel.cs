using FinalProjectDotNet.DAL;
using FinalProjectDotNet.DAL.Repositories;
using FinalProjectDotNet.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace FinalProjectDotNet.ViewModels
{
    public class MainViewModel : BaseNotifyPropertyChanged, IDisposable
    {
        public ICommand AddIncome { get; set; }
        public ICommand AddExpence { get; set; }
        

        User currentUser;
        decimal cash;

        DateTime selecteddatetime = DateTime.Now;
        IncomeType selectedincometype;
        ExpencesType selectedexpencestype;
        decimal selectedcash = 0;


        ObservableCollection<Expences> expences;
        ObservableCollection<Income> income;


        private UsersContext context;
        private IRepository<Expences> expRepo;
        private IRepository<ExpencesType> expTypesRepo;
        private IRepository<Income> incRepo;
        private IRepository<IncomeType> incTypesRepo;
        private IRepository<User> userRepo;


        public MainViewModel()
        {
            InitCommands();

            context = new UsersContext();
            expRepo = new ExpencesRepo(context);
            expTypesRepo = new ExpTypeRepo(context);
            incRepo = new IncomeRepo(context);
            incTypesRepo = new IncTypeRepo(context);
            userRepo = new UserRepo(context);

            Expences = new ObservableCollection<Expences>(expRepo.GetAll().OrderBy(x => x.Date));
            Income = new ObservableCollection<Income>(incRepo.GetAll().OrderBy(x => x.Date));
            ExpTypes = new ObservableCollection<ExpencesType>(expTypesRepo.GetAll());
            IncTypes = new ObservableCollection<IncomeType>(incTypesRepo.GetAll());
            Users = new ObservableCollection<User>(userRepo.GetAll());



            AllIncome = new ObservableCollection<Income>();
            DayIncome = new ObservableCollection<Income>();
            WeekIncome = new ObservableCollection<Income>();
            MonthIncome = new ObservableCollection<Income>();
            YearIncome = new ObservableCollection<Income>();

            AllExpences = new ObservableCollection<Expences>();
            DayExpences = new ObservableCollection<Expences>();
            WeekExpences = new ObservableCollection<Expences>();
            MonthExpences = new ObservableCollection<Expences>();
            YearExpences = new ObservableCollection<Expences>();
        }

        public User Login(string login) => context.User.Where(x => x.Login == login).Single();
        public void AddUser(string login, decimal cash)
        {
            context.User.Add(new User { Login = login, WalletAmount = cash });
            context.SaveChanges();
        }



        

        public ObservableCollection<ExpencesType> ExpTypes { get; set; }
        public ObservableCollection<IncomeType> IncTypes { get; set; }
        public ObservableCollection<User> Users { get; set; }


        ObservableCollection<Income> allincome;
        ObservableCollection<Income> dayincome;
        ObservableCollection<Income> weekincome;
        ObservableCollection<Income> monthincome;
        ObservableCollection<Income> yearincome;

        public ObservableCollection<Income> AllIncome
        {
            get => allincome;
            set
            {
                allincome = value;
                Notify();
            }
        }
        public ObservableCollection<Income> DayIncome 
        {
            get => dayincome;
            set
            {
                dayincome = value;
                Notify();
            }
        }
        public ObservableCollection<Income> WeekIncome
        {
            get => weekincome;
            set
            {
                weekincome = value;
                Notify();
            }
        }
        public ObservableCollection<Income> MonthIncome
        {
            get => monthincome;
            set
            {
                monthincome = value;
                Notify();
            }
        }
        public ObservableCollection<Income> YearIncome
        {
            get => yearincome;
            set
            {
                yearincome = value;
                Notify();
            }
        }


        ObservableCollection<Expences> allexpences;
        ObservableCollection<Expences> dayexpences;
        ObservableCollection<Expences> weekexpences;
        ObservableCollection<Expences> monthexpences;
        ObservableCollection<Expences> yearexpences;

        public ObservableCollection<Expences> AllExpences
        {
            get => allexpences;
            set
            {
                allexpences = value;
                Notify();
            }
        }
        public ObservableCollection<Expences> DayExpences
        {
            get => dayexpences;
            set
            {
                dayexpences = value;
                Notify();
            }
        }
        public ObservableCollection<Expences> WeekExpences
        {
            get => weekexpences;
            set
            {
                weekexpences = value;
                Notify();
            }
        }
        public ObservableCollection<Expences> MonthExpences
        {
            get => monthexpences;
            set
            {
                monthexpences = value;
                Notify();
            }
        }
        public ObservableCollection<Expences> YearExpences
        {
            get => yearexpences;
            set
            {
                yearexpences = value;
                Notify();
            }
        }


        public User CurrentUser
        {
            get => currentUser;
            set
            {
                currentUser = value;
                Cash = CurrentUser.WalletAmount;
                init();
                Notify();
            }
        }

        public decimal Cash
        {
            get => cash;
            set
            {
                cash = value;
                CurrentUser.WalletAmount = value;
                context.SaveChanges();
                Notify();
            }
        }


        public DateTime SelectedDateTime
        {
            get => selecteddatetime;
            set
            {
                selecteddatetime = value;
                Notify();
            }
        }
        public IncomeType SelectedIncomeType
        {
            get => selectedincometype;
            set
            {
                selectedincometype = value;
                Notify();
            }

        }
        public ExpencesType SelectedExpencesType
        {
            get => selectedexpencestype;
            set
            {
                selectedexpencestype = value;
                Notify();
            }

        }
        public decimal SelectedCash
        {
            get => selectedcash;
            set
            {
                selectedcash = value;
                Notify();
            }
        }




        public ObservableCollection<Expences> Expences
        {
            get => expences;
            set
            {
                expences = value;
                init();
                Notify();
            }
        }
        public ObservableCollection<Income> Income
        {
            get => income;
            set
            {
                income = value;
                init();
                Notify();
            }
        }







        void init()
        {
            if (Expences != null && CurrentUser != null)
            {
                AllExpences = new ObservableCollection<Expences>();
                DayExpences = new ObservableCollection<Expences>();
                WeekExpences = new ObservableCollection<Expences>();
                MonthExpences = new ObservableCollection<Expences>();
                YearExpences = new ObservableCollection<Expences>();

                foreach (var i in Expences)
                    if (i.User.Id == CurrentUser.Id)
                        AllExpences.Add(i);
                foreach (var i in Expences)
                    if (i.User.Id == CurrentUser.Id && i.Date.Date == DateTime.Now.Date)
                        DayExpences.Add(i);
                foreach (var i in Expences)
                    if (i.User.Id == CurrentUser.Id && (i.Date.Date <= DateTime.Now.Date && i.Date.Date >= DateTime.Now.AddDays(-7)))
                        WeekExpences.Add(i);
                foreach (var i in Expences)
                    if (i.User.Id == CurrentUser.Id && (i.Date.Date <= DateTime.Now.Date && i.Date.Date >= DateTime.Now.AddMonths(-1)))
                        MonthExpences.Add(i);
                foreach (var i in Expences)
                    if (i.User.Id == CurrentUser.Id && (i.Date.Date <= DateTime.Now.Date && i.Date.Date >= DateTime.Now.AddYears(-1)))
                        YearExpences.Add(i);
            }

            if (Income != null && CurrentUser != null)
            {
                AllIncome = new ObservableCollection<Income>();
                DayIncome = new ObservableCollection<Income>();
                WeekIncome = new ObservableCollection<Income>();
                MonthIncome = new ObservableCollection<Income>();
                YearIncome = new ObservableCollection<Income>();

                foreach (var i in Income)
                {
                    if (i.User.Id == CurrentUser.Id)
                        AllIncome.Add(i);
                    if (i.User.Id == CurrentUser.Id && i.Date.Date == DateTime.Now.Date)
                        DayIncome.Add(i);
                    if (i.User.Id == CurrentUser.Id && (i.Date.Date <= DateTime.Now.Date && i.Date.Date >= DateTime.Now.AddDays(-7)))
                        WeekIncome.Add(i);
                    if (i.User.Id == CurrentUser.Id && (i.Date.Date <= DateTime.Now.Date && i.Date.Date >= DateTime.Now.AddMonths(-1)))
                        MonthIncome.Add(i);
                    if (i.User.Id == CurrentUser.Id && (i.Date.Date <= DateTime.Now.Date && i.Date.Date >= DateTime.Now.AddYears(-1)))
                        YearIncome.Add(i);
                }
            }
        }

        private void InitCommands()
        {
            AddIncome = new RelayCommand(x =>
            {
                context.Income.Add(new Income { Date = SelectedDateTime, User = CurrentUser, Sum = SelectedCash, Type = SelectedIncomeType });
                Cash += SelectedCash;
                context.SaveChanges();
                Income = new ObservableCollection<Income>(incRepo.GetAll().OrderBy(y => y.Date));
                SelectedCash = 0;
                SelectedIncomeType = null;
                init();
            });

            AddExpence = new RelayCommand(x =>
            {
                context.Expences.Add(new Expences { Date = SelectedDateTime, User = CurrentUser, Sum = SelectedCash, Type = SelectedExpencesType });
                Cash -= SelectedCash;
                context.SaveChanges();
                Expences = new ObservableCollection<Expences>(expRepo.GetAll().OrderBy(y => y.Date));
                SelectedCash = 0;
                SelectedExpencesType = null;
                init();
            });

        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}