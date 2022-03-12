using MyULibrary_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyULibrary_API.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRoles();
        Task<Role> GetRoleById(int id);
        Task<Role> createRole(Role role);
        Task<Role> updateRole(Role role);
        Task<Role> deleteRole(int id);
    }
}
