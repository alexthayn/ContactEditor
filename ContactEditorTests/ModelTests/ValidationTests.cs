using NUnit.Framework;
using Models;

namespace ContactEditorTests
{
    [TestFixture]
    class ValidationTests
    {
        Contact contact;

        [SetUp]
        public void Setup()
        {
            contact = new Contact();
        }

        [Test]
        public void TestFirstNameValidationWithValidName()
        {
            contact.FirstName = "SpongeBob";

            Assert.AreEqual(contact[nameof(contact.FirstName)], null);
        }

        [Test]
        public void TestFirstNameValidationWithInvalidName()
        {
            contact.FirstName = "SpongeBob Squarepants";

            Assert.AreEqual(contact[nameof(contact.FirstName)], "First name must be valid with no extra whitespace.");
        }

        [Test]
        public void TestLastNameValidationWithValidName()
        {
            contact.LastName = "Squarepants";

            Assert.AreEqual(contact[nameof(contact.LastName)], null);
        }

        [Test]
        public void TestLastNameValidationWithInvalidName()
        {
            contact.LastName = "sQUARE PANTS";

            Assert.AreEqual(contact[nameof(contact.LastName)], "Last name must be valid with no extra whitespace.");
        }

        [Test]
        public void TestAgeValidationWithValidAge()
        {
            contact.Birthday = new System.DateTime(2001,12,12);

            Assert.AreEqual(contact[nameof(contact.Birthday)], null);
        }

        [Test]
        public void TestAgeValidationWithInvalidAge()
        {
            contact.Birthday = new System.DateTime(0001,12,12);

            Assert.AreEqual(contact[nameof(contact.Birthday)], "Please enter a valid birthdate between now and the last 150 years.");
        }

        [Test]
        public void TestEmailValidationWithValidEmail()
        {
            contact.Email = "alex@email.com";

            Assert.AreEqual(contact[nameof(contact.Email)], null);
        }

        [Test]
        public void TestEmailValicationWithInvalidEmail()
        {
            contact.Email = "not an email";

            Assert.AreEqual(contact[nameof(contact.Email)], "Please enter a valid email of the form myemail@email.com");
        }
    }
}
