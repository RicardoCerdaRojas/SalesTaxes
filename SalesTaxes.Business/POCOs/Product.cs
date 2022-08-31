using SalesTaxes.Business.Interfaces;
namespace SalesTaxes.Business.POCOs;

public class Product : IProduct
{
    public int Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    public bool IsImport { get; }
    public ProductType ItemType { get; }

    public Product(int id, string name, decimal price, bool isImport, ProductType  itemType)
    {
        Id = id;
        Name = name;
        Price = price;
        IsImport = isImport;
        ItemType = itemType;
    }

    
}