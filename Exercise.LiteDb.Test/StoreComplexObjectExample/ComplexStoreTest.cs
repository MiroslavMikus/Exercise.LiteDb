using LiteDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.LiteDb.Test.StoreComplexObjectExample
{
    [TestClass]
    public class ComplexStoreTest
    {
        [TestMethod]
        public void TestStore()
        {
            using (var db = new LiteDatabase(@"SecondDatabase.db"))
            {
                var customer = db.GetCollection<ComplexCustomer>("customers");

                customer.Insert(new ComplexCustomer()
                {
                    Birthday = DateTime.Now,
                    IsNotActive = true,
                    Name = "Miro",
                    Address = new Address
                    {
                        City = "Oberaudorf",
                        Street = "Bahnhof"
                    }
                });
            }
        }
    }
}
