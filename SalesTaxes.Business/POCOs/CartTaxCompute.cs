using SalesTaxes.Business.Interfaces;

namespace SalesTaxes.Business.POCOs;

public class CartTaxCompute: ICartTaxCompute
{
    List<ITaxesPolicy> SalesTaxes;
    private DataTaxes _dataTaxes;

    public CartTaxCompute(DataTaxes dataTaxes)
    {
        _dataTaxes = dataTaxes;
        SalesTaxes = new List<ITaxesPolicy>()
        {
            new SalesTax(),
            new ImportDuty()
        };
        
    }
    
    public decimal ComputeTotalTax(IProduct product, decimal totalPrice)
    {
        decimal computedSalesTax = 0m;
        foreach (var tax in SalesTaxes)
        {
            var calculateTax = tax.Compute(product, totalPrice, _dataTaxes);
            computedSalesTax +=  (0.05m / 1.00m) * decimal.Round((calculateTax * (1.00m / 0.05m)), MidpointRounding.AwayFromZero);
        }
        return computedSalesTax;
    }

}