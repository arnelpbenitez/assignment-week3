using EntityModels.Models;
using Microsoft.EntityFrameworkCore;
using Week3EntityFramework.Dtos;

var context = new IndustryConnectWeek2Context();

//var customer = new Customer
//{
//    DateOfBirth = DateTime.Now.AddYears(-20)
//};


//Console.WriteLine("Please enter the customer firstname?");

//customer.FirstName = Console.ReadLine();

//Console.WriteLine("Please enter the customer lastname?");

//customer.LastName = Console.ReadLine();


//var customers = context.Customers.ToList();

//foreach (Customer c in customers)
//{   
//    Console.WriteLine("Hello I'm " + c.FirstName);
//}

//Console.WriteLine($"Your new customer is {customer.FirstName} {customer.LastName}");

//Console.WriteLine("Do you want to save this customer to the database?");

//var response = Console.ReadLine();

//if (response?.ToLower() == "y")
//{
//    context.Customers.Add(customer);
//    context.SaveChanges();
//}



// var sales = context.Sales.Include(c => c.Customer)
//     .Include(p => p.Product).ToList();

// var salesDto = new List<SaleDto>();

// foreach (Sale s in sales)
// {
//     salesDto.Add(new SaleDto(s));
// }



//context.Sales.Add(new Sale
//{
//    ProductId = 1,
//    CustomerId = 1,
//    StoreId = 1,
//    DateSold = DateTime.Now
//});


//context.SaveChanges();




// Console.WriteLine("Which customer record would you like to update?");

// var response = Convert.ToInt32(Console.ReadLine());

// var customer = context.Customers.Include(s => s.Sales)
//     .ThenInclude(p => p.Product)
//     .FirstOrDefault(c => c.Id == response);


// var total = customer.Sales.Select(s => s.Product.Price).Sum();


// var customerSales = context.CustomerSales.ToList();

//var totalsales = customer.Sales



//Console.WriteLine($"The customer you have retrieved is {customer?.FirstName} {customer?.LastName}");

//Console.WriteLine($"Would you like to updated the firstname? y/n");

//var updateResponse = Console.ReadLine();

//if (updateResponse?.ToLower() == "y")
//{

//    Console.WriteLine($"Please enter the new name");

//    customer.FirstName = Console.ReadLine();
//    context.Customers.Add(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//    context.SaveChanges();
//}

// Console.ReadLine();

// Task Week 3
// 1. Using the linq queries retrieve a list of all customers from the database who don't have sales
var customers = context.Customers.Where(customer => !context.Sales.Any (s => s.CustomerId == customer.Id)).ToList();

Console.WriteLine("=========================================================");
Console.WriteLine("Week 3 Tasks\n\n");

Console.WriteLine("1) Using the linq queries retrieve a list of all customers from the database who don't have sales:");
foreach(Customer c in customers)
{
	Console.WriteLine(c.FirstName + ' ' + c.LastName) ;
}

// 2. Insert a new customer with a sale record
// 2a. New customer
Console.WriteLine("\n2) Insert a new customer with a sale record");
Console.WriteLine("Please enter the new Customer First Name:");
var customer = new Customer
{
	FirstName = Console.ReadLine()
};

Console.WriteLine("Please enter the new Customer Last Name:");
customer.LastName = Console.ReadLine();
Console.WriteLine("Please enter the new Customer Birthday (dd/MM/yyyy):");
var dob = Console.ReadLine();
DateTime dt;
while (!DateTime.TryParseExact(dob, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
{
    Console.WriteLine("Invalid date, please retry");
    dob = Console.ReadLine();
}
customer.DateOfBirth = dt;
context.Customers.Add(customer);
context.SaveChanges();

Console.WriteLine("Please enter the product id bought");
var productID = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Please enter the store id where the product was bought:");
var storeID = Convert.ToInt32(Console.ReadLine());

// 2b. new sale
var  sale = new Sale 
{
	CustomerId = customer.Id,
	ProductId = productID,
	DateSold = DateTime.Now,
	StoreId = storeID
};
context.Sales.Add(sale);
context.SaveChanges();

// 3. Add a new store 
Console.WriteLine("\n3) Add a new store");
Console.WriteLine("Please enter store name:");
var store = new Store
{
	Name = Console.ReadLine() ?? ""
};

Console.WriteLine("Please enter store location:");
store.Location = Console.ReadLine();
context.Stores.Add(store);
context.SaveChanges();

// 4. Find the list of all stores that have sales
Console.WriteLine("\n4) Find the list of all stores that have sales");
var stores =  context.Stores.Where(store => context.Sales.Any(s => s.StoreId == store.Id)).ToList();
Console.WriteLine("List of stores that have sales:");
foreach(Store s in stores)
{
	Console.WriteLine(s.Name ) ;
}





