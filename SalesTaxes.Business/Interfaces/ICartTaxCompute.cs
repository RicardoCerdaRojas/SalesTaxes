namespace SalesTaxes.Business.Interfaces;

public interface ICartTaxCompute
{
    decimal ComputeTotalTax(IProduct product, int quantity);

}