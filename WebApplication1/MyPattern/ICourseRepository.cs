using WebApplication1.EntitiesDTOs;
using WebApplication1.Models;

namespace WebApplication1.MyPattern
{
    public interface ICourseRepository
    {
        public string CreateCourse(CourseDTO courseDTO);
        public IEnumerable<Course> GetAllCourses();
        public Course GetByIdCourse(int id);
        public bool DeleteCourse(int id);
        public Course UpdateCourse(int id, CourseDTO courseDTO);
    }
}
