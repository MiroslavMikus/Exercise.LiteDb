using LiteDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Exercise.LiteDb.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExampleInsert()
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
                    //IsActive = true
                };

                // Insert new customer document (Id will be auto-incremented)
                customers.Insert(customer);

                // Update a document inside a collection
                customer.Name = "Joana Doe";

                customers.Update(customer);

                // Index document using a document property
                customers.EnsureIndex(x => x.Name);

                //Use Linq to query documents
               var results = customers.Find(x => x.Name.StartsWith("Jo"));
            }
        }

        [TestMethod]
        public void ExampleUpdate()
        {
            using (var db = new LiteDatabase(@"FirstDatabase.db"))
            {
                var customer = db.GetCollection<Customer>("customers");

                var joanna = customer.Find(a => a.Id == 1).FirstOrDefault();

                joanna.IsNotActive = true;

                customer.Update(joanna);
            }

            using (var db = new LiteDatabase(@"FirstDatabase.db"))
            {
                var customer = db.GetCollection<Customer>("customers");

                var joanna = customer.Find(a => a.Id == 1).FirstOrDefault();
            }
        }
    }
}
