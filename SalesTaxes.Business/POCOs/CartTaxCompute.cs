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
    
    public decimal ComputeTotalTax(IProduct product, int quantity)
    {
        decimal computedSalesTax = 0m;
        foreach (var tax in SalesTaxes)
        {
            var calculateTax = tax.Compute(product, quantity, _dataTaxes);
            computedSalesTax += calculateTax;
        }
        return computedSalesTax;
    }
 
}