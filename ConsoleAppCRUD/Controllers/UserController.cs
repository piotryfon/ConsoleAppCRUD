using ConsoleAppCRUD.Entities;
using ConsoleAppCRUD.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleAppCRUD.Controllers
{
    class UserController
    {
        private readonly IService _service;

        public UserController(IService service)
        {
            _service = service;
        }

        public async Task AddUser(User user)
        {
           await _service.AddUser(user);
        }

        public async Task EditUser(int id, User modifiedUser)
        {
            await _service.EditUser(id, modifiedUser); 
        }

        public async Task DeleteUser(int id)
        {
            await _service.DeleteUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _service.GetAllUsers();
        }

        public async Task GetUserById(int id)
        {
            await _service.GetUserById(id);
        }
    }
}
