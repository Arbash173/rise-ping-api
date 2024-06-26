using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RisePingAPIs.Models;

namespace RisePingAPIs.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {
        private readonly RisePingContext _context;

        public UsersController(RisePingContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<UserCreate>> CreateUser(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Email == user.Email || u.UserName == user.UserName))
            {
                return Conflict("Email is already taken");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login user)
        {
            try
            {
                var availableUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password==user.Password);
                if (availableUser != null)
                {
                    var metaData = new
                    {
                        User = availableUser,
                    };
                    return StatusCode(200, metaData);
                }


                return StatusCode(401);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex}");


                return StatusCode(500);
            }

        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
    }
    public class Login
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

