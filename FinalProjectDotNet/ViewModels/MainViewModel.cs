using FinalProjectDotNet.DAL;
using FinalProjectDotNet.Infrastructure;
using FinalProjectDotNet.Views.MainViewChild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FinalProjectDotNet.ViewModels
{
    public class MainViewModel : BaseNotifyPropertyChanged
    {
        #region Commands
        public ICommand AppCommand { get; set; }
        #endregion



        string login;
        UserControl curentView;
        User currentUser;

        public string Login { get => login;
            set
            {
                login = value;
                Notify();
            }
        }
        public UserControl CurentView { 
            get => curentView;
            set
            {
                curentView = value;
                Notify();
            }
        }
        User CurrentUser { 
            get => currentUser;
            set
            {
                currentUser = value;
                Notify();
            }
        }
        public MainViewModel()
        {
            InitCommands();
            CurentView = new Autentification();
            Login = "Test";
        }

        private void InitCommands()
        {
            AppCommand = new RelayCommand(x =>
            {
                using(UsersContext db = new UsersContext())
                {
                    var user = from b in db.User where b.Login == Login select b;
                    if (user.FirstOrDefault() != null && user.FirstOrDefault().Login == Login)
                    {
                        CurrentUser = user.FirstOrDefault();
                        CurentView = new MainApp();
                        MessageBox.Show(CurrentUser.WalletAmount.ToString());
                    }
                }
            });
        }
    }
}
