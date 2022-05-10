﻿namespace Cs_EfCore_DBfirst
{
    public interface IdataAccess<TEntity, Tpk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(Tpk Id, TEntity entity);
        Task<TEntity> DeleteAsync(Tpk id);


    }
}