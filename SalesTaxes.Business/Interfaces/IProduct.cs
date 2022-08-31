using SalesTaxes.Business.POCOs;

namespace SalesTaxes.Business.Interfaces;

public interface IProduct
{
    
    public int Id { get; }
    string Name { get; }
    decimal Price { get; }
    bool IsImport { get; }
    ProductType ItemType { get; }    
}