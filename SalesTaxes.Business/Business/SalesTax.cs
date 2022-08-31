using SalesTaxes.Business.Interfaces;

namespace SalesTaxes.Business.POCOs;

public class SalesTax: ITaxesPolicy
{
    public bool IsApplicable(IProduct product)
    {
        if (product.ItemType == ProductType.Book ||
            product.ItemType == ProductType.Food ||
            product.ItemType == ProductType.Medicine)
            return false;
        
        return true;
    }

    public decimal Compute(IProduct product, decimal totalPrice, DataTaxes dataTaxes)
    {
        if (IsApplicable(product))
            //return decimal.Round((totalPrice * dataTaxes.SalesTaxes), 10, MidpointRounding.AwayFromZero);
            return (totalPrice * dataTaxes.SalesTaxes);

        return 0m;
    }
    
}