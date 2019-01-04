using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using CodiJobServices.Model.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodiJobServices.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class GrupoController : Controller
    {
        /*IGrupoRepository repository;
        public GrupoController(IGrupoRepository repo)
        {
            this.repository = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TGrupo> Get()
        {
            return repository.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{GrupoId}")]
        public TGrupo Get(Guid GrupoId)
        {
            return repository.Items
                .Where(p => p.Id == GrupoId)
                .FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]TGrupo grupo)
        {
            repository.Save(grupo);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{GrupoId}")]
        public IActionResult Put(Guid GrupoId,
                        [FromBody]TGrupo grupo)
        {
            grupo.Id = GrupoId;
            repository.Save(grupo);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{GrupoId}")]
        public IActionResult Delete(Guid GrupoId)
        {
            repository.Delete(GrupoId);
            return Ok(true);
        }*/
    }
}