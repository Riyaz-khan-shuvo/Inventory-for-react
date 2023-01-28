using Invenroty.Data;
using Invenroty.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Invenroty.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public InventoryController(InventoryDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var departments = await _context.Departments.FindAsync(id);
            return departments == null ? NotFound() : Ok(departments);
        }
        [HttpPost()]
        public async Task<IActionResult> CreateDepartment(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, Department department)
        {
            if (id != department.Id) return BadRequest();
            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var StDel = await _context.Departments.FindAsync(id);
            if (StDel == null) return NotFound();
            _context.Departments.Remove(StDel);
            await _context.SaveChangesAsync();
            return NoContent();


        }
    }
}
