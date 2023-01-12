using System.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTRLab4Backend.Data;
using NTRLab4Backend.Models;


namespace NTRLab4Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly NTRLab4BackendContext _context;

        public UserController(NTRLab4BackendContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var Users = from u in _context.User
                select u;


            return new JsonResult(Users);
        }

        [HttpPost]
        public async Task<Boolean> Post(User User)
        {
            // @TODO: Add validation for duplicated usernames
            _context.Add(User);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpPost]
        [Route("/api/[controller]/login")]
        public async Task<Boolean> Login(Credentials credentials)
            // need to use Credentials class instead of 2 separate String objects, otherwise, the data are not being mapped
        {
            // @TODO: Add session guid generation
            var user = await _context.User
                .FirstOrDefaultAsync(u => u.Username == credentials.Username);

            if (user != null && user.Password == credentials.Password && user.IsLibrarian == 0)
            {
                return true;
            }

            return false;
        }

        [HttpPost]
        [Route("/api/[controller]/loginasadmin")]
        public async Task<Boolean> LoginAsAdmin(Credentials credentials)
            // need to use Credentials class instead of 2 separate String objects, otherwise, the data are not being mapped
        {
            // @TODO: Add session guid generation
            var user = await _context.User
                .FirstOrDefaultAsync(u => u.Username == credentials.Username);

            if (user != null && user.Password == credentials.Password && user.IsLibrarian == 1)
            {
                return true;
            }

            return false;
        }

        [HttpPut]
        public async Task<Boolean> Put(User User)
        {
            _context.Update(User);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpDelete("{id}")]
        public async Task<Boolean> Delete(int id)
        {
            var user = await _context.User
                .FirstOrDefaultAsync(u => u.Id == id);

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
