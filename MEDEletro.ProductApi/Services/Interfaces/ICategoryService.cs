using MEDEletro.ProductApi.DTOs;

namespace MEDEletro.ProductApi.Services.Interfaces
{
    // Interface ICategoryService que define operações relacionadas a categorias de produtos
    public interface ICategoryService
    {
        // Método para obter todas as categorias
        Task<IEnumerable<CategoryDTO>> GetCategories();

        // Método para obter todas as categorias com seus produtos associados
        Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();

        // Método para obter uma categoria por ID
        Task<CategoryDTO> GetById(int id);

        // Método para adicionar uma nova categoria
        Task AddCategory(CategoryDTO categoryDTO);

        // Método para atualizar uma categoria existente
        Task UpdateCategory(CategoryDTO categoryDTO);

        // Método para remover uma categoria por ID
        Task RemoveCategory(int id);
    }
}
