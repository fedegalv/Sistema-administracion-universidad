using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Data.Models;

namespace Universidad.Data.Services
{
    public class SqlUserData
    {
        private readonly UserDbContext db;

        public SqlUserData()
        {
            db = new UserDbContext();
        }

        public User FindUser(User user)
        {
            var userDetails = db.user.Where(x => x.Dni == user.Dni && x.Legajo == user.Legajo && x.EsAdmin == user.EsAdmin).FirstOrDefault();
            return userDetails;
        }
    }
}
