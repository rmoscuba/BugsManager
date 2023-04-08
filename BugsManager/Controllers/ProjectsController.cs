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
    public class ProjectsController : ControllerBase
    {
        private IRepositoryManager _repository;

        public ProjectsController(IRepositoryManager repository)
        {
            _repository = repository;
        }


        // GET: /<UsersController>
        [HttpGet]
        public IActionResult Get([FromQuery] Guid? project_id)
        {
            var projects = _repository.Project.GetAllProjects(trackChanges: false)
                    .Where(u => project_id is null ? true: u.Id == project_id );

            if (!projects.Any()) { return NotFound(); }
            else { return Ok(new { projects = projects }); }
        }
    }
}
