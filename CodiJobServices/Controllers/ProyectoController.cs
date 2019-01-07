﻿using Application.DTOs;
using Application.IServices;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodiJobServices.Controllers
{
    [Route("api/[controller]")]
    public class ProyectoController : Controller
    {
        private IProyectoService Service;
        public ProyectoController(IProyectoService service) {
            Service = service;
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<ProyectoDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{ProyectoId}")]
        public ProyectoDTO Get(Guid ProyectoId)
        {
            
            return Service.GetAll().Where(p => p.ProyId == ProyectoId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]ProyectoDTO proyecto)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Model is not Valid");
            }
            Service.Insert(proyecto);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{ProyectoId}")]
        public IActionResult Put(Guid ProyectoId, [FromBody]ProyectoDTO proyecto)
        {
            proyecto.ProyId = ProyectoId;
            Service.Insert(proyecto);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ProyectoId}")]
        public IActionResult Delete(Guid ProyectoId)
        {
            Service.Delete(ProyectoId);
           return Ok(true);
        }
    }
}
