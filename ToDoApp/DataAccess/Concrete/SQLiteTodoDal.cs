using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class SQLiteTodoDal:SQLiteEntityRepositoryBase<Todo>,ITodoDal
    {
        
    }
}
