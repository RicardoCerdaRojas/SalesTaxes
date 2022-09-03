using SalesTaxes.Business.Interfaces;
using SalesTaxes.Business.POCOs;


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

    public decimal Compute(IProduct product, int quantity, DataTaxes dataTaxes)
    {
        if (IsApplicable(product))
        {
            decimal calculateTaxForAllProducs = 0;
            for (int i = 1; i <= quantity; i++)
            {
                decimal temporalTax = decimal.Round((product.Price * dataTaxes.SalesTaxes), 2, MidpointRounding.AwayFromZero);

                if(Convert.ToInt32(temporalTax.ToString()[3].ToString()) > 5)
                    calculateTaxForAllProducs += decimal.Round(temporalTax, 1, MidpointRounding.AwayFromZero);
                else
                    calculateTaxForAllProducs += temporalTax;
            }
            return calculateTaxForAllProducs;
        }
        return 0m;
    }
    
}