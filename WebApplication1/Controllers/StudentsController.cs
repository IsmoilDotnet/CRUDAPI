using Microsoft.AspNetCore.Mvc;
using WebApplication1.EntitiesDTOs;
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
