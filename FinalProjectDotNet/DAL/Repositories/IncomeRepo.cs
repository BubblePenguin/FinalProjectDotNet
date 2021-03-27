using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDotNet.DAL.Repositories
{
    class IncomeRepo : GenericRpository<Income>
    {
        public IncomeRepo(DbContext context) : base(context)
        {
        }
    }
}
