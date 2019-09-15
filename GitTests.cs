using System;
using NUnit.Framework;

namespace GitTask
{
    [TestFixture]
    public class GitTests
    {
        private const int DefaultFilesCount = 5;
        private Git sut;

        [SetUp]
        public void SetUp()
        {
            sut = new Git(DefaultFilesCount);
        }

        [Test]
        public void YouTried()
        {
            
            sut.Update(0, 6);
            sut.Update(0, 5);
            sut.Commit();
            sut.Update(0, 7);
            
            Assert.AreEqual(5,sut.Checkout(0, 0));
        }
        

    }
}