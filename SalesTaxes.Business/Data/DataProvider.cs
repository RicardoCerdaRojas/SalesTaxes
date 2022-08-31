using SalesTaxes.Business.Interfaces;
using SalesTaxes.Business.POCOs;

namespace SalesTaxes.Business.Data;

public class DataProvider
{
    private IDBProducts _dbProducts;

    public DataProvider(IDBProducts dbProducts)
    {
        _dbProducts = dbProducts;
    }

    public List<Product> GetProducts()
    {
        return _dbProducts.GetProducts();
    }

    public DataTaxes GetDataTaxes()
    {
        return _dbProducts.GetDataTaxes();
    }
}