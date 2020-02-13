using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [ApiController]
    [Route("/user")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Users.ToListAsync();
            return categories;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromServices] DataContext context, [FromBody]User user)
        {
            if(ModelState.IsValid)
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
                return user;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<User>> Delete([FromServices] DataContext context, [FromBody]User user)
        {
            if(ModelState.IsValid)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return user;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update([FromServices] DataContext context, [FromBody]User user)
        {
            if(ModelState.IsValid)
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
                return user;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}