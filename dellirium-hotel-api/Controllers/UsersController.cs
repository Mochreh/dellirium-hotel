using dellirium_hotel_api.Models;
using dellirium_hotel_api.Utils;
using dellirium_hotel_services.Models;
using dellirium_hotel_services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dellirium_hotel_api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;
        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] UserTO userTo)
        {
            try
            {
                //var user = _mapper.Map<UserModel>(userTo);
                var user = Mapping.Mapper.Map<UserModel>(userTo);
                var result = _userService.Create(user);
                return Ok();
            }
            catch (Exception e)
            {

                throw new Exception("error"+e.InnerException);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}