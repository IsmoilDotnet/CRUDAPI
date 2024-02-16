using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using WebApplication1.EntitiesDTOs;
using WebApplication1.Models;
using WebApplication1.MyPattern;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepo;

        public StudentsController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpPost]
        public IActionResult CreateStudentwejrqeoruyqe(StudentDTO model)
        {
            try
            {
                var response = _studentRepo.CreateStudent(model);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllStudentsFromMyDatabse()
        {
            try
            {
                var response = _studentRepo.GetAllStudents();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetByIdFromStudensTable(int id)
        {
            try
            {
                var response = _studentRepo.GetByIdStudent(id);

                return Ok(response);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public Student UpdateStudentInfo(Student updatedStudent)
        {
            string query = "UPDATE student SET full_name = @full_name, age = @age, course_id = @course_id WHERE student_id = @student_id";

            using (NpgsqlConnection connection = new NpgsqlConnection("DefaultConnection"))
            {
                connection.Execute(query, new Student
                {
                    student_id = updatedStudent.student_id,
                    full_name = updatedStudent.full_name,
                    age = updatedStudent.age,
                    course_id = updatedStudent.course_id
                });

                return updatedStudent;
            }
        }

        [HttpDelete]
        public IActionResult DeleteStudensFromMyDatabase(int id)
        {
            try
            {
                var response = _studentRepo.DeleteStudent(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
