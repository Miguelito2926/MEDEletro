using MEDEletro.ProductApi.Models;
using System.ComponentModel.DataAnnotations;

namespace MEDEletro.ProductApi.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The Nme is Required")] //Validação de nome obrigatorio
        [MinLength(3)] //Precisa ter no minimo 3 caracteres
        [MaxLength(100)] //No maximo 100 caracteres
        public string? Name { get; set; }


        public ICollection<Product>? Products { get; set; }
    }
}
