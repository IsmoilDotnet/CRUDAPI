using WebApplication1.EntitiesDTOs;
using WebApplication1.Models;

namespace WebApplication1.MyPattern
{
    public interface IStudentRepository
    {
        public string CreateStudent(StudentDTO studentDTO);
        public IEnumerable<Student> GetAllStudents();
        public Student GetByIdStudent(int id);
        public bool DeleteStudent(int id);
        public Student UpdateStudent(int id, StudentDTO studentDTO);

    }
}
