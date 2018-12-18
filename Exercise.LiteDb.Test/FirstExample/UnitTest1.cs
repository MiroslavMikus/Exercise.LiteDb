using LiteDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise.LiteDb.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Example()
        {
            using (var db = new LiteDatabase(@"FirstDatabase.db"))
            {
                // Get customer collection
                var customers = db.GetCollection<Customer>("customers");

                // Create your new customer instance
                var customer = new Customer
                {
                    Name = "Miroslav Mikus",
                    Phones = new string[] { "8000-0000", "9000-0000" },
                    IsActive = true
                };

                // Insert new customer document (Id will be auto-incremented)
                customers.Insert(customer);

                // Update a document inside a collection
                customer.Name = "Joana Doe";

                customers.Update(customer);

                // Index document using a document property
                customers.EnsureIndex(x => x.Name);

                // Use Linq to query documents
                var results = customers.Find(x => x.Name.StartsWith("Jo"));
            }
        }
    }
}
