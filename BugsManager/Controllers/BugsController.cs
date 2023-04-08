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
    public class BugsController : ControllerBase
    {
        private IRepositoryManager _repository;

        public BugsController(IRepositoryManager repository)
        {
            _repository = repository;
        }


        // GET: /<BugController>
        [HttpGet]
        public IActionResult Get([FromQuery] BugQueryParams bugQueryParams)
        {
            if (bugQueryParams.ProjectId is null && 
                bugQueryParams.UserId is null && 
                bugQueryParams.EndDate is null && 
                bugQueryParams.StartDate is null)
            {
                return BadRequest("At least one parameter required i.e.: project_id=<project-id>&user_id=<user-id> &start_date=<start_date>&end_date=<end_date>");
            }

            var bugs = _repository.Bug.GetAllBugsByParams(bugQueryParams, trackChanges: false);
            if (bugs is null) { return NotFound(); }
            else { return Ok(bugs); }
        }


        // POST /<BugController>
        [HttpPost]
        public IActionResult Post([FromBody] BugDTO value)
        {
            if (Request.Query.Any())
            {
                return StatusCode(StatusCodes.Status405MethodNotAllowed);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Bug bug = BugDTO.Map(value);
                _repository.Bug.CreateBug(bug);
                _repository.Save();
                return Ok(bug);
            }
            catch (DbUpdateException e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }
    }
}
