using BugsManager.Controllers;
using BugsManager.Interfaces;
using BugsManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Xunit;

namespace TestBugsManager
{
    public class BugControllerTest
    {
        private readonly BugsController _bugController;
        private readonly IRepositoryManager _repositoryManager;
        private readonly DefaultHttpContext _context;

        public BugControllerTest()
        {
            _repositoryManager = new RepositoryManagerFake();
            _context = new DefaultHttpContext();
            _bugController = new BugsController(_repositoryManager)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = _context
                }
            };
        }

        [Fact]
        public void Get_WhenCalledReturnsStatus200OKRightBugsList1()
        {
            // Arrange
            BugQueryParams bugQueryParams = new BugQueryParams()
                {
                    ProjectId = new Guid("b5d21e01-ae4d-414a-aa38-11e63e307025"),
                    UserId = new Guid("3ca8c63c-b419-4587-a2b4-2cb91126dd68")
                };
            // Act
            var result = _bugController.Get(bugQueryParams) as ObjectResult;
            // Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsType<BugResult>(result.Value);
            Assert.Equal(2,((result.Value as BugResult).bugs as List<BugResultDTO>).Count);
        }

        [Fact]
        public void Get_WhenCalledReturnsStatus200OKRightBugsList2()
        {
            // Arrange
            BugQueryParams bugQueryParams = new BugQueryParams()
            {
                ProjectId = new Guid("b5d21e01-ae4d-414a-aa38-11e63e307025")
            };
            // Act
            var result = _bugController.Get(bugQueryParams) as ObjectResult;
            // Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsType<BugResult>(result.Value);
            Assert.Equal(3, ((result.Value as BugResult).bugs as List<BugResultDTO>).Count);
        }

        [Fact]
        public void Get_WhenCalledReturnsStatus200OKRightBugsList3()
        {
            // Arrange
            BugQueryParams bugQueryParams = new BugQueryParams()
            {
                StartDate = DateTime.Parse("2023-04-08")
            };
            // Act
            var result = _bugController.Get(bugQueryParams) as ObjectResult;
            // Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsType<BugResult>(result.Value);
            Assert.Equal(3, ((result.Value as BugResult).bugs as List<BugResultDTO>).Count);
        }

        [Fact]
        public void Get_WhenCalledReturnsStatus200OKRightBugsList4()
        {
            // Arrange
            BugQueryParams bugQueryParams = new BugQueryParams()
            {
                EndDate = DateTime.Parse("2023-04-08")
            };
            // Act
            var result = _bugController.Get(bugQueryParams) as ObjectResult;
            // Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsType<BugResult>(result.Value);
            Assert.Equal(3, ((result.Value as BugResult).bugs as List<BugResultDTO>).Count);
        }

        [Fact]
        public void Get_WhenCalledNotParameterReturnsStatus400BadRequest()
        {
            // Arrange
            BugQueryParams bugQueryParams = new BugQueryParams();
            // Act
            var result = _bugController.Get(bugQueryParams) as ObjectResult;
            // Assert
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Fact]
        public void Add_BugInvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var missingItem = new BugDTO()
            {
                Description = "Missing"
            };
            _bugController.ModelState.AddModelError("Project", "Required");
            _bugController.ModelState.AddModelError("User", "Required");
            // Act
            var badResponse = _bugController.Post(missingItem);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_BugObject_ReturnsOk()
        {
            // Arrange
            var missingItem = new BugDTO()
            {
                Project = new Guid("147528c3-f1ea-4768-bdb7-fa05c2437990"),
                User = new Guid("3ca8c63c-b419-4587-a2b4-2cb91126dd68"),
                Description = "Contract history. When applying more than one filter, it does not return information.",
            };
            // Act
            var okResponse = _bugController.Post(missingItem);
            // Assert
            Assert.IsType<OkObjectResult> (okResponse);
        }

        [Fact]
        public void CallPostMethodWithQueryParamsReturns405StatusCode()
        {
            // Arrange
            var nullItem = new BugDTO();
            _bugController.HttpContext.Request.QueryString = new QueryString("?project_id=1 ");
            // Act
            var notAllowedResponse = _bugController.Post(nullItem) as StatusCodeResult;
            // Assert
            Assert.Equal(StatusCodes.Status405MethodNotAllowed, notAllowedResponse.StatusCode);
        }
    }
}
