using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController :ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> register (UserForRegistorDtos userForRegistorDtos)
        {    
           var username = userForRegistorDtos.Username.ToLower();
            if( await _repo.UserExists(username))
            
            return  BadRequest("username already exist");

               var UserToCreate = new User { Username = username};
 
            var createUser = _repo.Register(UserToCreate,userForRegistorDtos.Password);

            return StatusCode(201);
        }
}

}
