using Dapper;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public IEnumerable<Car> GetAll()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Cars";

                return conn.Query<Car>(sql);
            }
        }

        public Car GetById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Cars WHERE Cars.Id = @id";

                return conn.Query<Car>(sql, new { id }).SingleOrDefault();
            }
        }

        public Car Create(Car car)
        {
            string sql = "INSERT INTO Cars VALUES (@brand, @mileage, @reserved); SELECT SCOPE_IDENTITY();";

            using (var conn = new SqlConnection(_connectionString))
            {
                var id = conn.ExecuteScalar<int>(sql, car);
                return GetById(id);
            }
        }

        public Car Update(Car car)
        {
            string sql = "UPDATE Cars SET Mileage = @mileage WHERE Id = @id";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute(sql, car);
                return GetById(car.Id);
            }
        }

        public bool Delete(Car car)
        {
            string sql = "DELETE FROM Cars WHERE Id = @id";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Execute(sql, car) == 1;
            }
        }
    }
}
