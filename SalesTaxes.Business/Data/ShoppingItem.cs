using SalesTaxes.Business.Interfaces;

namespace SalesTaxes.Business.Data;

public class ShoppingItem
{
    public long Id { get; }
    public IProduct Product { get; }
    public int Quantity { get; set; }
    public string Description { get; set; }

    public ShoppingItem()
    {
    }    
    public ShoppingItem(IProduct product, int quantity, string description)
    {
        Id = DateTime.Now.Ticks;
        Product = product;
        Quantity = quantity;
        Description = description;
    }    
}