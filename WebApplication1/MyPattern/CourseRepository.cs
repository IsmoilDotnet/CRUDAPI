using Dapper;
using Npgsql;
using WebApplication1.EntitiesDTOs;
using WebApplication1.Models;

namespace WebApplication1.MyPattern
{
    public class CourseRepository
    {
        public IConfiguration _configuration;

        public CourseRepository(IConfiguration configuration)
        {
            _configuration = _configuration;
        }

        public string CreateCourse(CourseDTO courseDTO)
        {

            try
            {
                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = "insert into courses(course_name,teacher_id,duration,price,description) Values(@course_id,@teacher_id,@duration,@price,@description))";

                    var parameters = new CourseDTO
                    {
                        course_name = courseDTO.course_name,
                        teacher_id = courseDTO.teacher_id,
                        duration = courseDTO.duration,
                        price = courseDTO.price,
                        description = courseDTO.description

                    };


                    connection.Execute(query, parameters);

                }

                return "malumot yaratildi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool DeleteCourse(int id)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    string query = $"delete from courses where course_id = {id};";

                    connection.Execute(query);

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Course> GetAllCourses()
        {

            using (var connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = "select * from courses";

                var result = connection.Query<Course>(query);

                return result;
            }

        }

        public IEnumerable<Course> GetByIdCourse(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string query = $"select * from courses where student_id = {id};";

                var result = connection.Query<Course>(query);

                returnresult;
            }
        }

        public Course UpdateCourse(int id, CourseDTO studentDTO)
        {
            throw new NotImplementedException();
        }

        Course ICourseRepository.GetByIdCourse(int id)
        {
            throw new NotImplementedException();
        }
    }
}
