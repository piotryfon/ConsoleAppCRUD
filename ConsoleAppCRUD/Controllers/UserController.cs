using ConsoleAppCRUD.Context;
using ConsoleAppCRUD.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCRUD.Controllers
{
    class UserController
    {
        private readonly ApplicationDbContext _dbContext;
        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(User user)
        {
            var insertedUser = _dbContext.Add(user);
            if (insertedUser != null)
                _dbContext.SaveChanges();
        }
    }
}
