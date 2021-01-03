using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Data.PostgreSql
{
     public abstract class BaseRepository
    {
        private readonly IConfiguration _configuration;
        
        protected BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string ConnStr => _configuration.GetConnectionString("DB");
        private string ConnStrLog => _configuration.GetConnectionString("LogDB");
        private string ConnStrPlay => _configuration.GetConnectionString("PlayDB");
        private string ConnStrReadonlyPlay => _configuration.GetConnectionString("PlayReadonlyDB");
        private string ConnStrReadonly => _configuration.GetConnectionString("PlayReadonlyDB");
        private string ConnStrPlayReport => _configuration.GetConnectionString("PlayReportDB");

        protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStr))
            {
                await connection.OpenAsync(); // Asynchronously open a connection to the database
                return
                    await getData(
                        connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task<T>>
            }
        }

        protected async Task WithConnection(Func<IDbConnection, Task> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStr))
            {
                await connection.OpenAsync(); // Asynchronously open a connection to the database
                await getData(
                    connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task>
            }
        }

        protected async Task<T> WithLogConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStrLog))
            {
                await connection.OpenAsync(); // Asynchronously open a connection to the database
                return await getData(connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task>
            }
        }

        protected async Task WithLogConnection(Func<IDbConnection, Task> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStrLog))
            {
                await connection.OpenAsync(); // Asynchronously open a connection to the database
                await getData(connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task>
            }
        }

        protected async Task<T> WithPlayConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStrPlay))
            {
                await connection.OpenAsync(); // Asynchronously open a connection to the database
                return await getData(connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task>
            }
        }

        protected T WithPlayConnection<T>(Func<IDbConnection, T> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStrPlay))
            {
                connection.Open(); // Synchronously open a connection to the database
                return getData(connection); // Synchronously execute getData, which has been passed in as a Func<IDBConnection, Task>
            }
        }
        
        protected void WithPlayConnection(Action<IDbConnection> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStrPlay))
            {
                connection.Open(); // Asynchronously open a connection to the database
                getData(connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task>
            }
        }

        protected T WithLogConnection<T>(Func<IDbConnection, T> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStrLog))
            {
                connection.Open(); // Asynchronously open a connection to the database
                return getData(connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task>
            }
        }


        protected T WithConnection<T>(Func<IDbConnection, T> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStr))
            {
                connection.Open(); // Asynchronously open a connection to the database
                return getData(connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task>
            }
        }

        protected void WithConnection(Action<IDbConnection> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStr))
            {
                connection.Open(); // Asynchronously open a connection to the database
                getData(connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task>
            }
        }

        protected async Task<T> WithReadonlyPlayConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStrReadonlyPlay))
            {
                await connection.OpenAsync(); // Asynchronously open a connection to the database
                return await getData(connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task>
            }
        }

        protected T WithReadonlyPlayConnection<T>(Func<IDbConnection, T> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStrReadonlyPlay))
            {
                connection.Open(); // Synchronously open a connection to the database
                return getData(connection); // Synchronously execute getData, which has been passed in as a Func<IDBConnection, Task>
            }
        }

        protected async Task<T> WithReadonlyConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStrReadonly))
            {
                await connection.OpenAsync(); // Asynchronously open a connection to the database
                return await getData(connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task>
            }
        }

        protected T WithReadonlyConnection<T>(Func<IDbConnection, T> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStrReadonly))
            {
                connection.Open(); // Synchronously open a connection to the database
                return getData(connection); // Synchronously execute getData, which has been passed in as a Func<IDBConnection, Task>
            }
        }

        protected async Task<T> WithPlayReportConnectionAsync<T>(Func<IDbConnection, Task<T>> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStrPlayReport))
            {
                await connection.OpenAsync(); // Asynchronously open a connection to the database
                return
                    await getData(
                        connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task<T>>
            }
        }

        protected T WithPlayReportConnection<T>(Func<IDbConnection, T> getData)
        {
            using (var connection = new NpgsqlConnection(ConnStrPlayReport))
            {
                connection.Open();
                return getData(connection);
            }
        }

        protected void WithPlayReportConnection(Action<IDbConnection> getData)
        {
            using (var connection =new  NpgsqlConnection(ConnStrPlayReport))
            {
                connection.Open();
                getData(connection);
            }
        }
    }
}