using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace backend.Controllers
{
    [ApiController]
    [Route("/admin")]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public AdminController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> Get ([FromBody] Admin newAdmin, [FromQuery] string isNew)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(isNew =="true")
                    {
                        //Checa se já ha um administrador igual ao que será cadastrado
                        var queryAdmin =  _dataContext.Admins.FromSqlRaw(String.Format(@"select * from Admins where username='{0}'",newAdmin.username));

                        if (await queryAdmin.CountAsync() > 0)
                        {
                            return StatusCode(418);
                        }
                        else
                        {
                            var response = await _dataContext.Admins.AddAsync(newAdmin);
                            await _dataContext.SaveChangesAsync();
                            return response.Entity;
                        }
                    }
                    else
                    {
                        var queryAdmin =  _dataContext.Admins.FromSqlRaw(String.Format(@"select * from Admins where username='{0}' and pwd='{1}'",newAdmin.username,newAdmin.pwd));
                        var response = await queryAdmin.ToListAsync();
                        response[0].pwd= "";
                        return response[0];
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch(Exception err)
            {
                throw err;
            }
        }
    }
}