using SalesTaxes.Business.POCOs;

namespace SalesTaxes.Business.Interfaces;

public interface ITaxesPolicy
{
    bool IsApplicable(IProduct product);
    decimal Compute(IProduct product, decimal totalPrice, DataTaxes dataTaxes);
    
}