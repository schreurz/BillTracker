using System;
using System.Collections;

namespace BillTracker
{
    public class BillFund
    {
        public BillFund(string title)
        {
            Title = title;
            Balance = 0;
            upcomingBills = new SortedList();
            payedBills = new SortedList();
        }

        public void AddBill(Bill bill)
        {
            upcomingBills.Add(bill.GetDueDate(), bill);
        }

        public void PayNextBill()
        {
            Bill nextBill = (Bill)upcomingBills.GetByIndex(0);
            upcomingBills.RemoveAt(0);
            Balance -= nextBill.GetBalance();
            payedBills.Add(nextBill.GetDueDate(), nextBill);
        }

        public void DepositFunds(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be a positive number");
            }
            this.Balance += amount;
        }

        public Bill GetBill(int index)
        {
            return (Bill)upcomingBills.GetByIndex(0);
        }

        public double GetTotalDue()
        {
            double totalDue = 0;
            foreach (Bill bill in upcomingBills)
            {
                totalDue += bill.GetBalance();
            }

            return totalDue;
        }

        public string Title
        {
            get;
            set;
        }

        public double Balance
        {
            get;
            private set;
        }

        private SortedList upcomingBills;
        private SortedList payedBills;
    }
}