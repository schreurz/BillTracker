using System;
using Xunit;

namespace BillTracker.Tests
{
    public class BillTests
    {
        [Fact]
        public void BillHasCorrectBalance()
        {
            var bill = GetBill(123.45, new DateTime(2019, 8, 23));

            var expected = 123.45;

            var actual = bill.GetBalance();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BillHasCorrectDueDate()
        {
            var bill = GetBill(123.45, new DateTime(2019, 8, 23));

            var expected = new DateTime(2019, 8, 23);

            var actual = bill.GetDueDate();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BillCreatedWithPayee()
        {
            var bill = GetBill(123.45, new DateTime(2019, 8, 23), "Consumers");

            var expected = "Consumers";

            var actual = bill.GetPayee();

            Assert.Equal(expected, actual);
        }

        Bill GetBill(double balance, DateTime dueDate, string payee=null)
        {
            return Bill.From(balance, dueDate, payee);
        }
    }
}
