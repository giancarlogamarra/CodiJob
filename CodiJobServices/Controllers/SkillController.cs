using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IServices;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodiJobServices2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        ISkillService Service;
        public SkillController(ISkillService service)
        {
            this.Service = service;
        }

        // GET: api/<controller>
        [HttpGet]
        public IList<SkillDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{SkillId}")]
        public SkillDTO Get(Guid SkillId)
        {
            return Service.GetAll()
                .Where(p => p.SkillId == SkillId)
                .FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]SkillDTO skill)
        {
            Service.Insert(skill);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{SkillId}")]
        public IActionResult Put(Guid SkillId,
                        [FromBody]SkillDTO skill)
        {
            skill.SkillId = SkillId;
            Service.Update(skill);
            return Ok(true);    
        }

        // DELETE api/<controller>/5
        [HttpDelete("{SkillId}")]
        public IActionResult Delete(Guid SkillId)
        {
            Service.Delete(SkillId);
            return Ok(true);
        }
    }
}