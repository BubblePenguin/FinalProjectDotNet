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
    public class MainViewModel : BaseNotifyPropertyChanged
    {
        #region Commands
        public ICommand AddIncome { get; set; }
        public ICommand AddExpence { get; set; }
        private void InitCommands()
        {
            AddIncome = new RelayCommand(x =>
            {
                
            });

            AddExpence = new RelayCommand(x =>
            {
                
            });

        }
        #endregion

        User currentUser;
        decimal cash;
        DateTime dateTime = DateTime.Now.Date;
        public IncomeType SelectedIncomeType;
        public ExpencesType SelectedExpencesType;
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
        public DateTime DateTime
        {
            get => dateTime;
            set
            {
                dateTime = value;
                Notify();
            }
        }

        public decimal Cash
        {
            get => cash;
            set
            {
                cash = value;
                Notify();
            }
        }


        private UsersContext context;
        private IRepository<Expences> expRepo;
        private IRepository<ExpencesType> expTypesRepo;
        private IRepository<Income> incRepo;
        private IRepository<IncomeType> incTypesRepo;
        private IRepository<User> userRepo;




        public ObservableCollection<Expences> Expences { get; set; }
        public ObservableCollection<Income> Income { get; set; }
        public ObservableCollection<ExpencesType> ExpTypes { get; set; }
        public ObservableCollection<IncomeType> IncTypes { get; set; }
        public ObservableCollection<User> Users { get; set; }




        public ObservableCollection<Income> AllIncome { get; set; }
        public ObservableCollection<Income> DayIncome { get; set; }
        public ObservableCollection<Income> WeekIncome { get; set; }
        public ObservableCollection<Income> MonthIncome { get; set; }
        public ObservableCollection<Income> YearIncome { get; set; }

        public ObservableCollection<Expences> AllExpences { get; set; }
        public ObservableCollection<Expences> DayExpences { get; set; }
        public ObservableCollection<Expences> WeekExpences { get; set; }
        public ObservableCollection<Expences> MonthExpences { get; set; }
        public ObservableCollection<Expences> YearExpences { get; set; }



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

        void init()
        {
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


            foreach (var i in Income)
                if (i.User.Id == CurrentUser.Id)
                    AllIncome.Add(i);
            foreach (var i in Income)
                if (i.User.Id == CurrentUser.Id && i.Date.Date == DateTime.Now.Date)
                    DayIncome.Add(i);
            foreach (var i in Income)
                if (i.User.Id == CurrentUser.Id && (i.Date.Date <= DateTime.Now.Date && i.Date.Date >= DateTime.Now.AddDays(-7)))
                    WeekIncome.Add(i);
            foreach (var i in Income)
                if (i.User.Id == CurrentUser.Id && (i.Date.Date <= DateTime.Now.Date && i.Date.Date >= DateTime.Now.AddMonths(-1)))
                    MonthIncome.Add(i);
            foreach (var i in Income)
                if (i.User.Id == CurrentUser.Id && (i.Date.Date <= DateTime.Now.Date && i.Date.Date >= DateTime.Now.AddYears(-1)))
                    YearIncome.Add(i);
        }
    }
}