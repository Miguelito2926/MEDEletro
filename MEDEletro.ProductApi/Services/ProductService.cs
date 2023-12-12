using AutoMapper;
using MEDEletro.ProductApi.DTOs;
using MEDEletro.ProductApi.Models;
using MEDEletro.ProductApi.Repositories;
using MEDEletro.ProductApi.Services.Interfaces;

namespace MEDEletro.ProductApi.Services
{
    // Classe ProductService que implementa a interface IProductService
    public class ProductService : IProductService
    {
        // Campos privados para armazenar instâncias de IProductRepository e IMapper
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        // Construtor da classe que recebe instâncias de IProductRepository e IMapper
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        // Método para obter todos os produtos
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            // Chama o método GetAll do repositório para obter entidades de produto
            var productsEntity = await _productRepository.GetAll();

            // Mapeia as entidades de produto para DTOs usando AutoMapper
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        // Método para obter um produto por ID
        public async Task<ProductDTO> GetById(int id)
        {
            // Chama o método GetById do repositório para obter uma entidade de produto por ID
            var productsEntity = await _productRepository.GetById(id);

            // Mapeia a entidade de produto para um DTO usando AutoMapper
            return _mapper.Map<ProductDTO>(productsEntity);
        }

        // Método para adicionar um novo produto
        public async Task AddProduct(ProductDTO productDTO)
        {
            // Mapeia o DTO de produto para uma entidade de produto usando AutoMapper
            var productEntity = _mapper.Map<Product>(productDTO);

            // Chama o método Create do repositório para adicionar a nova entidade de produto
            await _productRepository.Create(productEntity);

            // Atualiza o ID no DTO com o ID atribuído à nova entidade de produto
            productDTO.Id = productEntity.Id;
        }

        // Método para atualizar um produto existente
        public async Task UpdateProduct(ProductDTO productDTO)
        {
            // Mapeia o DTO de produto para uma entidade de produto usando AutoMapper
            var produtoEntity = _mapper.Map<Product>(productDTO);

            // Chama o método Update do repositório para atualizar a entidade de produto
            await _productRepository.Update(produtoEntity);
        }

        // Método para remover um produto por ID
        public async Task RemoveProduct(int id)
        {
            // Chama o método GetById do repositório para obter a entidade de produto por ID
            var productEntity = _productRepository.GetById(id).Result;

            // Chama o método Delete do repositório para remover a entidade de produto
            await _productRepository.Delete(productEntity.Id);
        }
    }
}
