using SalesTaxes.Business.Interfaces;

namespace SalesTaxes.Business.POCOs;

public class ImportDuty: ITaxesPolicy
{
    public bool IsApplicable(IProduct product)
    {
        return product.IsImport;
    }

    public decimal Compute(IProduct product, decimal totalPrice, DataTaxes dataTaxes)
    {
        if (IsApplicable(product))
            //return decimal.Round((totalPrice * dataTaxes.ImportDuty), 10, MidpointRounding.AwayFromZero);
            return totalPrice * dataTaxes.ImportDuty;

        return 0m;
    }
    
}