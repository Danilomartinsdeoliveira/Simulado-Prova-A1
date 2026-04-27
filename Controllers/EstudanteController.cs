using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CdastroEstudanteApi.Data;
using CdastroEstudanteApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CdastroEstudanteApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudanteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EstudanteController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetEstudantes(int id)    
        {
            var estudantes = await _context.Set<Estudante>().ToListAsync();
            return Ok(estudantes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstudante(int id)
        {
            var estudante = await _context.Set<Estudante>().FindAsync(id);
            if (estudante == null)
            {
                return NotFound();
            }
            return Ok(estudante);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEstudante(Estudante estudante)
        {
            _context.Set<Estudante>().Add(estudante);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEstudante), new { id = estudante.Id }, estudante);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudante(int id, [FromBody] Estudante estudante)
        {
            if (id != estudante.Id)
            {
                return BadRequest();
            }
            _context.Entry(estudante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}