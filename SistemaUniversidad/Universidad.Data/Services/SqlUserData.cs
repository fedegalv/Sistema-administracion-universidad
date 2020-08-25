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
            var userDetails = db.Users.Where(x => x.dni == user.dni && x.legajo == user.legajo && x.is_admin == user.is_admin).FirstOrDefault();
            return userDetails;
        }
    }
}
