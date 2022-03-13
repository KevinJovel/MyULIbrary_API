using Microsoft.EntityFrameworkCore;
using MyULibrary_API.DTOs;
using MyULibrary_API.Interfaces;
using MyULibrary_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyULibrary_API.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly MyULibraryContext _ctx;


        public UserRepository(MyULibraryContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> createUser(User user)
        {
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task<User> deleteUser(int id)
        {
            User user = await _ctx.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
            _ctx.Users.Remove(user);
            await _ctx.SaveChangesAsync(true);
            return user;
        }

        public async Task<IEnumerable<UserDTo>> GetAllUsers()
        {
            List<UserDTo> lista = await (from user in _ctx.Users
                                         join role in _ctx.Roles
                                         on user.RoleId equals role.RoleId
                                         select new UserDTo
                                         {
                                             UserId = user.UserId,
                                             RoleId = role.RoleId,
                                             Email = user.Email,
                                             FirstName = user.FirstName,
                                             LastName = user.LastName,
                                             RoleName = role.RoleName,
                                         }).ToListAsync();
            return lista;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _ctx.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
        }

        public async Task<User> updateUser(User user)
        {
            _ctx.Users.Update(user);
            await _ctx.SaveChangesAsync();
            return user;
        }
    }
}
