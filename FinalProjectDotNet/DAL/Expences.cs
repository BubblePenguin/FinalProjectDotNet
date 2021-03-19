using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDotNet.DAL
{
    class Expences
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        //public int TypeId { get; set; }
        public ExpencesType Type { get; set; }
    }
}
