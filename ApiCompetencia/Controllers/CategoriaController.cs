using ApiCompetencia.Context;
using ApiCompetencia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCompetencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext context;
        public CategoriaController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<CategoriaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.categoria.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}", Name = "GetCategoria")]
        public ActionResult Get(int id)
        {
            try
            {
                var categ = context.categoria.FirstOrDefault(g => g.id == id);
                return Ok(categ);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public ActionResult Post([FromBody] Categoria_BD categ)
        {
            try
            {
                context.categoria.Add(categ);
                context.SaveChanges();
                return CreatedAtRoute("GetCategoria", new { id = categ.id }, categ);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria_BD categ)
        {
            try
            {
                if (categ.id == id)
                {
                    context.Entry(categ).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCategoria", new { id = categ.id }, categ);
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

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var categ = context.categoria.FirstOrDefault(g => g.id == id);
                if (categ != null)
                {
                    context.categoria.Remove(categ);
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
