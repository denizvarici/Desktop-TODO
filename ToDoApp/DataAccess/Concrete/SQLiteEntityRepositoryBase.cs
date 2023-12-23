using DataAccess.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class SQLiteEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
    where TEntity:class,IEntity,new()
    {
        public List<TEntity> GetAll()
        {
            
        }
    }
}
