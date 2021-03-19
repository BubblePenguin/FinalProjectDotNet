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
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        decimal walletAmount;
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
