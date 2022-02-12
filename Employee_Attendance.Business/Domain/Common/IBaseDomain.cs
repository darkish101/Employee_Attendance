using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using Employee_Attendance.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Employee_Attendance.Business
{
   public interface IBaseDomain<TEntity> where TEntity: class, IBaseEntity
    {
        Task<TEntity> InsertAsync(TEntity request);
        Task<TEntity> UpdateAsync(TEntity request);
        Task<int> DeleteAsync(TEntity request);
        Task<int> DeleteAsync(int id);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        Task<IPagedList<TEntity>> GetAllAsync(int pageIndex, int pageSize,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}
