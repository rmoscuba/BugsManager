using BugsManager.Contexts;
using BugsManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BugsManager.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BugsManager.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepositoryManager _repository;

        public UsersController(IRepositoryManager repository)
        {
            _repository = repository;
        }


        // GET: /<UsersController>
        [HttpGet]
        public IActionResult Get([FromQuery] Guid? user_id)
        {
            var users = _repository.User.GetAllUsers(trackChanges: false)
                    .Where(u => user_id is null ? true: u.Id == user_id )
                    .Select(u =>
                    {
                        return new
                        {
                            user = u.Id,
                            name = u.Name
                        };
                    });

            if (!users.Any()) { return NotFound(); }
            else { return Ok(new { users = users }); }
        }
    }
}
