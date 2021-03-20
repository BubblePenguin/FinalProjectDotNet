using FinalProjectDotNet.DAL;
using FinalProjectDotNet.Infrastructure;
using FinalProjectDotNet.Views.MainViewChild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FinalProjectDotNet.ViewModels
{
    public class AutentificationViewModel : BaseNotifyPropertyChanged
    {
        #region Commands
        public ICommand AutentificationCommand { get; set; }
        public ICommand RegistrationCommand { get; set; }
        #endregion

        User currentUser;
        public User CurrentUser
        {
            get => currentUser;
            set
            {
                currentUser = value;
                Notify();
            }
        }
        string login;
        public string Login
        {
            get => login;
            set
            {
                login = value;
                Notify();
            }
        }
        decimal cash;
        public decimal Cash
        {
            get => cash;
            set
            {
                cash = value;
                Notify();
            }
        }

        public AutentificationViewModel()
        {
            CurentView = new Autentification();
            MainViewModel = new MainViewModel();
            InitCommands();
            Login = "Test";
        }

        MainViewModel mainviewmodel;
        public MainViewModel MainViewModel
        {
            get => mainviewmodel;
            set
            {
                mainviewmodel = value;
                Notify();
            }
        }
        UserControl curentView;
        public UserControl CurentView
        {
            get => curentView;
            set
            {
                curentView = value;
                Notify();
            }
        }

        private void InitCommands()
        {
            AutentificationCommand = new RelayCommand(x =>
            {
                using (UsersContext db = new UsersContext())
                {
                    var user = from b in db.User where b.Login == Login select b;
                    if (user.FirstOrDefault() != null && user.FirstOrDefault().Login == Login)
                    {
                        MainViewModel.CurrentUser = user.FirstOrDefault();
                        CurentView = new MainApp();
                    }
                }
            });

            RegistrationCommand = new RelayCommand(x =>
            {
                using (UsersContext db = new UsersContext())
                {
                    db.User.Add(new User { Login = Login, WalletAmount = Cash });
                    db.SaveChanges();

                    var user = from b in db.User where b.Login == Login select b;
                    if (user.FirstOrDefault() != null && user.FirstOrDefault().Login == Login)
                    {
                        MainViewModel.CurrentUser = user.FirstOrDefault();
                        CurentView = new MainApp();
                    }
                }
            });

        }
    }
}
