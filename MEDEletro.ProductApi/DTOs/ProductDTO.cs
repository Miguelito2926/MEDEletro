using MEDEletro.ProductApi.Models;
using System.ComponentModel.DataAnnotations;

namespace MEDEletro.ProductApi.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        //Validação de nome obrigatorio
        [Required(ErrorMessage = "The Nme is Required")] //Validação de nome obrigatorio
        [MinLength(3)] //Precisa ter no minimo 3 caracteres
        [MaxLength(100)] //No maximo 100 caracteres
        public string? Name { get; set; }

        [Required(ErrorMessage = "The Price is Requerid")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Description is Requerid")]
        [MinLength(5)]
        [MaxLength(200)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The Stock is Requerid")]
        [Range(1,9999)]
        public long Stock { get; set; }

        public string? ImageUrl { get; set; }

        public Category? Category { get; set; }

        public int CategoryId { get; set; }
    }
}
