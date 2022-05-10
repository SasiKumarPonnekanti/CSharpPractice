using Microsoft.EntityFrameworkCore;
using EF_Core_2._0___New_Features.Models;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
try
{
    ManageDatabase();
    var person = new Person
    {
        FisrtName = "Sasi",
        MiddleName = "Kumar",
        LastName = "Ponnekanti",
        Address = "Guntur-Andhra"
    };

    person.SetEmail("sasi@somemail.com");
    person.SetContactNo("6331238000");

    var db = new personInfoDbContext();
    db.Persons.Add(person);
    db.SaveChanges();
    var persons = db.Persons.ToListAsync().Result;
    foreach (var item in persons)
    {
        Console.WriteLine($" Person Details {item.FisrtName} {item.MiddleName} {item.LastName} {item.Address} {item.GetEmail()} {item.GetContact()}");
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.ReadLine();

 
static void ManageDatabase()
{

    using (var ctx = new personInfoDbContext())
    {
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();
    }
}