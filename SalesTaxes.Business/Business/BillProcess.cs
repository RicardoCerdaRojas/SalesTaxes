using SalesTaxes.Business.Data;
using SalesTaxes.Business.Interfaces;

namespace SalesTaxes.Business.POCOs;

public class BillProcess
{
    public ICartTaxCompute SalesCartTaxCompute { get; }

    public BillProcess(ICartTaxCompute salesTaxProcess)
    {
        SalesCartTaxCompute = salesTaxProcess;
    }
    
    public Reciept ProcessCart(List<ShoppingItem> shoppingCart)
    {
        var billedShoppingItems = new List<BilledShoppingItem>();
        decimal totalTaxForCart = 0;
        decimal totalBilledAmount = 0;
        int beforeID = 0;
        string beforeName = "";
        decimal beforePrice = 0;
        int countedItems = 0;
        bool beforeIsImport = false;
        string beforeDescription = "";
        ProductType beforeProductType = ProductType.Others;
        decimal taxForAllProducts = 0;
        decimal totalPrice = 0;
        decimal totalPriceAfterTax = 0;
        decimal individualTax = 0;
        ShoppingItem billedShoppingItem = new ShoppingItem();
        foreach (var shoppingItem in shoppingCart)
        {

            if (shoppingItem.Product.Id != beforeID && countedItems > 0)
            {
                //Acumulate prices 
                totalPrice = billedShoppingItem.Product.Price * countedItems;
                taxForAllProducts = SalesCartTaxCompute.ComputeTotalTax(billedShoppingItem.Product, totalPrice);
                totalPriceAfterTax = totalPrice + taxForAllProducts;
                totalTaxForCart += taxForAllProducts;
                totalBilledAmount += totalPriceAfterTax;
                
                BuildBilledShoppingItem(beforeID, 
                                        beforeName, 
                                        beforePrice,
                                        beforeIsImport,
                                        beforeProductType,
                                        countedItems,
                                        billedShoppingItems,
                                        taxForAllProducts,
                                        totalPriceAfterTax);

                totalPrice = 0;
                countedItems = 0;
            }
            // Set variables for grouping items 
            billedShoppingItem = shoppingItem;
            countedItems++;
            beforeName = shoppingItem.Product.Name;
            beforePrice = shoppingItem.Product.Price;
            beforeID = shoppingItem.Product.Id;
            beforeIsImport = shoppingItem.Product.IsImport;
            beforeProductType = shoppingItem.Product.ItemType;


        }
        //Acumulate prices 
        totalPrice = billedShoppingItem.Product.Price * countedItems;
        taxForAllProducts = SalesCartTaxCompute.ComputeTotalTax(billedShoppingItem.Product, totalPrice);
        totalPriceAfterTax = totalPrice + taxForAllProducts;
        totalTaxForCart += taxForAllProducts;
        //totalPriceAfterTax = Math.Round((totalPrice + taxForAllProducts), 1, MidpointRounding.ToPositiveInfinity);
        //totalTaxForCart += Math.Round(taxForAllProducts, 1, MidpointRounding.ToPositiveInfinity);
        totalBilledAmount += totalPriceAfterTax;
        
        BuildBilledShoppingItem(beforeID, 
            beforeName, 
            beforePrice,
            beforeIsImport,
            beforeProductType,
            countedItems,
            billedShoppingItems,
            taxForAllProducts,
            totalPriceAfterTax);
        
        return new Reciept(billedShoppingItems, totalBilledAmount, totalTaxForCart);
    }

    private void BuildBilledShoppingItem(int beforeID, string beforeName, decimal beforePrice,
                            bool beforeIsImport, ProductType beforeProductType, int countedItems, 
                            List<BilledShoppingItem> billedShoppingItems,
                            decimal taxForAllProducts, decimal totalPriceAfterTax)
    {
        string beforeDescription;
        ShoppingItem billedShoppingItem;
        Product billedProduct = new Product(beforeID, beforeName, beforePrice, beforeIsImport,
            beforeProductType);

        if (countedItems > 1)
            beforeDescription = String.Format("{0}: {1} ({2} @ {3})", beforeName,
                totalPriceAfterTax.ToString("#0.00"),
                countedItems,
                (totalPriceAfterTax / 2).ToString("#0.00"));
        else
            beforeDescription = String.Format("{0}: {1}", beforeName,
                totalPriceAfterTax.ToString("#0.00"));

        billedShoppingItem = new ShoppingItem(billedProduct, countedItems, beforeDescription);


        billedShoppingItems.Add(new BilledShoppingItem(billedShoppingItem, taxForAllProducts,
            totalPriceAfterTax));
        
    }
}