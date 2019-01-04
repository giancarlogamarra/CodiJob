using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodiJobServices.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        /*ISkillRepository repository;
        public SkillController(ISkillRepository repo)
        {
            this.repository = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TSkill> Get()
        {
            return repository.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{SkillId}")]
        public TSkill Get(Guid SkillId)
        {
            return repository.Items
                .Where(p => p.SkillId == SkillId)
                .FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]TSkill skill)
        {
            repository.Save(skill);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{SkillId}")]
        public IActionResult Put(Guid SkillId,
                        [FromBody]TSkill skill)
        {
            skill.SkillId = SkillId;
            repository.Save(skill);
            return Ok(true);    
        }

        // DELETE api/<controller>/5
        [HttpDelete("{SkillId}")]
        public IActionResult Delete(Guid SkillId)
        {
            repository.Delete(SkillId);
            return Ok(true);
        }*/
    }
}