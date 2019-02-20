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
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly HefnyDBContext context;
        public EmployeeDetailsController(HefnyDBContext context)
        {
            this.context = context;

            if (context.EmployeeDetails.Count() == 0)
            {
                context.EmployeeDetails.Add(new EmployeeDetails { Address = "", DateOfBirth = DateTime.Now.Date, Emailid = "", EmpId = 0, EmpName = "Default insertion", Gender = "male", PinCode = "pincode" });
                context.SaveChanges();

            }

        }

        // GET: api/EmployeeDetails All
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDetails>>> GetEmployeeDetails()
        {
            return await context.EmployeeDetails.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetails>> GetEmployeeDetails(int ID)
        {
            var EmployeeDetails = await context.EmployeeDetails.FindAsync(ID);
            if (EmployeeDetails == null)
            {
                return NotFound();
            }
            return EmployeeDetails;
        }


        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<EmployeeDetails>> PostEmployeeDetails(EmployeeDetails EmployeeDetails)
        {
            context.EmployeeDetails.Add(EmployeeDetails);
            await context.SaveChangesAsync();

            // return CreatedAtAction("GetEmployeeDetails", new { ID = EmployeeDetails.Id }, EmployeeDetails);
            return CreatedAtAction("GetEmployeeDetails", new { ID = EmployeeDetails.EmpId });
        }


        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeDetails(int id, EmployeeDetails EmployeeDetails)
        {
            if (id != EmployeeDetails.EmpId)
            {
                return BadRequest();
            }


            context.Entry(EmployeeDetails).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeDetails",EmployeeDetails);
            //return NoContent();
        }


        // DELETE: api/EmployeeDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDetails>> DeleteEmployeeDetails(int id)
        {
            var EmployeeDetails = await context.EmployeeDetails.FindAsync(id);
            if (EmployeeDetails == null)
            {
                return NotFound();
            }

            context.EmployeeDetails.Remove(EmployeeDetails);
            await context.SaveChangesAsync();

            return EmployeeDetails;
        }




    }

}