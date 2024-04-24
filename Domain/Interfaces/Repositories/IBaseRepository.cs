﻿using Domain.Entity;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository <TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(int id, CancellationToken token = default);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token = default);
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken token = default);
        Task<bool> UpdateAsync(TEntity entity, CancellationToken token = default);
        Task<bool> DeleteAsync(TEntity entity, CancellationToken token = default);
    }
}
