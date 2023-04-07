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

        public BugControllerTest()
        {
            _repositoryManager = new RepositoryManagerFake();
            _bugController = new BugsController(_repositoryManager);
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
            Assert.IsType<List<BugResultDTO>>(result.Value);
            Assert.Equal(2,(result.Value as List<BugResultDTO>).Count);
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
            Assert.IsType<List<BugResultDTO>>(result.Value);
            Assert.Equal(3, (result.Value as List<BugResultDTO>).Count);
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
            Assert.IsType<List<BugResultDTO>>(result.Value);
            Assert.Equal(3, (result.Value as List<BugResultDTO>).Count);
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
            Assert.IsType<List<BugResultDTO>>(result.Value);
            Assert.Equal(3, (result.Value as List<BugResultDTO>).Count);
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

    }
}
