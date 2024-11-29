using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystemAPI.Entities;
using SchoolManagementSystemAPI.Interface;

namespace SchoolManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClass _classService;
        public ClassController(IClass classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _classService.GetAllClass();
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
            var model = await _classService.GetClassByID(id);
            if (model == null)
                return NotFound("Record Not Found");
            return Ok(model);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveClass(Class classModel)
        {
            var model = await _classService.AddClass(classModel);
            return Ok(model);
        }

        [HttpPut]
        [Route("[action]/id")]
        public async Task<IActionResult> UpdateClass(int id,Class updateClass)
        {
            if (id != updateClass.ClassId)
                return BadRequest("Class ID Mismatch");

            var updateClassResult= await _classService.UpdateClass(id,updateClass);
            if (updateClassResult == null)
                return NotFound("Class with ID {id} Not Found or Update Failed");
            return Ok(updateClassResult);
        }

        [HttpDelete]
        [Route("[action]/id")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var model = await _classService.DeleteClassByID(id);
            return Ok(model);
        }
    }
}
