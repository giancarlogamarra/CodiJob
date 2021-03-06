﻿using System;
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
    public class GrupoController : Controller
    {
        IGrupoService Service;
        public GrupoController(IGrupoService service)
        {
            this.Service = service;
        }

        // GET: api/<controller>
        [HttpGet]
        public IList<GrupoDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{GrupoId}")]
        public GrupoDTO Get(Guid GrupoId)
        {
            return Service.GetAll()
                .Where(p => p.Id == GrupoId)
                .FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]GrupoDTO grupo)
        {
            Service.Insert(grupo);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{GrupoId}")]
        public IActionResult Put(Guid GrupoId,
                        [FromBody]GrupoDTO grupo)
        {
            grupo.Id = GrupoId;
            Service.Update(grupo);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{GrupoId}")]
        public IActionResult Delete(Guid GrupoId)
        {
            Service.Delete(GrupoId);
            return Ok(true);
        }
    }
}