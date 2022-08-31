using SalesTaxes.Business.Interfaces;

namespace SalesTaxes.Business.POCOs;

public class DataTaxes: IDataTaxes
{
    public decimal SalesTaxes { get; }
    public decimal ImportDuty { get; }

    public DataTaxes(decimal salesTaxes, decimal importDuty)
    {
        SalesTaxes = salesTaxes;
        ImportDuty = importDuty;
    }
}