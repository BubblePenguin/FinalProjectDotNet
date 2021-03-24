using FinalProjectDotNet.DAL;
using FinalProjectDotNet.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinalProjectDotNet.Models
{
    class MainModel : BaseNotifyPropertyChanged
    {
        public MainModel()
        {
            InitData();
        }
        public List<IncomeType> IncomeTypes { get; set; }
        public List<ExpencesType> ExpencesTypes { get; set; }
        //ObservableCollection<DateTime> dates { get; set; }

        User currentUser;
        User CurrentUser
        {
            get => currentUser;
            set
            {
                currentUser = value;
                //foreach (var i in ExpencesTypes)
                //    MessageBox.Show(i.Name + i.Id);
                Notify();
            }
        }

        void InitData()
        {
            CurrentUser = null;
            using (var db = new UsersContext())
            {
                IncomeTypes = db.IncomeType.ToList();
                ExpencesTypes = db.ExpencesType.ToList();
            }
        }
        public void ChangeUserById(int id)
        {
            using (UsersContext db = new UsersContext())
            {
                var user = from b in db.User where b.Id == id select b;
                if (user.FirstOrDefault() != null && user.FirstOrDefault().Id == id)
                    CurrentUser = user.FirstOrDefault();
            }
        }

        public Dictionary<int, string> GetIncTypes()
        {
            Dictionary<int, string> temp = new Dictionary<int, string>();

            foreach (var i in IncomeTypes)
                temp.Add(i.Id, i.Name);

            return temp;
        }
    }
}
