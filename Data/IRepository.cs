using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        TEntity Create(TEntity obj);

        TEntity Update(TEntity obj);

        bool Delete(TEntity obj);
    }
}
