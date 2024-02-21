using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMC_Contracts;
using SMC_Entities;

using SMC_Entities.Models;
using SMC_Entities.Paged;
using System.Linq;
using System.Threading.Tasks;

namespace SMC_Repository
{
    public abstract class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        protected SmcContext smcContext { get; set; }

        public BaseRepo(SmcContext sMCContext)
        {
            this.smcContext = sMCContext;
        }

        public virtual IQueryable<T> GetAll()
        {
            return smcContext.Set<T>().AsNoTracking();
        }

        public virtual PagedList<T> GetAll(QueryStringParameters parameters)
        {
            return PagedList<T>.ToPagedList(smcContext.Set<T>().AsNoTracking(),
                parameters.PageNumber,
                parameters.PageSize);
        }

        public virtual T GetById(int id)
        {
            return smcContext.Set<T>().Find(id);
        }

        public virtual void Create(T entity)
        {
            smcContext.Set<T>().Add(entity);
            smcContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            smcContext.Set<T>().Update(entity);
            smcContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            smcContext.Set<T>().Remove(entity);
            smcContext.SaveChanges();
        }
    }
}
