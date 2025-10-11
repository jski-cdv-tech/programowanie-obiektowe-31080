const int requiredAge = 16;
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
}