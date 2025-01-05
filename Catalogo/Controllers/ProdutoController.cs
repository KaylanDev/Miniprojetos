using Catalogo.Data;
using Catalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }


        //comentarios em xml

        /// <summary>
        /// Retorna os itens.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            try
            {
                var produtos = _context.Produtos.AsNoTracking().Take(10).ToList();


                if (produtos is null) return NotFound();

                return produtos;
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
        [HttpGet("{id:int}", Name = "obterproduto")]
        public ActionResult<Produto> Get(int id)
        {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
                if (produto is null) return NotFound("O produto n existe!");


                return produto;
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
        public ActionResult Post(Produto produto)
        {
            try
            {
                if (produto is null) return BadRequest();
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return new CreatedAtRouteResult("obterproduto", new { id = produto.ProdutoId }, produto);
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
        public ActionResult Put(int id, Produto produto)
        {
            try
            {
                if (id != produto.ProdutoId) return BadRequest();

                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(produto);
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
                var produto = _context.Produtos.FirstOrDefault(p => id == p.ProdutoId);
                if (produto is null) return NotFound("produto n encontrado");

                _context.Produtos.Remove(produto);
                _context.SaveChanges();
                return Ok(produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno");
            }
        }
    }
}
