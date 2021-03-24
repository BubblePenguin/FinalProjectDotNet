using FinalProjectDotNet.Infrastructure;
using FinalProjectDotNet.Models;
using FinalProjectDotNet.Views.MainViewChild;
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
        public MainViewModel()
        {
            MainModel = new MainModel();
            //temp = MainModel.GetIncTypes();
        }

        private MainModel MainModel { get; set; }

        public void ChangeUserById(int id)
        {
            MainModel.ChangeUserById(id);
        }

        //Dictionary<int, string> temp;

        //public CollectionView Temp
        //{

        //}

    }
}