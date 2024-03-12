using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.TransactionsUseCases;

namespace UseCases.ProductsUseCase
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IRecordTransactionUseCase _recordTransactionUseCase;

        public SellProductUseCase(IProductRepository productRepository, IRecordTransactionUseCase recordTransactionUseCase)
        {
            _productRepository = productRepository;
            _recordTransactionUseCase = recordTransactionUseCase;
        }

        public void Execute(string cashierName,int productId, int qtyToSell)
        {
            bool category = false;
            var product = _productRepository.GetProductById(productId,category);
            if (product == null) return;

            _recordTransactionUseCase.Execute(cashierName, product.Name, product.Quantity,product.Price, productId, qtyToSell);
            product.Quantity -= qtyToSell;
            _productRepository.UpdateProduct(product, productId);
        }
    }
}
