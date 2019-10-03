using System;

namespace BillTracker
{
    public class Bill : IComparable
    {
        private Bill(double balance, DateTime dueDate)
        {
            this.balance = balance;
            this.dueDate = dueDate;
        }

        public static Bill From(double balance, DateTime dueDate)
        {
            return new Bill(balance, dueDate);
        }

        public DateTime GetDueDate()
        {
            return this.dueDate;
        }
        private DateTime dueDate;

        public double GetBalance()
        {
            return this.balance;
        }

        public int CompareTo(object obj)
        {
            return dueDate.CompareTo(((Bill)obj).GetDueDate());
        }

        private double balance;
    }
}