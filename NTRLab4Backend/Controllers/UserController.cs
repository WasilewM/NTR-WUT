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
            var Users = from b in _context.User
                select b;


            return new JsonResult(Users);
        }

        [HttpPost]
        public async Task<Boolean> Post(User User)
        {
            _context.Add(User);
            await _context.SaveChangesAsync();
            return true;
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
