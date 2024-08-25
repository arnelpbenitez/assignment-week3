# Week 3

Week 3 Software developer intern (Entity Framework)

1. Using the linq queries retrieve a list of all customers from the database who don't have sales

2. Insert a new customer with a sale record

3. Add a new store 

4. Find the list of all stores that have sales 

Command line syntax

dotnet-ef dbcontext scaffold "Server=localhost;Initial Catalog=IndustryConnectWeek2;Integrated Security=True;TrustServerCertificate=Yes" Microsoft.EntityFrameworkCore.SqlServer -o Models -f



Week 3 Tasks Test


1) Using the linq queries retrieve a list of all customers from the database who don't have sales:
Abigail Smith
Jenny Jones
Joey Kang

2) Insert a new customer with a sale record
Please enter the new Customer First Name:
John 
Please enter the new Customer Last Name:
Dow
Please enter the new Customer Birthday (dd/MM/yyyy):
08/12/2001
Please enter the product id bought
1
Please enter the store id where the product was bought:
1

3) Add a new store
Please enter store name:
My Store
Please enter store location:
Melbourne

4) Find the list of all stores that have sales
List of stores that have sales:
Syndey
