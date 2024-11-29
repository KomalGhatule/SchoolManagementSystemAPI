using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystemAPI.Entities;
using SchoolManagementSystemAPI.Interface;

namespace SchoolManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentService;
        public StudentController(IStudent studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var stud = await _studentService.GetAllStudents();
            if (stud == null)
            {
                return NotFound("No Data Found");
            }
            return Ok(stud);
        }

        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> Get(int id)
        {
            var stud = await _studentService.GetStudentByID(id);
            if (stud == null)
                return NotFound("No Data Found");
            return Ok(stud);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveStudent(Student obj)
        {
            var stud = await _studentService.AddStudent(obj);
            return Ok(stud);
        }

        [HttpPut]
        [Route("[action]/id")]
        public async Task<IActionResult> UpdateStudent(int id,Student updateStudent)
        {
            if (id != updateStudent.StudentId)
                return BadRequest("Student ID Mismatch");

            var updateStudentResult=await _studentService.UpdateStudent(id,updateStudent);
            if (updateStudentResult == null)
                return NotFound("Student with ID {id} Not Found or Update Failed");
            return Ok(updateStudentResult);
        }

        [HttpDelete]
        [Route("[action]/id")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var stud = await _studentService.DeleteStudentByID(id);
            return Ok(stud);
        }
    }
}
