using SalesTaxes.Business.Data;

namespace SalesTaxes.Business.POCOs;

public class Reciept
{
    public List<ShoppingItem> ProcessedShoppingCart { get; }
    public decimal TotalBillAmount { get; }
    public decimal TotalSalesTax { get; }
    public Reciept(List<ShoppingItem> processedShoppingCart, decimal totalBillAmount, decimal totalSalesTax)
    {
        ProcessedShoppingCart = processedShoppingCart;
        TotalBillAmount = totalBillAmount;
        TotalSalesTax = totalSalesTax;
    }
    public List<string> GetBillItems()
    {
        List<string> billItems = new List<string>();
        try
        {
            foreach (var processedItem in ProcessedShoppingCart)
            {
                billItems.Add(String.Format("{0}", processedItem.Description));
            }
            billItems.Add($"Sales Taxes: {TotalSalesTax.ToString("#0.00")}");
            billItems.Add($"Total: {TotalBillAmount.ToString("#0.00")}");

            return billItems;

        }
        catch (Exception e)
        {
            billItems.Add(e.Message);
            return new List<string>(billItems);
        }
    }
    

}
