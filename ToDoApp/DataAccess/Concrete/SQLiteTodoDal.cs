using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class SQLiteTodoDal : ITodoDal
    {
        public List<Todo> GetAll()
        {
            List<Todo> todos = new List<Todo>();

            using (SQLiteConnection connection = new SQLiteConnection(DBInfo.C()))
            {
                connection.Open();
                string query = "SELECT * FROM todos";

                using (SQLiteCommand command = new SQLiteCommand(query,connection))
                {
                    using(SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Todo todo = new Todo
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                TodoTitle = Convert.ToString(reader["TodoTitle"]),
                                TodoText = Convert.ToString(reader["TodoText"]),
                                TodoIsDoneInfo = Convert.ToInt32(reader["TodoIsDoneInfo"])
                            };
                            todos.Add(todo);
                        }
                        
                    }
                }
            }
            return todos;
        }
        public void Add(Todo todo)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBInfo.C()))
            {
                connection.Open();

                string query = "INSERT INTO todos (TodoTitle,TodoText,TodoIsDoneInfo) VALUES (@TodoTitle,@TodoText,@TodoIsDoneInfo)";

                using (SQLiteCommand command = new SQLiteCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@TodoTitle", todo.TodoTitle);
                    command.Parameters.AddWithValue("@TodoText", todo.TodoText);
                    command.Parameters.AddWithValue("@TodoIsDoneInfo", todo.TodoIsDoneInfo);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }                                                                    
        }

        public void Delete(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBInfo.C()))
            {
                connection.Open();

                string query = "DELETE FROM todos WHERE Id = @Id";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }

                connection.Close();

            }
        }

        public void Update(Todo todo)
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBInfo.C()))
            {
                connection.Open();

                string query = "UPDATE todos SET TodoTitle = @NewTitle, TodoText = @NewText, TodoIsDoneInfo = @NewInfo WHERE Id = @Id";

                using (SQLiteCommand command = new SQLiteCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@NewTitle", todo.TodoTitle);
                    command.Parameters.AddWithValue("@NewText", todo.TodoText);
                    command.Parameters.AddWithValue("@NewInfo", todo.TodoIsDoneInfo);
                    command.Parameters.AddWithValue("@Id", todo.Id);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
