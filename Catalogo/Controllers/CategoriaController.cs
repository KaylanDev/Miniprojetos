using Catalogo.Data;
using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace Catalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> get() {
          
            return _context.Categorias.ToList();

        }

        [HttpGet("{id:int}",Name = "categoria")]
        public ActionResult Get(int id) {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

            if (categoria is null) return NotFound("n encontrou");

           return Ok(categoria);
        }

        [HttpGet]
        [Route("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriaProdutos()
        {
            return _context.Categorias.Include(p => p.Produtos).ToList();
        }
            

        [HttpPost]
        public ActionResult<Categoria> post(Categoria categoria)
        {
            if (categoria is null) return BadRequest("tem erro ai");

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("categoria",new {id =  categoria.CategoriaId},categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Categoria> put (int id,Categoria categoria)
        {
            if (id != categoria.CategoriaId) return BadRequest();

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {

            var categoria = _context.Categorias.FirstOrDefault(p => id == p.CategoriaId);
            if (categoria is null) return NotFound("produto n encontrado");

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);


        }


    }
}
