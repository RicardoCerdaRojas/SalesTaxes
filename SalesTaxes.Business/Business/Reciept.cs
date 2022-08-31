using SalesTaxes.Business.Data;

namespace SalesTaxes.Business.POCOs;

public class Reciept
{
    public List<BilledShoppingItem> ProcessedShoppingCart { get; }
    public decimal TotalBillAmount { get; }
    public decimal TotalSalesTax { get; }
    public Reciept(List<BilledShoppingItem> processedShoppingCart, decimal totalBillAmount, decimal totalSalesTax)
    {
        ProcessedShoppingCart = processedShoppingCart;
        TotalBillAmount = totalBillAmount;
        TotalSalesTax = totalSalesTax;
    }

    public void PrintBill()
    {
        foreach (var processedItem in ProcessedShoppingCart)
        {
            Console.WriteLine(String.Format("{0}", processedItem.ShoppingItem.Description));
        }
        Console.WriteLine($"Sales Taxes {TotalSalesTax.ToString("##.00")}");
        Console.WriteLine($"Total {TotalBillAmount.ToString("##.00")}");
    }

}
