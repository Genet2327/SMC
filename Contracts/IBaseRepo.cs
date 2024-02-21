using Microsoft.AspNetCore.Identity;
using SMC_Entities.Paged;
using System.Linq;
using System.Threading.Tasks;

namespace SMC_Contracts
{
    public   interface IBaseRepo<T>
    {
        IQueryable<T> GetAll();
        PagedList<T> GetAll(QueryStringParameters parameters);
        T GetById(int id);
        void Create(T  entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
