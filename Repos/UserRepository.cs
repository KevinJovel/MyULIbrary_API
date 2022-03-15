using Microsoft.EntityFrameworkCore;
using MyULibrary_API.DTOs;
using MyULibrary_API.Interfaces;
using MyULibrary_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System;

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
            //cifrar contraseña
            SHA256Managed sha = new SHA256Managed();
            string pass = user.Password;
            byte[] dataNoEncrypted = Encoding.Default.GetBytes(pass);
            byte[] dataEncrypted = sha.ComputeHash(dataNoEncrypted);
            string keyEncrypted = BitConverter.ToString(dataEncrypted).Replace("-", "");
            user.Password = keyEncrypted;
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

        public async Task<User> login(string user, string pass)
        {
            SHA256Managed sha = new SHA256Managed();
            byte[] dataNoEncrypted = Encoding.Default.GetBytes(pass);
            byte[] dataEncrypted = sha.ComputeHash(dataNoEncrypted);
            string keyEncrypted = BitConverter.ToString(dataEncrypted).Replace("-", "");
            var logUser=  await _ctx.Users.Where(x => x.Password == keyEncrypted && x.UserName == user).FirstOrDefaultAsync();
            if (logUser != null) {
                return logUser;
            }
            else {
                return null;
            }
        }

        public async Task<User> updateUser(User user)
        {
            _ctx.Users.Update(user);
            await _ctx.SaveChangesAsync();
            return user;
        }
    }
}
