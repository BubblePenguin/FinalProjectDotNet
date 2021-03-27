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
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }

        public decimal WalletAmount { get; set; } = 0;
    }
}
