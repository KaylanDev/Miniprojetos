using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Catalogo.Validations;

namespace Catalogo.Models;

public class Produto
{
    [Key]
    public int ProdutoId { get; set; }

    [Required]
    [StringLength(80,MinimumLength = 5 ,ErrorMessage ="Digite um nome valido!")]
    [PrimeiraLetraMaiusculaAttribute]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre {2} a {1}!")]
    public string? Descricao { get; set; }

    [Required]
    [Range(1, 1000, ErrorMessage = "O valor deve ser entre {1} e {2}")]
    public decimal Preco { get; set; }

    [Required]
    [StringLength(300, MinimumLength = 3, ErrorMessage = "A imagem precisa ter entre {1} e {2} caracteres!")]
    public string? ImagemUrl { get; set; }
    [Range(0,10000,ErrorMessage ="O Valor precisa estar entre {1} e {2}!")]
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    public int CategoriaId { get; set; }
    public Categoria?Categoria { get; set; }


}
