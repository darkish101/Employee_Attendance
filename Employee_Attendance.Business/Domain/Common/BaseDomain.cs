using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using Employee_Attendance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Attendance.Business
{
   public class BaseDomain<TEntity, TRepository>: IBaseDomain<TEntity>
       where TEntity: class, IBaseEntity
       where TRepository: class, IBaseRepository<TEntity>
    {
        protected readonly TRepository _repository;
        protected readonly IUnitOfWork _unitOfWork;
        public BaseDomain(TRepository repository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository ?? (TRepository)_unitOfWork.GetRepository<TEntity>(true);
        }

        protected async Task<int> CommitAsync()
        {
            try
            {
                return await _unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<int> DeleteAsync(TEntity request)
        {
            try
            {
                //_repository.SetAuditableInfo(request);
                _repository.Delete(request);
                return await CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            try
            {
                var entity = _repository.Find(id);
               // _repository.SetAuditableInfo(entity);
                _repository.Delete(entity);
                return await CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = await _repository.FindAsync(expression);
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<IPagedList<TEntity>> GetAllAsync(int pageIndex, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            try
            {
                IPagedList<TEntity> request = await _repository.GetPagedListAsync(pageIndex: pageIndex, pageSize: pageSize, orderBy: orderBy);
                return request;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<TEntity> InsertAsync(TEntity request)
        {
            try
            {
                _repository.SetAuditableInfo(request);
                await _repository.InsertAsync(request);
                await CommitAsync();

            }
            catch
            {
                throw;
            }

            return request;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity request)
        {
            try
            {
                _repository.SetAuditableInfo(request);
                _repository.Update(request);
                await CommitAsync();
            }
            catch
            {
                throw;
            }
            return request;
        }
    }
}
