using SalesTaxes.Business.Data;
using SalesTaxes.Business.Interfaces;

namespace SalesTaxes.Business.POCOs;

public class BillProcess
{
    public ICartTaxCompute SalesCartTaxCompute { get; }

    public BillProcess(ICartTaxCompute salesTaxProcess)
    {
        SalesCartTaxCompute = salesTaxProcess;
    }
    
    public Reciept ProcessCart2(List<ShoppingItem> shoppingCart)
    {
        decimal totalTaxForCart = 0;
        decimal totalAmountForCart = 0;
        foreach (var shoppingItem in shoppingCart)
        {
            shoppingItem.Totaltax = SalesCartTaxCompute.ComputeTotalTax(shoppingItem.Product, shoppingItem.Quantity);
            shoppingItem.TotalPrice += shoppingItem.Totaltax;
            totalTaxForCart += shoppingItem.Totaltax;
            totalAmountForCart += shoppingItem.TotalPrice;
            
            if (shoppingItem.Quantity > 1)
                shoppingItem.Description = String.Format("{0}: {1} ({2} @ {3})", shoppingItem.Product.Name,
                    shoppingItem.TotalPrice.ToString("#0.00"),
                    shoppingItem.Quantity,
                    (shoppingItem.TotalPrice / shoppingItem.Quantity).ToString("#0.00"));
            else
                shoppingItem.Description = String.Format("{0}: {1}", shoppingItem.Product.Name,
                    shoppingItem.TotalPrice.ToString("#0.00"));
        }

        return new Reciept(shoppingCart, totalAmountForCart, totalTaxForCart);
    }
}