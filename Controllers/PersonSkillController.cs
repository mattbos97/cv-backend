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
        public async Task<ActionResult<IEnumerable<PersonSkill>>> GetPersonSkills()
        {
            return await _context.PersonSkills.ToListAsync();
        }

        // GET: api/PersonSkill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonSkill>> GetPerson_Skill(long id)
        {
            var personSkill = await _context.PersonSkills.FindAsync(id);

            if (personSkill == null)
            {
                return NotFound();
            }

            return personSkill;
        }

        // PUT: api/PersonSkill/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson_Skill(long id, PersonSkill personSkill)
        {
            if (id != personSkill.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(personSkill).State = EntityState.Modified;

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
        public async Task<ActionResult<PersonSkill>> PostPerson_Skill(PersonSkill personSkill)
        {
            _context.PersonSkills.Add(personSkill);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonSkillExists(personSkill.PersonId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPerson_Skill", new { id = personSkill.PersonId }, personSkill);
        }

        // DELETE: api/PersonSkill/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson_Skill(long id)
        {
            var personSkill = await _context.PersonSkills.FindAsync(id);
            if (personSkill == null)
            {
                return NotFound();
            }

            _context.PersonSkills.Remove(personSkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonSkillExists(long id)
        {
            return _context.PersonSkills.Any(e => e.PersonId == id);
        }
    }
}
