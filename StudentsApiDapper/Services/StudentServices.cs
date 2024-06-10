using Dapper;
using Microsoft.Data.SqlClient;
using StudentsApiDapper.Model;
using System.Data;

namespace StudentsApiDapper.Services
{
    public class StudentServices
    {
        public readonly IConfiguration _configuration;
        public readonly string connectionString;
        public StudentServices(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration["ConnectionStrings:DefaultConnection"];

        }
        public List<Student> GetAllStudents()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "select * from students";
                var std = connection.Query<Student>(sql);
                return std.ToList();
            }
        }
        public string AddStudent(Student std)
        {
            using(var connection = new SqlConnection(connectionString))
            {
                string sql = "insert into students values(@s_name,@s_age,@s_dep)";
                connection.Execute(sql, std);
                return "posted successfully";
            }
        }
        public string UpdateStudent(Student std, int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = $"update students set s_name=@name,s_age=@age,s_dep=@dep where s_id=@id";
                connection.Execute(sql, new {name=std.S_Name,age=std.S_Age,dep=std.S_Dep,id=id});
                return "updated successfully";
            }
        }
        public string DeleteStudent(int id) {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "delete from students where s_id=@id";
                connection.Execute(sql, new {id=id});
                return "deletion completed";

            }
        }
        public List<Student>GetStudentByAgeSP(int age)
        {
            using( var connection = new SqlConnection(connectionString))
            {
                string SP = "GetStudentByAge";
                var students=connection.Query<Student>(SP, new {age=age},commandType: CommandType.StoredProcedure);
                return students.ToList();
            }
        }
    }
}
