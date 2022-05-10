using FirstNaukri.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstNaukri.Services
{
    public interface IService<TEntity, in TPk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllByIdAsync(TPk Id);
        Task<TEntity> GetAsync(TPk id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPk id, TEntity entity);
        
        Task<TEntity> DeleteAsync(TPk id);
        Task<List<TEntity>> AddList(List<TEntity> list, int id);
    }
}
