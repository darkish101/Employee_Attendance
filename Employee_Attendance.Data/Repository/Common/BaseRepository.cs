using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Attendance.Data
{
    public abstract class BaseRepository<TEntity, TDbContext> : Repository<TEntity>, IBaseRepository<TEntity>
        where TEntity : class, IBaseEntity
        where TDbContext : DbContext
    {
        protected BaseRepository(TDbContext dbContext) : base(dbContext)
        { }

        public void SetAuditableInfo(TEntity entity)
        {
            if (entity is BaseEntity<int> auditableEntity)
            {
                if (auditableEntity.Id == 0)
                {
                    auditableEntity.Created_On = DateTime.Now;
                    _dbContext.Entry(auditableEntity).Property(e => e.LastUpdatedDate).IsModified = false;
                }
                else
                {
                    auditableEntity.LastUpdatedDate = DateTime.Now;
                    _dbContext.Entry(auditableEntity).Property(e => e.Created_On).IsModified = false;
                }
            }
        }
    }
}
