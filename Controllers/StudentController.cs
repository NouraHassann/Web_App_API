

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskStudDeptCore.Data;
using TaskStudDeptCore.Models;

namespace TaskStudDeptCore.Controllers
{
  ////\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;
    public StudentsController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAll() =>
        await _context.Students.Include(s => s.Department).ToListAsync();

    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return Ok(student);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Student student)
    {
        if (id != student.Id) return BadRequest();
        _context.Entry(student).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return NotFound();
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet("with-departments")]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudentsWithDepartments()
    {
        return await _context.Students.Include(s => s.Department).ToListAsync();
    }

   

    }
}
