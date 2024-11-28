using Moq;
using MockQueryable.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeVoter.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EmployeeVoter.Data;
using EmployeeVoter.Models.Entitites;

[TestClass]
public class EmployeesControllerTests
{
    private Mock<ApplicationDbContext> _mockContext;
    private DbContextOptions<ApplicationDbContext> _options;
    private List<Employee> _employees;
    private EmployeesController _controller;

    [TestInitialize]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _employees = new List<Employee>
        {
            new Employee { Id = Guid.NewGuid(), Name = "John Doe", Email = "john@example.com", Phone = "12345", Salary = 50000 },
            new Employee { Id = Guid.NewGuid(), Name = "Jane Doe", Email = "jane@example.com", Phone = "67890", Salary = 60000 }
        };

        _mockContext = new Mock<ApplicationDbContext>(_options);
        var mockSet = _employees.AsQueryable().BuildMockDbSet();
        _mockContext.Setup(c => c.Employees).Returns(mockSet.Object);

        _controller = new EmployeesController(_mockContext.Object);
    }

    [TestMethod]
    public void GetAllEmployees_ShouldReturnListOfEmployees()
    {
        var result = _controller.GetAllEmployees() as OkObjectResult;

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result.Value, typeof(IEnumerable<Employee>));
        var employeeList = (IEnumerable<Employee>)result.Value;
        Assert.AreEqual(2, employeeList.Count());
    }

    //[TestMethod]
    //public void GetEmployeeById_ShouldReturnEmployee_WhenEmployeeExists()
    //{
    //    var existingEmployee = _employees.First();

    //    var result = _controller.GetEmployeeById(existingEmployee.Id) as OkObjectResult;

    //    Assert.IsNotNull(result);
    //    var returnedEmployee = result.Value as Employee;
    //    Assert.IsNotNull(returnedEmployee);
    //    Assert.AreEqual(existingEmployee.Id, returnedEmployee.Id);
    //}

    [TestMethod]
    public void GetEmployeeById_ShouldReturnNotFound_WhenEmployeeDoesNotExist()
    {
        var result = _controller.GetEmployeeById(Guid.NewGuid());

        Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    }


    //[TestMethod]
    //public void DeleteEmployee_ShouldReturnNoContent_WhenEmployeeExists()
    //{

    //    var existingEmployee = _employees.First();
    //    _mockContext.Setup(x => x.SaveChanges()).Returns(1);

    //    var result = _controller.DeleteEmployee(existingEmployee.Id);

    //    Assert.IsInstanceOfType(result, typeof(NoContentResult));
    //    _mockContext.Verify(x => x.Employees.Remove(It.IsAny<Employee>()), Times.Once);
    //    _mockContext.Verify(x => x.SaveChanges(), Times.Once);
    //}

    //[TestMethod]
    //public void DeleteEmployee_ShouldReturnNotFound_WhenEmployeeDoesNotExist()
    //{

    //    var result = _controller.DeleteEmployee(Guid.NewGuid());

    //    Assert.IsInstanceOfType(result, typeof(NotFoundResult));
    //}

}