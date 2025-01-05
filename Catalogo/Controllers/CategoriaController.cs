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

        //comentarios em xml

        /// <summary>
        /// Retorna os itens.
        /// </summary>

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> get()
        {
            try
            {
                throw new Exception();
                //return _context.Categorias.AsNoTracking().Take(10).ToList();
                //AsNoTracking evita a sobrecarga, deixando a consulta otimizada
                //Take ira limitar a consulta apenas com os 10 primeiros

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno");
            }

        }

        /// <summary>
        /// retorna elemento pelo id
        /// </summary>
        //metodo que ira retornar pelo Id
        [HttpGet("{id:int}", Name = "categoria")]
        public ActionResult Get(int id)
        {

            try
            {
                var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

                if (categoria is null) return NotFound("n encontrou");
                return Ok(categoria);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno");
                //tratando erro com a classe statuscode
            }



        }

        /// <summary>
        /// retorna elementos relacionados
        /// </summary>
        //metodo que ira retornar produtos relacionados
        [HttpGet]
        [Route("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriaProdutos()
        {
            try
            {
                return _context.Categorias.Include(p => p.Produtos).Where(p => p.CategoriaId < 5).ToList();
                //o where limita a consulta para evitar uma grande quantidade de dados retornado.

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno");

            }

        }

        /// <summary>
        /// adciona um novo elemento
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Categoria> post(Categoria categoria)
        {
            try
            {
                if (categoria is null) return BadRequest("tem erro ai");

                _context.Categorias.Add(categoria);
                _context.SaveChanges();

                return new CreatedAtRouteResult("categoria", new { id = categoria.CategoriaId }, categoria);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno");

            }

        }

        /// <summary>
        /// altera a informação
        /// </summary>
        /// <returns></returns>

        [HttpPut("{id:int}")]
        public ActionResult<Categoria> Put(int id, Categoria categoria)
        {
            try
            {
                if (id != categoria.CategoriaId) return BadRequest();

                //entry modifica o elemento selecionado e o state recebe o modo modified q avisa q esta sendo modificado
                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(categoria);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno");

            }

        }

        /// <summary>
        /// Deleta o elemento selecionado
        /// </summary>
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var categoria = _context.Categorias.FirstOrDefault(p => id == p.CategoriaId);
                if (categoria is null) return NotFound("produto n encontrado");

                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
                return Ok(categoria);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno");
            }


        }


    }
}
