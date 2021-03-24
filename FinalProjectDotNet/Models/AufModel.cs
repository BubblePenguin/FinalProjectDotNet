using FinalProjectDotNet.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDotNet.Models
{
    class AufModel
    {
        static public int Auf(string login)
        {
            int userid = -1;
            using (UsersContext db = new UsersContext())
            {
                var user = from b in db.User where b.Login == login select b;
                if (user.FirstOrDefault() != null && user.FirstOrDefault().Login == login)
                {
                    userid = user.FirstOrDefault().Id;
                }
            }

            return userid;
        }

        static public void Add(string login, decimal cash)
        {
            using (UsersContext db = new UsersContext())
            {
                db.User.Add(new User { Login = login, WalletAmount = cash });
                db.SaveChanges();
            }
        }
    }
}
