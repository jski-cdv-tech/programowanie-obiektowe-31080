// Exercise from first PDF file
/*const int requiredAge = 16;
const int beerRequiredAge = 18;
const int simRequiredAge = 14;
const string accessDenied = "You must be at least 16 years old";
const string accessAllowed = "Welcome to our shop";
const string beerRestrictionMessage = "You must be at least 18 years old to buy a beer";
const string accessAllowedExceptSim = "Welcome to our shop, but don't register SIM cards";

int age = 13;

if (age >= beerRequiredAge)
{
    Console.WriteLine(beerRestrictionMessage);
}
else if (age >= requiredAge)
{
    Console.WriteLine(accessDenied);
}
else if (age >= simRequiredAge)
{
    Console.WriteLine(accessAllowed);
}
else
{
    Console.WriteLine(accessAllowedExceptSim);
}*/

// Exercise 1 from second PDF file
/*const string correctPassword = "admin123";
string password;
do
{
    Console.Write("Enter password: ");
    password = Console.ReadLine();
} while (password != correctPassword);
Console.WriteLine("Logged in successfully");*/

// Exercise 2 from second PDF file
/*int number;
do
{
    Console.Write("Write number greater than zero: ");
    number = int.Parse(Console.ReadLine());
} while (number <= 0);
Console.WriteLine($"Yes, number {number} is greater than zero");*/

// Exercise 3 from second PDF file
string[] cities = { "Poznań", "Warszawa", "Gdańsk", "Leszno", "Opole" };
foreach (var city in cities) {
    Console.WriteLine(city);
}