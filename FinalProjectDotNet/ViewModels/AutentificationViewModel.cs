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
        private void InitCommands()
        {
            AutentificationCommand = new RelayCommand(x =>
            {
                User user = MainViewModel.Login(Login);
                if (user != null)
                {
                    MainViewModel.CurrentUser = user;
                    CurentView = new MainApp();
                }
            });

            RegistrationCommand = new RelayCommand(x =>
            {
                MainViewModel.AddUser(Login, Cash);
                User user = MainViewModel.Login(Login);
                if (user != null)
                {
                    MainViewModel.CurrentUser = user;
                    CurentView = new MainApp();
                }
            });

        }
        #endregion

        public string Login { get; set; }
        public decimal Cash { get; set; }
        public MainViewModel MainViewModel { get; set; }

        public AutentificationViewModel()
        {
            CurentView = new Autentification();
            MainViewModel = new MainViewModel();
            InitCommands();
            Login = "Test";
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
    }
}
