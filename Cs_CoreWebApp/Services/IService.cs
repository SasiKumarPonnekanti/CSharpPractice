using System.Collections.Generic;
using System.Threading.Tasks;
namespace Cs_CoreWebApp.Services
{
    public interface IService<TEntity,Tpk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(int id,TEntity entity);
        Task<TEntity> DeleteAsync(int id);

    }
}
