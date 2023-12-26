using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TodoManager : ITodoService
    {
        private ITodoDal _todoDal;
        public TodoManager(ITodoDal todoDal)
        {
            _todoDal = todoDal;
        }

        public List<Todo> GetAll()
        {
            return _todoDal.GetAll();
        }

        public void Add(Todo todo)
        {
            _todoDal.Add(todo);
        }

        public void Delete(int id)
        {
            _todoDal.Delete(id);
        }

        public void Update(Todo todo)
        {
            _todoDal.Update(todo);
        }
    }
}
