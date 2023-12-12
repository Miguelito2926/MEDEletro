using MEDEletro.ProductApi.DTOs;

namespace MEDEletro.ProductApi.Services.Interfaces
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductDTO>> GetProducts();       
        Task<ProductDTO> GetById(int id);
        Task AddProduct(ProductDTO productDTO);
        Task UpdateProduct(ProductDTO productDTO);
        Task RemoveProduct(int id);
    }
}

