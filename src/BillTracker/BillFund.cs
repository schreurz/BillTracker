using System;
using System.Collections.Generic;

namespace BillTracker
{
    public class BillFund
    {
        public BillFund(string title)
        {
            Title = title;
            Balance = 0;
            upcomingBills = new List<Bill>();
            payedBills = new List<Bill>();
        }

        public void AddBill(Bill bill)
        {
            upcomingBills.Add(bill);
            upcomingBills.Sort();
        }

        public HashSet<string> GetPayees()
        {
            HashSet<string> payees = new HashSet<string>();
            foreach (Bill bill in this.upcomingBills)
            {
                payees.Add(bill.GetPayee());
            }
            foreach (Bill bill in this.payedBills)
            {
                payees.Add(bill.GetPayee());
            }

            return payees;
        }

        public List<Bill> GetBillsByPayee(string payee)
        {
            List<Bill> bills = new List<Bill>();
            foreach (Bill bill in this.upcomingBills)
            {
                if (bill.GetPayee() == payee)
                {
                    bills.Add(bill);
                }
            }

            bills.Sort();

            return bills;
        }

        public void PayBill(Bill bill)
        {
            if (upcomingBills.Remove(bill))
            {
                Balance -= bill.GetBalance();
                payedBills.Add(bill);
            }
        }

        public void PayNextBill()
        {
            Bill nextBill = upcomingBills[0];
            upcomingBills.RemoveAt(0);
            Balance -= nextBill.GetBalance();
            payedBills.Add(nextBill);
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
            return upcomingBills[index];
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

        private List<Bill> upcomingBills;
        private List<Bill> payedBills;
    }
}