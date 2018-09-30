using System;
using System.Globalization;
using System.Windows;
using ContactEditor.Converters;
using Moq;
using NUnit.Framework;

namespace ContactEditorTests.ConverterTests
{
    [TestFixture]
    class BooleanToVisibilityConverterTest
    {
        private BooleanToVisibilityConverter converter;

        [SetUp]
        public void Setup()
        {
            converter = new BooleanToVisibilityConverter();
        }

        [Test]
        public void ConvertToVisibleTest()
        {
            Object result = converter.Convert(true, new Mock<Type>().Object, new Mock<object>().Object, new CultureInfo("en-US"));

            Assert.AreEqual(Visibility.Visible, result);
        }

        [Test]
        public void ConvertToCollapsedTest()
        {
            Object result = converter.Convert(false, new Mock<Type>().Object, new Mock<object>().Object, new CultureInfo("en-US"));

            Assert.AreEqual(Visibility.Collapsed, result);
        }
        
    }
}
