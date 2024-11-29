using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystemAPI.Entities;
using SchoolManagementSystemAPI.Interface;

namespace SchoolManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher _teacherService;
        public TeacherController(ITeacher teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _teacherService.GetAllTeachers();
            if (model == null)
            {
                return NotFound("No Data Found");
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _teacherService.GetTeacherByID(id);
            if (model == null)
                return NotFound("No Data Found");
            return Ok(model);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveTeacher(Teacher obj)
        {
            var model = await _teacherService.AddTeacher(obj);
            return Ok(model);
        }

        [HttpPut]
        [Route("[action]/id")]
        public async Task<IActionResult> UpdateTeacher(int id,Teacher updateTeacher)
        {
            if (id != updateTeacher.TeacherId)
                return BadRequest("Teacher ID Mismatch");

            var updateTeacherResult=await _teacherService.UpdateTeacher(id,updateTeacher);
            if (updateTeacherResult == null)
                return NotFound("Teacher with ID {id} Not Found or Update Failed");
            return Ok(updateTeacherResult);

        }
        [HttpDelete]
        [Route("[action]/id")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var model = await _teacherService.DeleteTeacherByID(id);
            return Ok(model);
        }
    }
}
