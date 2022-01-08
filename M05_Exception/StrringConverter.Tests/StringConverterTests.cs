namespace StringConverter.Tests
{
    using System;
    using NUnit.Framework;

    public class StringConverterTests
    {
        [Test]
        public void DoIt_simpletext_Number()
        {
            string text = "simple1234567890text";
            int expected = 1234567890;
            Assert.That(StringConverter.DoIt(text), Is.EqualTo(expected));
        }

        [Test]
        public void DoIt_spacedtext_Number()
        {
            string text = "simple 1234 5678 90 text ";
            int expected = 1234567890;
            Assert.That(StringConverter.DoIt(text), Is.EqualTo(expected));
        }

        [Test]
        public void DoIt_OverFlowedText_OverflowException()
        {
            string text = "123456789123456789";
            Assert.Throws(typeof(OverflowException), () => StringConverter.DoIt(text), "Not expected");
        }

        [Test]
        public void DoIt_negativeNumberedText_number()
        {
            string text = "-123456789";
            int expected = -123456789;
            Assert.AreEqual(StringConverter.DoIt(text), expected);
        }

        [Test]
        public void DoItError_NotNegativeNumberedText_NegativeNumber()
        {
            string text = "123-45678";
            int expected = -12345678;
            Assert.AreEqual(StringConverter.DoIt(text), expected);
        }

        [Test]
        public void DoIt_DifficultText_Number()
        {
            string text = "dif#f-ic  ult12345678-text";
            int expected = 12345678;
            Assert.AreEqual(StringConverter.DoIt(text), expected);
        }

        [Test]
        public void DoIt_DifficultTextWithNegativeNumber_Number()
        {
            string text = "dif#f-ic  ult-12345678-text";
            int expected = -12345678;
            Assert.AreEqual(StringConverter.DoIt(text), expected);
        }
    }
}