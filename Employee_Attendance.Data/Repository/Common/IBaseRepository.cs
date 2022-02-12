using Arch.EntityFrameworkCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Attendance.Data
{
   public interface IBaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        void SetAuditableInfo(TEntity entity);
    }
}
