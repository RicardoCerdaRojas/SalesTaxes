using Xunit;
using SalesTaxes.Business.Data;
using SalesTaxes.Business.POCOs;

namespace SalesTaxes.Test;

public class SalesTaxesShould
{
    private CartTaxCompute _taxCompute = new CartTaxCompute(new DataTaxes(0.10m, 0.050m));

    #region Test Cases Scenarios
    [Fact]
    public void Scenario1()
    {
        //Arrange
        
        //Input
        List<ShoppingItem> shoppingItems = new List<ShoppingItem>()
        {
            new ShoppingItem( new Product(1,"Book", 12.49m, false, ProductType.Book),
                2),
            new ShoppingItem( new Product(3, "Music CD",14.99m, false, ProductType.Music),
                1),
            new ShoppingItem( new Product(2, "Chocolate bar", 0.85m, false, ProductType.Food),
                1)
        };
        
        //expected bill
        List<string> expected = new List<string>()
        {
            new string("Book: 24,98 (2 @ 12,49)"),
            new string("Music CD: 16,49"),
            new string("Chocolate bar: 0,85"),
            new string("Sales Taxes: 1,50"),
            new string("Total: 42,32")
        };

        //Acts
        var process = new BillProcess(_taxCompute);
        var receipt = process.ProcessCart2(shoppingItems);
        List<string> actual = receipt.GetBillItems();

        //Asserts
        Assert.Equal(expected, actual);

    }
    [Fact]
    public void Scenario2() 
    {
        //Arrange
        //Input
        List<ShoppingItem> shoppingItems = new List<ShoppingItem>()
        {
            new ShoppingItem( new Product(4, "Imported box of chocolates", 10.00m, true, ProductType.Food),
                1),
            new ShoppingItem( new Product(5, "Imported bottle of perfume", 47.50m, true, ProductType.Perfum),
                1)
        };
        
        //expected bill
        List<string> expected = new List<string>()
        {
            new string("Imported box of chocolates: 10,50"),
            new string("Imported bottle of perfume: 54,65"),
            new string("Sales Taxes: 7,65"),
            new string("Total: 65,15")
        };

        //Acts
        var process = new BillProcess(_taxCompute);
        var receipt = process.ProcessCart2(shoppingItems);
        List<string> actual = receipt.GetBillItems();

        //Asserts
        Assert.Equal(expected, actual);

    }
    [Fact]
    public void Scenario3()
    {
        //Arrange
        //Input
        List<ShoppingItem> shoppingItems = new List<ShoppingItem>()
        {
            new ShoppingItem(new Product(6, "Imported bottle of perfume", 27.99m, true, ProductType.Perfum),
                1),
            new ShoppingItem(new Product(7, "Bottle of perfume", 18.99m, false, ProductType.Perfum),
                1),
            new ShoppingItem(new Product(8, "Packet of headache pills", 9.75m, false, ProductType.Medicine),
                1),
            new ShoppingItem(new Product(9, "Imported box of chocolates", 11.25m, true, ProductType.Food),
                2)
        };
        
        //expected bill
        List<string> expected = new List<string>()
        {
            new string("Imported bottle of perfume: 32,19"),
            new string("Bottle of perfume: 20,89"),
            new string("Packet of headache pills: 9,75"),
            new string("Imported box of chocolates: 23,70 (2 @ 11,85)"),
            new string("Sales Taxes: 7,30"),
            new string("Total: 86,53")
        };

        //Acts
        var process = new BillProcess(_taxCompute);
        var receipt = process.ProcessCart2(shoppingItems);
        List<string> actual = receipt.GetBillItems();

        //Asserts
        Assert.Equal(expected, actual);

    }
    
    #endregion
    
}