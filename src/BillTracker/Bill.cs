using System;

namespace BillTracker
{
    public class Bill : IComparable
    {
        private Bill(double balance, DateTime dueDate, string payee)
        {
            this.balance = balance;
            this.dueDate = dueDate;
            this.payee = payee;
        }

        public static Bill From(double balance, DateTime dueDate)
        {
            return new Bill(balance, dueDate, null);
        }

        public static Bill From(double balance, DateTime dueDate, string payee)
        {
            return new Bill(balance, dueDate, payee);
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
        private double balance;

        public string GetPayee()
        {
            return this.payee;
        }
        private string payee;

        public int CompareTo(object obj)
        {
            return dueDate.CompareTo(((Bill)obj).GetDueDate());
        }
    }
}