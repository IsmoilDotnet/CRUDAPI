using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IStudentService
    {
        public Student GetStudent(int id);
        public void UpdateStudent(Student student);
        public void DeleteStudent(int id);
    }
}
