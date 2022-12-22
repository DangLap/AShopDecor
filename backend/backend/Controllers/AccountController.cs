using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using backend.Services;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
            public AccountController(IAccountService accountService)
            {
                _accountService = accountService; 
            }
        [HttpPost("Login")]
        public async Task<ActionResult<TaiKhoan>> Login(string username, string password)
        {
            var account = await _accountService.Login(username, password);
            IActionResult response = Unauthorized();

            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }
    }  
}
