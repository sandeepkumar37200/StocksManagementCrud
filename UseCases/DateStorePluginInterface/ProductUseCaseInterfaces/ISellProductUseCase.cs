﻿namespace UseCases.ProductsUseCase
{
    public interface ISellProductUseCase
    {
        void Execute(string cashierName, int productId, int qtyToSell);
    }
}