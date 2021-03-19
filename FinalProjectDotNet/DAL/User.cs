using FinalProjectDotNet.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDotNet.DAL
{
    public class User : BaseNotifyPropertyChanged
    {
        int id;
        string login;
        string name;
        string lastname;
        decimal walletAmount;
        public int Id 
        {
            get => id;
            set
            {
                id = value;
                Notify();
            }
        }
        public string Login 
        {
            get => login;
            set
            {
                login = value;
                Notify();
            }
        }
        public string Name {
            get => name;
            set
            {
                name = value;
                Notify();
            }
        }
        public string Lastname {
            get => lastname;
            set
            {
                lastname = value;
                Notify();
            }
        }
        public decimal WalletAmount {
            get => walletAmount;
            set
            {
                walletAmount = value;
                Notify();
            }
        }
    }
}
