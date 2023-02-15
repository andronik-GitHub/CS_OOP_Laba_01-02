using Microsoft.AspNetCore.Mvc;
using NLayerApp.DAL.Repositories.Interfaces;
using NLayerApp.DAL.Entities;

namespace NLayerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUnitOfWork _uow;
        public UsersController(IUnitOfWork unitOfWork)
        {
            this._uow = unitOfWork;
        }


        [HttpGet] // GET: api/users
        public async Task<ActionResult<IEnumerable<User>>> GetAllAsync()
        {
            try
            {
                var result = await _uow.Users.GetAllAsync();
                Console.WriteLine("All users were successfully extracted from [Users]");

                return Ok(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in [UsersController]->[GetAllAsync]\n " + ex.Message);
                return StatusCode(500, "Status Code: 500");
            }
        }

        [HttpGet("{id}")] // GET: api/users/id
        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _uow.Users.GetAsync(id); // чи взагалі є такий запис в БД

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

        [HttpPost] // POST: api/users?nikname=...&email=...&sex=...&aboutmyself=...
        public async Task<ActionResult> AddAsync(User newUser)
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
                    var id = await _uow.Users.CreateAsync(new User
                    {
                        NikName = newUser.NikName,
                        Email = newUser.Email,
                        Sex = newUser.Sex,
                        AboutMyself = newUser.AboutMyself,
                    });
                    _uow.Save();
                    Console.WriteLine($"User{id} successfully added to [Users]");

                    return Ok(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in [UsersController]->[AddAsync]\n " + ex.Message);
                return StatusCode(500, "Status Code: 500");
            }
        }

        [HttpPut] // PUT: api/users?id=...&nikname=...&email=...&sex=...&aboutmyself=...
        public async Task<ActionResult> UpdateAsync(User upUser)
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
                    var result = await _uow.Users.GetAsync(upUser.Id); // чи взагалі є такий запис в БД

                    if (result == null)
                    {
                        Console.WriteLine($"Users {upUser.Id} from [Users] not found");
                        return NotFound();
                    }
                    else
                    {
                        await _uow.Users.UpdateAsync(new User
                        {
                            Id = upUser.Id,
                            NikName = upUser.NikName,
                            Email = upUser.Email,
                            Sex = upUser.Sex,
                            AboutMyself = upUser.AboutMyself,
                        });
                        _uow.Save();
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
                var result = await _uow.Users.GetAsync(id); // чи взагалі є такий запис в БД

                if (result == null)
                {
                    Console.WriteLine($"Users {id} from [Users] not found");
                    return NotFound();
                }
                else
                {
                    await _uow.Users.DeleteAsync(id);
                    _uow.Save();
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
