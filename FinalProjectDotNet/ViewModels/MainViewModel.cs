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
        User currentUser;
        public User CurrentUser { 
            get => currentUser;
            set
            {
                currentUser = value;
                Notify();
            }
        }
        public MainViewModel()
        {
            CurrentUser = null;
        }

    }
}
