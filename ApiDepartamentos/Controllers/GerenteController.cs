using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDepartamentos.Context;
using ApiDepartamentos.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDepartamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerenteController : ControllerBase
    {
        private readonly AppDbContext context;
        public GerenteController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<GerenteController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {

                return Ok(context.Gerentes.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<GerenteController>/5
        [HttpGet("{id}", Name = "GetGerente")]
        public ActionResult Get(int id)
        {
            try
            {
                var gerente = context.Gerentes.FirstOrDefault(g => g.Id == id);
                return Ok(gerente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<GerenteController>
        [HttpPost]
        public ActionResult Post([FromBody] Gerentes gerente)
        {
            try
            {
                context.Gerentes.Add(gerente);
                context.SaveChanges();
                return CreatedAtRoute("GetEmpleado", new { id = gerente.Id }, gerente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<GerenteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Gerentes gerente)
        {
            try
            {
                if (gerente.Id == id)
                {
                    context.Gerentes.Add(gerente);
                    context.SaveChanges();
                    return CreatedAtRoute("GetDepartamento", new { id = gerente.Id }, gerente);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<GerenteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            try
            {
                var gerente = context.Gerentes.FirstOrDefault(g => g.Id == id);
                if (gerente != null)
                {
                    context.Gerentes.Remove(gerente);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
