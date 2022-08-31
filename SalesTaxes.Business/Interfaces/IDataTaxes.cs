namespace SalesTaxes.Business.Interfaces;

public interface IDataTaxes
{
    public decimal SalesTaxes { get; }
    public decimal ImportDuty { get; }
}