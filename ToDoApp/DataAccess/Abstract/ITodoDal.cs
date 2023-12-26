using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ITodoDal
    {
        List<Todo> GetAll();
        void Add(Todo todo);
        void Delete(int id);

        void Update(Todo todo);
    }
}
