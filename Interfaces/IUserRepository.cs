using MyULibrary_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyULibrary_API.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> createUser(User user);
        Task<User> updateUser(User user);
        Task<User> deleteUser(int id);
    }
}
