using CoreBusiness;

namespace UseCases.ProductsUseCase
{
    public interface IEditProductUseCase
    {
        void Execute(Product product, int productId);
    }
}