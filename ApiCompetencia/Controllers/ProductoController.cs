using ApiCompetencia.Context;
using ApiCompetencia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCompetencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext context;
        public ProductoController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var productoCateg = context.producto.Join(context.categoria, prod => prod.categoria_id,
                    cat => cat.id, (prod, cat) => new {
                        id = prod.id,
                        nombre = prod.nombre,
                        costo = prod.costo,
                        precio = prod.precio,
                        caracteristicas = prod.caracteristicas,
                        stock = prod.stock,
                        marca = prod.marca,
                        categoria_id = prod.categoria_id,
                        nombrecat = cat.nombre,
                    }).ToList();
                return Ok(productoCateg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}", Name = "GetProducto")]
        public ActionResult Get(int id)
        {
            try
            {
                var producto = context.producto.FirstOrDefault(g => g.id == id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Productos_Bd producto)
        {
            try
            {
                context.producto.Add(producto);
                context.SaveChanges();
                return CreatedAtRoute("GetProducto", new { id = producto.id }, producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Productos_Bd producto)
        {
            try
            {
                if (producto.id == id)
                {
                    context.Entry(producto).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProducto", new { id = producto.id }, producto);
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

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var producto = context.producto.FirstOrDefault(g => g.id == id);
                if (producto != null)
                {
                    context.producto.Remove(producto);
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
