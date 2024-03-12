using CoreBusiness;

namespace UseCases.TransactionsUseCases
{
    public interface IRecordTransactionUseCase
    {
        void Execute(string cashierName,string productName, int productQuantity, double price,int productId, int qtyToSell);
    }
}