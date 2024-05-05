using CRUD_usuarios.Models;
using CRUD_usuarios.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_usuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> Get()
        {
            List<UserModel> users = await _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> GetById(int id)
        {
            UserModel user = await _userRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Post([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.PostUser(userModel);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Put([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.PutUser(userModel, id);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            await _userRepository.DeleteUser(id);

            return Ok("User deleted success");
        }
    }
}
