using SalesTaxes.Business.POCOs;

namespace SalesTaxes.Business.Interfaces;

public interface IDBProducts
{
    public List<Product> GetProducts();
    public DataTaxes GetDataTaxes();
}