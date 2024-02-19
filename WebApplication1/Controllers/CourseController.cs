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
    public class CourseController
    {

        private readonly ICourseRepository _CourseRepo;

        public CourseController(ICourseRepository CourseRepo)
        {
            _CourseRepo = CourseRepo;
        }

        [HttpPost]
        public IActionResult CreateCourse(CourseDTO model)
        {
            try
            {
                var response = _CourseRepo.CreateCourse(model);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private IActionResult BadRequest(string message)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetAllCoursesFromMyDatabse()
        {
            try
            {
                var response = _CourseRepo.GetAllCourses();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private IActionResult Ok(IEnumerable<Course> response)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetByIdFromStudensTable(int id)
        {
            try
            {
                var response = _CourseRepo.GetByIdCourse(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public Course UpdateCourseInfo(Course updatedCourse)
        {
            string query = "UPDATE courses SET course_name = @course_name,  = @age, course_id = @course_id WHERE Course_id = @Course_id";

            using (NpgsqlConnection connection = new NpgsqlConnection("DefaultConnection"))
            {
                connection.Execute(query, new Course
                {
                    course_name = updatedCourse.course_name,
                    teacher_id = updatedCourse.teacher_id,
                    duration = updatedCourse.duration,
                    price = updatedCourse.price,
                    description = updatedCourse.description
                });

                return updatedCourse;
            }
        }

        [HttpDelete]
        public IActionResult DeleteStudensFromMyDatabase(int id)
        {
            try
            {
                var response = _CourseRepo.DeleteCourse(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
