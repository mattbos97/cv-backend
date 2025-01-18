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
    }
}
