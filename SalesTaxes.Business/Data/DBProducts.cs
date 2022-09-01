using SalesTaxes.Business.Interfaces;
using SalesTaxes.Business.POCOs;

namespace SalesTaxes.Business.Data;

public class DBProducts : IDBProducts
{
    public List<Product> GetProducts()
    {
        var products = new List<Product>()
        {
            new Product(1,"Book", 12.49m, false, ProductType.Book),
            new Product(2, "Chocolate bar", 0.85m, false, ProductType.Food),
            new Product(3, "Music CD",14.99m, false, ProductType.Music),
            new Product(4, "Imported box of chocolates", 10.00m, true, ProductType.Food),
            new Product(5, "Imported bottle of perfume", 47.50m, true, ProductType.Perfum),
            new Product(6, "Imported bottle of perfume", 27.99m, true, ProductType.Perfum),
            new Product(7, "bottle of perfume", 18.99m, false, ProductType.Perfum),
            new Product(8, "Packet of headache pills", 9.75m, false, ProductType.Medicine),
            new Product(9, "Imported box of chocolates", 11.25m, true, ProductType.Food)
        };
        return products;
    }

    public DataTaxes GetDataTaxes()
    {
        DataTaxes dataTaxes = new(0.10m, 0.050m);
        return dataTaxes;
    }

    private decimal ToDecimal(double number)
    {
        return Convert.ToDecimal(number);
    }
}