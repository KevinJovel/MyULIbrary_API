using Microsoft.EntityFrameworkCore;
using MyULibrary_API.Interfaces;
using MyULibrary_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyULibrary_API.Repos
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MyULibraryContext _ctx;


        public RoleRepository(MyULibraryContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Role> createRole(Role role)
        {
            await _ctx.Roles.AddAsync(role);
            await _ctx.SaveChangesAsync();
            return role;
        }

        public async Task<Role> deleteRole(int id)
        {
            Role role = await _ctx.Roles.Where(x => x.RoleId == id).FirstOrDefaultAsync();
            _ctx.Roles.Remove(role);
            await _ctx.SaveChangesAsync(true);
            return role;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _ctx.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _ctx.Roles.Where(x => x.RoleId == id).FirstOrDefaultAsync();
        }

        public async Task<Role> updateRole(Role role)
        {
            _ctx.Roles.Update(role);
            await _ctx.SaveChangesAsync();
            return role;
        }
    }
}
