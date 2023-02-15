using Microsoft.AspNetCore.Mvc;
using NLayerApp.BLL.DTO;
using NLayerApp.BLL.Services.Interfaces;
using NLayerEF.DAL.Repositories.Interfaces;

namespace NLayerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        IUserService _userService;
        IUnitOfWorkEF unitOfWorkEF;
        public UsersController(IUserService userService,
            IUnitOfWorkEF unitOfWorkEF)
        {
            this._userService = userService;
            this.unitOfWorkEF = unitOfWorkEF;
        }


        [HttpGet] // GET: api/users
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllAsync()
        {
            try
            {
                var result = await _userService.GetAllAsync();
                Console.WriteLine("All users were successfully extracted from [Users]");

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in [UsersController]->[GetAllAsync]\n " + ex.Message);
                return StatusCode(500, "Status Code: 500");
            }
        }

        [HttpGet("ADO/{id}")] // GET: api/users/id
        public async Task<ActionResult<UserDTO>> GetByIdADOAsync(int id)
        {
            try
            {
                var result = await _userService.GetAsync(id); // чи взагалі є такий запис в БД

                if (result == null)
                {
                    Console.WriteLine($"Users {id} from [Users] not found");
                    return NotFound();
                }
                else
                {
                    Console.WriteLine($"Users {result.Id} were successfully extracted from [Users]");
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in [UsersController]->[GetByIdAsync]\n " + ex.Message);
                return StatusCode(500, "Status Code: 500");
            }
        }

        [HttpGet("EF/{id}")] // GET: api/users/id
        public async Task<ActionResult<UserDTO>> GetByIdEFAsync(int id)
        {
            try
            {
                var result = await unitOfWorkEF.userRep.GetByIdAsync(id); // чи взагалі є такий запис в БД

                if (result == null)
                {
                    Console.WriteLine($"Users {id} from [Users] not found");
                    return NotFound();
                }
                else
                {
                    Console.WriteLine($"Users {result.Id} were successfully extracted from [Users]");
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in [UsersController]->[GetByIdAsync]\n " + ex.Message);
                return StatusCode(500, "Status Code: 500");
            }
        }

        [HttpPost] // POST: api/users
        public async Task<ActionResult> AddAsync(UserDTO newUser)
        {
            try
            {
                // Чи введені валідні данні
                if (newUser.NikName == null || newUser.Email == null || newUser.Sex == null)
                {
                    return BadRequest("Invalid information");
                }
                else
                {
                    var id = await _userService.CreateAsync(newUser);
                    Console.WriteLine($"User {id} successfully added to [Users]");

                    return Ok(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in [UsersController]->[AddAsync]\n " + ex.Message);
                return StatusCode(500, "Status Code: 500");
            }
        }

        [HttpPut] // PUT: api/users
        public async Task<ActionResult> UpdateAsync(UserDTO upUser)
        {
            try
            {
                // Чи введені валідні данні
                if (upUser.NikName == null || upUser.Email == null || upUser.Sex == null)
                {
                    return BadRequest("Invalid information");
                }
                else
                {
                    var result = await _userService.GetAsync(upUser.Id); // чи взагалі є такий запис в БД

                    if (result == null)
                    {
                        Console.WriteLine($"Users {upUser.Id} from [Users] not found");
                        return NotFound();
                    }
                    else
                    {
                        await _userService.UpdateAsync(upUser);
                        Console.WriteLine($"User{upUser.Id} successfully update to [Users]");

                        return Ok();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in [UsersController]->[UpdateAsync]\n " + ex.Message);
                return StatusCode(500, "Status Code: 500");
            }
        }

        [HttpDelete("{id}")] // DELETE: api/users/id
        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            try
            {
                var result = await _userService.GetAsync(id); // чи взагалі є такий запис в БД

                if (result == null)
                {
                    Console.WriteLine($"Users {id} from [Users] not found");
                    return NotFound();
                }
                else
                {
                    await _userService.DeleteAsync(id);
                    Console.WriteLine($"User{id} successfully deleted to [Users]");

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in [UsersController]->[UpdateAsync]\n " + ex.Message);
                return StatusCode(500, "Status Code: 500");
            }
        }
    }
}
