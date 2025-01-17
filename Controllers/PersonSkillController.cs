using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cv_backend;
using cv_backend.Models;

namespace cv_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonSkillController : ControllerBase
    {
        private readonly CVContext _context;

        public PersonSkillController(CVContext context)
        {
            _context = context;
        }

        // GET: api/PersonSkill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetPersonSkill()
        {
            return await _context.Skill.ToListAsync();
        }

        // GET: api/PersonSkill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetPersonSkill(long id)
        {
            var skill = await _context.Skill.FindAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            return skill;
        }

        // PUT: api/PersonSkill/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonSkill(long id, Skill skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            _context.Entry(skill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonSkillExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonSkill
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Skill>> PostPersonSkill(Skill skill)
        {
            _context.Skill.Add(skill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonSkill", new { id = skill.Id }, skill);
        }

        // DELETE: api/PersonSkill/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonSkill(long id)
        {
            var skill = await _context.Skill.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            _context.Skill.Remove(skill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonSkillExists(long id)
        {
            return _context.Skill.Any(e => e.Id == id);
        }
    }
}
