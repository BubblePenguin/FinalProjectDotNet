using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDotNet.DAL.Repositories
{
    class ExpTypeRepo : GenericRpository<ExpencesType>
    {
        public ExpTypeRepo(DbContext context) : base(context)
        {
        }
    }
}
