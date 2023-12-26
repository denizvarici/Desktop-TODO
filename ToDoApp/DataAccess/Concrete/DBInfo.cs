using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public static class DBInfo
    {
        //public static string connectionString = "Data Source = R:\\GITHUB\\Desktop-TODO\\ToDoApp\\ToDoUI\\bin\\Debug\\net6.0-windows\\ToDo.db";
        public static string C()
        {
          
            string currentDirectory = Directory.GetCurrentDirectory();

          
            string databaseFileName = "ToDo.db";

        
            string databaseFilePath = Path.Combine(currentDirectory, databaseFileName);

            
          
            string connectionString = $"Data Source={databaseFilePath};Version=3;";


            return connectionString;
            
        }
    }
}

