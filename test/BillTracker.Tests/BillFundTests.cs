using System;
using Xunit;

namespace BillTracker.Tests
{
    public class BillFundTests
    {
        [Fact]
        public void CreatedWithCorrectTitle()
        {
            BillFund fund = GetBillFund("Test");

            var expected = "Test";

            var actual = fund.Title;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StartingBalanceIsZero()
        {
            BillFund fund = GetBillFund("Test");

            double expected = 0;

            var actual = fund.Balance;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BalanceCorrectAfterDeposits()
        {
            BillFund fund = GetBillFund("Test");

            fund.DepositFunds(100);
            fund.DepositFunds(32);
            fund.DepositFunds(32.5);

            var expected = 100 + 32 + 32.5;

            var actual = fund.Balance;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DepositNegativeAmountThrowsArgumentException()
        {
            BillFund fund = GetBillFund("Test");

            Assert.Throws<ArgumentException>(() => fund.DepositFunds(-100));
        }

        [Fact]
        public void PayNextBillRemovesFunds()
        {
            BillFund fund = GetBillFund("Test");

            Bill bill = Bill.From(100, new DateTime(2019, 08, 23));

            fund.AddBill(bill);

            fund.DepositFunds(100);

            fund.PayNextBill();

            Assert.Equal(0, fund.Balance);
        }

        [Fact]
        public void BillsAreOrderedByDate()
        {
            BillFund fund = GetBillFund("Test");
            Bill bill = Bill.From(100, new DateTime(2019, 08, 23));
            Bill bill2 = Bill.From(101, new DateTime(2019, 07, 28));
            fund.AddBill(bill);
            fund.AddBill(bill2);

            var expected = bill2;

            var actual = fund.GetBill(0);

            Assert.Same(expected, actual);
        }

        [Fact]
        public void CanAddMultipleBillsWithSameDate()
        {
            BillFund fund = GetBillFund("Test");
            Bill bill = Bill.From(100, new DateTime(2019, 08, 23));
            Bill bill2 = Bill.From(200, new DateTime(2019, 08, 23));

            fund.AddBill(bill);
            fund.AddBill(bill2);

            Assert.Equal(100 + 200, fund.GetTotalDue());
        }

        [Fact]
        public void TotalBalanceOfBillsIsCorrect()
        {
            BillFund fund = GetBillFund("Test");
            Bill bill = Bill.From(100, new DateTime(2019, 08, 23));
            Bill bill2 = Bill.From(200, new DateTime(2019, 08, 23));
            Bill bill3 = Bill.From(50.75, new DateTime(2019, 08, 23));

            fund.AddBill(bill);
            fund.AddBill(bill2);
            fund.AddBill(bill3);

            var expected = 100 + 200 + 50.75;

            var actual = fund.GetTotalDue();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BalanceIsCorrect()
        {
            BillFund fund = GetBillFund("Test");
            fund.DepositFunds(132.50);
            fund.DepositFunds(500);
            fund.DepositFunds(12.34);

            var expected = 132.50 + 500 + 12.34;

            var actual = fund.Balance;

            Assert.Equal(expected, actual);
        }

        BillFund GetBillFund(string title)
        {
            return new BillFund(title);
        }
    }
}
