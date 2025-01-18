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
    public class SkillController : ControllerBase
    {
        private readonly CVContext _context;

        public SkillController(CVContext context)
        {
            _context = context;
        }

        // GET: api/Skill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkill()
        {
            return await _context.Skills.ToListAsync();
        }

        // GET: api/Skill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkill(long id)
        {
            var skill = await _context.Skills.FindAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            return skill;
        }
    }
}
