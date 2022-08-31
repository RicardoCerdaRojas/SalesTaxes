using SalesTaxes.Business.Data;

namespace SalesTaxes.Business.POCOs;

public class BilledShoppingItem
{
    public ShoppingItem ShoppingItem { get; }
    public decimal Tax { get; }
    public decimal TotalPrice { get; }

    public BilledShoppingItem(ShoppingItem shoppingItem, decimal tax, decimal totalPrice)
    {
        ShoppingItem = shoppingItem;
        Tax = tax;
        TotalPrice = totalPrice;
    }

    
}