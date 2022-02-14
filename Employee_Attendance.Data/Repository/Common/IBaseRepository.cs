using Arch.EntityFrameworkCore.UnitOfWork;

namespace Employee_Attendance.Data
{
   public interface IBaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        void SetAuditableInfo(TEntity entity);
    }
}
