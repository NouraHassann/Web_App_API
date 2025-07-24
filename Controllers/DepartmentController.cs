using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskStudDeptCore.Data;
using TaskStudDeptCore.Models;

namespace TaskStudDeptCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DepartmentsController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll() =>
            await _context.Departments.Include(d => d.Students).ToListAsync();

        [HttpPost]
        public async Task<IActionResult> Create(Department dept)
        {
            _context.Departments.Add(dept);
            await _context.SaveChangesAsync();
            return Ok(dept);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Department dept)
        {
            if (id != dept.Id) return BadRequest();
            _context.Entry(dept).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return NotFound();
            _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
