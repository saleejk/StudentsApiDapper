using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsApiDapper.Model;
using StudentsApiDapper.Services;

namespace StudentsApiDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly StudentServices _studentServices;
        public StudentController(StudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            return Ok(_studentServices.GetAllStudents());
        }
        [HttpPost("AddStudent")]
        public IActionResult AddStudent(Student std)
        {
            _studentServices.AddStudent(std);
            return Ok("student Added successfully");
        }
        [HttpPut("UpdateStudent")]
        public IActionResult UpdateStudent(Student std,int id)
        {
            _studentServices.UpdateStudent(std,id);
            return Ok("updated successfully");
        }
        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
            _studentServices.DeleteStudent(id);
            return Ok("deletion completed");
        }
        [HttpGet("StoreProcedure")]
        public IActionResult GetStudentByAgeSP(int age)
        {
            return Ok(_studentServices.GetStudentByAgeSP(age));
        }
    }
}
