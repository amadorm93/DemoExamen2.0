using ApiDepartamentos.Context;
using ApiDepartamentos.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDepartamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly AppDbContext context;
        public DepartamentoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<DepartamentoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                
                return Ok(context.Departamentos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<DepartamentoController>/5
        [HttpGet("{id}", Name ="GetDepartamento")]
        public ActionResult Get(int id)
        {
            try
            {
                var departamento = context.Departamentos.FirstOrDefault(g => g.IdDepartamento == id);
                return Ok(departamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<DepartamentoController>
        [HttpPost]
        public ActionResult Post([FromBody]Departamento departamento)
        {
            try
            {
                context.Departamentos.Add(departamento);
                context.SaveChanges();
                return CreatedAtRoute("GetDepartamento", new { id = departamento.IdDepartamento }, departamento);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<DepartamentoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Departamento departamento)
        {
            try
            {
                if (departamento.IdDepartamento == id)
                {
                    context.Entry(departamento).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetDepartamento", new { id = departamento.IdDepartamento }, departamento);
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

        // DELETE api/<DepartamentoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            
            try
            {
                var departamento = context.Departamentos.FirstOrDefault(g => g.IdDepartamento == id);
                if (departamento != null)
                {
                    context.Departamentos.Remove(departamento);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
