using SalesTaxes.Business.Data;
using SalesTaxes.Business.POCOs;

Console.ForegroundColor = ConsoleColor.DarkCyan;

DBProducts dbProducts = new DBProducts();
DataProvider dataProvider = new DataProvider(dbProducts);
bool showMenu = true;
List<ShoppingItem> shoppingItems = new List<ShoppingItem>();

while (showMenu)
{
    showMenu = MainMenu();
}

bool MainMenu()
{
    Console.Clear();
    Console.Title = "Sales Taxes App";
    Console.WriteLine("Welcome to SalesTaxes App!");
    Console.WriteLine("##########################");
    Console.WriteLine("Products in Cart [{0}]: ", shoppingItems.Count);
    Console.WriteLine("");
    Console.WriteLine("Choose an option:");
    Console.WriteLine("[1] Scan Products");
    Console.WriteLine("[2] Show items in the cart");
    Console.WriteLine("[3] Checkout Receipt");
    Console.WriteLine("[0] Exit");

    Console.Write("\r\nSelect an option: ");
 
    switch (Console.ReadLine())
    {
        case "1":
            ScanItems();
            return true;
        case "2":
            DisplayCart();
            return true;
        case "3":
            CheckOutReceipt();
            return true;
        case "0":
            return false;
        default:
            return true;
    }
}
 
void ScanItems()
{
    string scanItems = "";
    string option = "";

    
    Console.Clear();
    while (option != "0")
    {
        var products = dataProvider.GetProducts();
        int index = 1;
        Console.Write("\r\n");
        foreach (Product product in products)
        {
            Console.WriteLine("{0}) {1} [{2}]", index, product.Name, product.Price);
            index++;
        }

        if (option != "0" && option != "")
        {
            var addedproduct = products[Convert.ToInt32(option) -1 ];
            shoppingItems.Add(new ShoppingItem(addedproduct, 1, addedproduct.Name));
        }
        Console.Write("0) To go back");
        Console.WriteLine("");
        
        Console.WriteLine("####################################################");
        Console.Write("Products in Cart [{0}]: ", shoppingItems.Count);
        option = Console.ReadLine();
        Console.Clear();
        
    }
}
 
void DisplayCart()
{
    Console.Clear();
    Console.WriteLine("\r\nItems in the Cart");
    Console.WriteLine("####################################################");
    Console.WriteLine("");

    int index = 1;
    foreach (ShoppingItem items in shoppingItems)
    {
        Console.WriteLine("{0}) {1} [{2}] x [{3}]", index, items.Product.Name, items.Product.Price, items.Quantity);
        index++;
    }
    Console.WriteLine("");
    Console.WriteLine("####################################################");
    Console.WriteLine("");
    Console.Write("Press Enter to return to Main Menu");
    Console.ReadLine();
}

void CheckOutReceipt()
{
    Console.Clear();
    Console.WriteLine("\r\nItems in the Cart");
    Console.WriteLine("####################################################");
    Console.WriteLine("");

    var taxCompute = new CartTaxCompute(dbProducts.GetDataTaxes());
    var process = new BillProcess(taxCompute);
    var receipt = process.ProcessCart(shoppingItems);
    receipt.PrintBill();
    
    
    
    // int index = 1;
    // foreach (ShoppingItem items in shoppingItems)
    // {
    //     Console.WriteLine("{0}) {1} [{2}] x [{3}]", index, items.Product.Name, items.Product.Price, items.Quantity);
    //     index++;
    // }
    Console.WriteLine("");
    Console.WriteLine("####################################################");

    
    
    Console.WriteLine("");
    Console.Write("Press Enter to return to Main Menu");
    Console.ReadLine();
    shoppingItems = new List<ShoppingItem>();
 
}


