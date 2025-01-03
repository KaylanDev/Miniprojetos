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
        
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produtos.ToList();


            if (produtos is null) return NotFound();

            return produtos;
        }

        [HttpGet("{id:int}", Name = "obterproduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null) return NotFound("O produto n existe!");


            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {

            if (produto is null) return BadRequest();
            _context.Produtos.Add(produto);
            _context.SaveChanges();



            return new CreatedAtRouteResult("obterproduto", new { id = produto.ProdutoId }, produto);
        }


        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId) return BadRequest();

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(produto);
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) {

            var produto = _context.Produtos.FirstOrDefault(p => id == p.ProdutoId);
            if (produto is null) return NotFound("produto n encontrado");

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok(produto);
        
        
        }
    }
}
