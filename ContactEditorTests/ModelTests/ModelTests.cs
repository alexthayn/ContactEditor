using Models;
using NUnit.Framework;

namespace ContactEditorTests
{
    [TestFixture]
    class ModelTests
    {
        private Contact contact;

        [SetUp]
        public void Setup()
        {
            contact = new Contact();
            contact.FirstName = "Hello";
            contact.LastName = "There";

        }
        
        [Test]
        public void FullNameTest()
        {
            Assert.AreEqual("Hello There", contact.FullName);
        }

        [Test] 
        public void FullNameWithNoLastNameTest()
        {
            contact.LastName = null;
            Assert.AreEqual("Hello ", contact.FullName);
        }
    }
}
