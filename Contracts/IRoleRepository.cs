using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace SMC_Contracts
{
    public interface IRoleRepository : IBaseRepo<IdentityRole>
    {
        Task<IdentityRole> GetById(string id);
    }
}