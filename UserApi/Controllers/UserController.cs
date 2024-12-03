using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Model;

namespace UserApi.Controllers
{
    [ApiController]

    [Route("api/controller")]
    public class UserController : Controller
    {
        private readonly UserDbContext _db;

        public UserController(UserDbContext db)
        {
            this._db=db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _db.Users.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (id ==null)
            {
                return Content("User Not Found");
            }
            return await _db.Users.FindAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>>PutUser(int id, User user)
        {
            if(id ==null)
            {
                return NotFound();
            }
            _db.Entry(user).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExit(id))
                {
                    return NotFound();
                }
                else { 
                
                    throw;
                }
            }
            return Content("Update Successfully");
        }
        [HttpDelete]
        public async Task<ActionResult<User>>DeleteProduct(int id)
        {
            var user = await _db.Users.FindAsync(id);
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return Content("Delete Successfully");
        }
        private bool UserExit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
