using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise.LiteDb.Test2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test()
        {
            using (var db = new LiteDatabase("FileDb.db"))
            {
                // Upload a file from file system
                db.FileStore.Upload("/my/file-id", @"C:\Temp\picture1.jgn");

                // Upload a file from Stream
                db.FileStore.Upload("/my/file-id", myStream);

                // Open as an stream
                var stream = db.FileStore.OpenRead("/my/file-id");

                // Write to another stream
                stream.CopyTo(Response.Output);
            }
        }
    }
}
