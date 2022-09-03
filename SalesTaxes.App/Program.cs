using System.Runtime.InteropServices.ComTypes;
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
    Console.WriteLine("Insert a product!");
    Console.WriteLine("##########################");
    while (option != "0")
    {
        Console.WriteLine("\r\nItems in the Cart");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("");

        int index = 1;
        foreach (ShoppingItem items in shoppingItems)
        {
            Console.WriteLine("{0}) {1} [{2}] x [{3}]", index, items.Product.Name, items.Product.Price, items.Quantity);
            index++;
        }
        Console.WriteLine("");
        Console.WriteLine("Number of items [{0}]: ", shoppingItems.Count);
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("");
        Console.Write("Press any button to add product (0: Go back) ");
        option = Console.ReadLine();

        if (option != "0")
            InsertCustomProduct();

        Console.Clear();
        
    }
}

void InsertCustomProduct()
{
    bool success;
    string input = "";
    string name;
    decimal price;
    bool isImported;
    int quantity;
    ProductType inputProductType;
    
    Console.Clear();
    Console.WriteLine("");
    Console.WriteLine("Add a custom product");
    Console.WriteLine("#########################");
    Console.WriteLine("");
    //Adding Name Product
    Console.Write("Enter name: ");
    name = Console.ReadLine();

    //Adding Price Product
    Console.Write("Enter price: ");
    success = decimal.TryParse(Console.ReadLine(), out price);
    while (!success)
    {
        Console.WriteLine("Invalid price. Try again...");
        Console.Write("Please price: ");
        success = decimal.TryParse(Console.ReadLine(), out price);
    }    
    
    //Adding Imported flag
    Console.Write("The product is imported (Y/N): ");
    input = Console.ReadLine();
    isImported = false;
    if (input.ToUpper() != "Y" && input.ToUpper() != "N")
        isImported = true;
    while (isImported)
    {
        Console.WriteLine("Invalid answer. Try again...");
        Console.Write("The product is imported (Y/N): ");
        input = Console.ReadLine();
        isImported = false;
        if (input.ToUpper() != "Y" && input.ToUpper() != "N")
            isImported = true;
    }
    isImported = input.ToUpper() == "Y" ? true : false;
    
    // Adding Product Type
    string[] operators = new[] { "Book", "Food", "Medicine", "Perfum", "Music", "Other" };
    string prompt = $"Please enter your product type ({string.Join(", ", operators)}): ";
    Console.Write(prompt);
    while (!operators.Contains(input = Console.ReadLine()))
    {
        Console.WriteLine("Invalid product type. Try Again...");
        Console.Write(prompt);
    }

    inputProductType = (input == "Book") ? ProductType.Book: 0;
    inputProductType = (input == "Food") ? ProductType.Food: inputProductType;
    inputProductType = (input == "Medicine") ? ProductType.Medicine: inputProductType;
    inputProductType = (input == "Perfum") ? ProductType.Perfum: inputProductType;
    inputProductType = (input == "Music") ? ProductType.Music: inputProductType;
    inputProductType = (input == "Other") ? ProductType.Others: inputProductType;

    //Adding number of product to shop
    Console.Write("How many? : ");
    success = int.TryParse(Console.ReadLine(), out quantity);
    while (!success)
    {
        Console.WriteLine("Invalid quantity. Try again...");
        Console.Write("How many?: ");
        success = int.TryParse(Console.ReadLine(), out quantity);
    }    

    
    //Create product and add to the cart
    Product newProduct = new Product(0, name, price, isImported, inputProductType);
    shoppingItems.Add(new ShoppingItem(newProduct, quantity));
    
    Console.Clear();


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
    var receipt = process.ProcessCart2(shoppingItems);
    List<string> listbill = receipt.GetBillItems();
    foreach (string lineReciept in listbill)
    {
        Console.WriteLine(lineReciept);
    }
    Console.WriteLine("");
    Console.WriteLine("####################################################");
    Console.WriteLine("");
    Console.Write("Press Enter to return to Main Menu");
    Console.ReadLine();
    shoppingItems = new List<ShoppingItem>();
 
}


