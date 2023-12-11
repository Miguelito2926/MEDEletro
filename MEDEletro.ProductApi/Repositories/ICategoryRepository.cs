using MEDEletro.ProductApi.Models;

namespace MEDEletro.ProductApi.Repositories
{
    public interface ICategoryRepository
    {
        //Definindo contrato na Interface a ser implemnetado 
        Task<IEnumerable<Category>> GetAll();
        Task<IEnumerable<Category>> GetCategoriesProducts();
        Task<Category> GetById(int id);
        Task<Category> Cerate(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(int id);  

    }
}
