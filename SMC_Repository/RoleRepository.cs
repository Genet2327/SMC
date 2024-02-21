using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMC_Contracts;
using SMC_Entities;
using SMC_Entities.Paged;
using System.Threading.Tasks;

namespace SMC_Repository
{
    public class RoleRepository :  BaseRepo<IdentityRole> , IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleRepository(RoleManager<IdentityRole> roleManager, SmcContext smcContext) : base(smcContext)
        {
            _roleManager = roleManager;
        }
        public override PagedList<IdentityRole> GetAll(QueryStringParameters parameters)
        {
            return PagedList<IdentityRole>.ToPagedList(_roleManager.Roles.AsNoTracking(),
                parameters.PageNumber,
                parameters.PageSize);
        }

        public  override void Create(IdentityRole model)
        {
            _roleManager.CreateAsync(model);
        }

        public override void Update(IdentityRole model)
        {
            _roleManager.UpdateAsync(model);
        }

        public async Task<IdentityRole> GetById(string id) => await _roleManager.FindByIdAsync(id);

        public override void Delete(IdentityRole model)
        {
            _roleManager.DeleteAsync(model);
        }
    }
}