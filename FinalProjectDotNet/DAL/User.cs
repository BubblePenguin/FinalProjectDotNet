using FinalProjectDotNet.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDotNet.DAL
{
    public class User : BaseNotifyPropertyChanged
    {
        int id;
        string login;
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
        [Required]
        public string Login 
        {
            get => login;
            set
            {
                login = value;
                Notify();
            }
        }
        
        public decimal WalletAmount
        {
            get => walletAmount;
            set
            {
                walletAmount = value;
                Notify();
            }
        }
    }
}
