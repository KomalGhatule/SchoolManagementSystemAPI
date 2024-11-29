using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystemAPI.Entities;
using SchoolManagementSystemAPI.Interface;

namespace SchoolManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubject _subjectService;
        public SubjectController(ISubject subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sub = await _subjectService.GetAllSubjects();
            if (sub == null)
            {
                return NotFound("No Data Found");
            }
            return Ok(sub);
        }

        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> Get(int id)
        {
            var sub = await _subjectService.GetSubjectByID(id);
            if (sub == null)
                return NotFound("No Data Found");
            return Ok(sub);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveSubject(Subject obj)
        {
            var sub = await _subjectService.AddSubject(obj);
            return Ok(sub);
        }
        [HttpPut]
        [Route("[action]/id")]
        public async Task<IActionResult> UpdateSubject(int id,Subject updateSubject)
        {
            if (id != updateSubject.SubjectId)
                return BadRequest("Subject ID Mismatch");
             
            var updateSubjectResult= await _subjectService.UpdateSubject(id,updateSubject);
            if (updateSubjectResult == null)
                return NotFound("Subject with ID {id} Not Found or Update Failed");
            return Ok(updateSubjectResult);
        }
        [HttpDelete]
        [Route("[action]/id")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var Sub = await _subjectService.DeleteSubjectByID(id);
            return Ok(Sub);
        }
    }
}
