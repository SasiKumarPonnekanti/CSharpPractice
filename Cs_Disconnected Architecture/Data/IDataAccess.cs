using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Disconnected_Architecture.Data
{
    internal interface IDataAccess<TEntity, in TPk> where TEntity : class
    {
        IEnumerable<TEntity> GetData();
        TEntity GetData(TPk id);
        void Create(TEntity entity);
        TEntity Update(TPk id, TEntity entity);
       TEntity Delete(TPk id);
    }
}
