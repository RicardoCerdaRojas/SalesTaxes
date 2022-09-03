using System.Reflection.Metadata;
using SalesTaxes.Business.Interfaces;
using SalesTaxes.Business.POCOs;

namespace SalesTaxes.Business.Data;

public class ShoppingItem
{
    public long Id { get; }
    public IProduct Product { get; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Totaltax { get; set; }

    public ShoppingItem()
    {
    }    
    public ShoppingItem(IProduct product, int quantity)
    {
        Id = DateTime.Now.Ticks;
        Product = product;
        Quantity = quantity;
        TotalPrice = product.Price * quantity;
        Description = "";
        Totaltax = 0;

    }    
}