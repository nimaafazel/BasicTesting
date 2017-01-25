using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTest
{
    [TestClass]  // attribute to tell the compiler that this is a test class and contains unit test methods to run in TestExplorer
    public class BankAccountTests
    {
        /// <summary>
        /// Test Method requirements
        /// 1.- Decorated with the TestMethod Attribute
        /// 2.- Return void
        /// 3.- Cannot have parameters.
        /// </summary>
        [TestMethod]  // attribute required to be a test method
        public void TestMethod1()
        {
        }

        /// <summary>
        /// Tests Debit method.
        /// Specifically that the balance updates corrrectly.
        /// </summary>
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
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
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        /// <summary>
        /// Tests Debit method.
        /// Specifically when amount is less than zero, which should throw an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]  // we use this attribute to assert a specific exception, in this case, ArgumentOutOfRangeException
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange
            double begginingBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", begginingBalance);

            // act
            account.Debit(debitAmount);

            // assert is handled by attribute ExpectedException
        }

        ///// <summary>
        ///// Tests Debit method.
        ///// Specifically when the debit amount is bigger than the balance, which should throw an ArgumentOutOfRangeException.
        ///// </summary>
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        //public void Debit_WhenAmountIsBiggerThanBalance_ShouldThrowArgumentOutOfRange()
        //{
        //    // arrange
        //    double begginingBalance = 44.56;
        //    double debitAmount = 45.00;
        //    BankAccount account = new BankAccount("Mr. Bryan Walton", begginingBalance);

        //    // act
        //    account.Debit(debitAmount);

        //    // assert is handled by attribute ExpectedException
        //}

        /// <summary>
        /// Tests Debit method.
        /// Specifically when the debit amount is bigger than the balance, which should throw an ArgumentOutOfRangeException with the message from
        /// our const DebitAmountExceedsBalanceMessage.
        /// </summary>
        [TestMethod]        
        public void Debit_WhenAmountIsBiggerThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // arrange
            double begginingBalance = 44.56;
            double debitAmount = 45.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", begginingBalance);

            // act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown");  // we use this method to intentionallly fail a test. In this case, we want to know if we didn't get an exception.
        }
    }
}
