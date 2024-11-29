using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystemAPI.Entities;
using SchoolManagementSystemAPI.Interface;

namespace SchoolManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _userService.GetAllUsers();
            if (model == null)
            {
                return NotFound("No Data Found");
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _userService.GetUserByID(id);
            if (model == null)
                return NotFound("No Data Found");
            return Ok(model);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveUser(User obj)
        {
            var model = await _userService.AddUser(obj);
            return Ok(model);
        }

        [HttpPut]
        [Route("[action]/id")]
        public async Task<IActionResult> UpdateUser(int id, User updateUser)
        {
            if (id != updateUser.UserId)
                return BadRequest("User Id Mismatch");

            var updateUserResult = await _userService.UpdateUser(id, updateUser);
            if (updateUserResult == null)
                return NotFound("User with ID {id} Not Found or Update Failed");
            return Ok(updateUserResult);
        }

        [HttpDelete]
        [Route("[action]/id")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var model = await _userService.DeleteUserByID(id);
            return Ok(model);
        }
    }
}
