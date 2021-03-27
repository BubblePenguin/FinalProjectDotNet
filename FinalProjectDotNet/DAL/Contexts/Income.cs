using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDotNet.DAL
{
    public class Income
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        //public int TypeId { get; set; }
        public IncomeType Type { get; set; }
    }
}
