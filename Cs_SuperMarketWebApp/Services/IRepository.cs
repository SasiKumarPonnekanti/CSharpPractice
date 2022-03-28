using System.Collections.Generic;

namespace Cs_SuperMarketWebApp.Services
{
    public interface IRepository<T, U> where T : class
    {
        IEnumerable<T> Get();
        T Get(U id);
        bool Create(T data);
        bool Update(U id, T data);
        bool Delete(U id);
    }
}
