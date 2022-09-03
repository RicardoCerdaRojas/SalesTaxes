using SalesTaxes.Business.Data;

namespace SalesTaxes.Business.POCOs;

public class BilledShoppingItem
{
    public List<ShoppingItem> ShoppingItem { get; }
    public decimal TotalTax { get; }
    public decimal TotalPrice { get; }

    public BilledShoppingItem(List<ShoppingItem> shoppingItem, decimal totalTax, decimal totalPrice)
    {
        ShoppingItem = shoppingItem;
        TotalTax = totalTax;
        TotalPrice = totalPrice;
    }

    
}