using HelloWorldApp.Controllers;
using HelloWorldApp.Data;
using HelloWorldApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldApp.Tests.Controllers
{
    public class NameEntriesControllerTests
    {
        private readonly AppDbContext _context;
        private readonly NameEntriesController _controller;

        public NameEntriesControllerTests()
        {
            // Menggunakan In-Memory Database untuk pengujian
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")  // Nama database in-memory
                .Options;
            _context = new AppDbContext(options);
            _controller = new NameEntriesController(_context);

            // Menambahkan data contoh ke database in-memory
            if (!_context.NameEntries.Any())
            {
                _context.NameEntries.Add(new NameEntry { Name = "John Doe" });
                _context.NameEntries.Add(new NameEntry { Name = "Jane Smith" });
                _context.SaveChanges();
            }
        }

        // Test untuk GET: api/NameEntries
        [Fact]
        public async Task GetNameEntries_ReturnsAllEntries()
        {
            // Act
            var result = await _controller.GetNameEntries();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<NameEntry>>>(result);
            var okResult = Assert.IsType<List<NameEntry>>(actionResult.Value);
            Assert.Equal(2, okResult.Count);  // Pastikan ada dua entri
        }

        // Test untuk GET: api/NameEntries/{id}
        [Fact]
        public async Task GetNameEntry_ReturnsCorrectEntry()
        {
            // Act
            var result = await _controller.GetNameEntry(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<NameEntry>>(result);
            var okResult = Assert.IsType<NameEntry>(actionResult.Value);
            Assert.Equal(1, okResult.Id);  // Pastikan ID entri yang diambil adalah 1
            Assert.Equal("John Doe", okResult.Name);  // Pastikan data yang diambil adalah John Doe
        }

        // Test untuk POST: api/NameEntries
        [Fact]
        public async Task PostNameEntry_CreatesNewEntry()
        {
            // Arrange
            var newEntry = new NameEntry { Name = "Mark Lee" };

            // Act
            var result = await _controller.PostNameEntry(newEntry);

            // Assert
            var actionResult = Assert.IsType<ActionResult<NameEntry>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var createdEntry = Assert.IsType<NameEntry>(createdAtActionResult.Value);
            Assert.Equal("Mark Lee", createdEntry.Name);  // Pastikan nama yang dibuat adalah Mark Lee
            Assert.NotNull(createdEntry.Id);  // Pastikan ID yang dihasilkan tidak null
        }
    }
}
