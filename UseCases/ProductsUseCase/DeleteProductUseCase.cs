﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.ProductsUseCase
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Execute(int productId)
        {
            _productRepository.DeleteProduct(productId);
        }
    }
}
