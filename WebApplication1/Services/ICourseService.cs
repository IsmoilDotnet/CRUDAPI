using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ICourseService
    {
        public void DeleteCourse();
        public string CreateCourse(Course course);
        public void UpdateCourse(Course course);

    }
}
