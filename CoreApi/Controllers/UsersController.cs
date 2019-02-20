using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly HefnyDBContext context;
        public UsersController(HefnyDBContext context)
        {
            this.context = context;

            if (context.Users.Count() == 0)
            {
                context.Users.Add(new Users { Id = 0, Name = "Default Name", IsActive = true });
                context.SaveChanges();

            }

        }

        // GET: api/Users All
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }


        // GET: api/Users By ID

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int ID)
        {
            var user = await context.Users.FindAsync(ID);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }


        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users User)
        {
            context.Users.Add(User);
            await context.SaveChangesAsync();

            // return CreatedAtAction("GetUsers", new { ID = Users.Id }, Users);
            return CreatedAtAction("GetUsers", new { ID = User.Id });
        }


        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users User)
        {

            User.Id=id;
            if (id != User.Id)
            {
                return BadRequest();
            }

            context.Entry(User).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(int id)
        {
            var Users = await context.Users.FindAsync(id);
            if (Users == null)
            {
                return NotFound();
            }

            context.Users.Remove(Users);
            await context.SaveChangesAsync();

            return Users;
        }

    }

}