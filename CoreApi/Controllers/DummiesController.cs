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
    public class DummiesController : ControllerBase
    {
        private readonly HefnyDBContext context;

        public DummiesController(HefnyDBContext context)
        {
            this.context = context;
            if (context.Dummies.Count() == 0)
            {
                context.Dummies.Add(new Dummies { Id = 0, Name = "Default Name", IsActive = true });
                context.SaveChanges();

            }

        }

        // GET: api/Dummies All
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dummies>>> GetDummies()
        {
            return await context.Dummies.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Dummies>> GetDummies(int ID)
        {
            var dummies = await context.Dummies.FindAsync(ID);
            if (dummies == null)
            {
                return NotFound();
            }
            return dummies;
        }

          // POST: api/Dummies
        [HttpPost]
        public async Task<ActionResult<Dummies>> PostDummies(Dummies dummies)
        {
            context.Dummies.Add(dummies);
            await context.SaveChangesAsync();

            // return CreatedAtAction("GetDummies", new { ID = Dummies.Id }, Dummies);
            return CreatedAtAction("GetDummies", new { ID = dummies.Id });
        }


        
        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDummies(int id, Dummies dummies)
        {
            if (id != dummies.Id)
            {
                return BadRequest();
            }

            context.Entry(dummies).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/Dummies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dummies>> DeleteDummies(int id)
        {
            var Dummies = await context.Dummies.FindAsync(id);
            if (Dummies == null)
            {
                return NotFound();
            }

            context.Dummies.Remove(Dummies);
            await context.SaveChangesAsync();

            return Dummies;
        }

    }

}