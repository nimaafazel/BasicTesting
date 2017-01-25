using BankAccountNS;
using NUnit.Framework;
using System;

namespace Bank.NUnitTest
{
    [TestFixture] // attribute to tell the compiler that this is a test class from NUnit and contains unit test methods to run in TestExplorer
    public class BankAccountNUnitTests
    {
        [Test]  // attribute required to be a NUnit test method
        public void Debit_WithValidAmount_UpdatesBalance2()
        {
            // arrange
            double begginingBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", begginingBalance);

            // act
            account.Debit(debitAmount);

            // assert
            double actual = account.Balance;
            Assert.That(actual, Is.EqualTo(expected));
            //Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }        
    }
}
