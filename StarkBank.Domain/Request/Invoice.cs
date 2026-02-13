using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarkBankTest.Domain.Request
{
    public class Invoice
    {
        private int amount;
        private List<Dictionary<string, object>> descriptions;
        private List<Dictionary<string, object>> discounts;
        private List<Dictionary<string, object>> rules;
        private DateTime due;
        private int expiration;
        private double fine;
        private double interest;
        private string name;
        private List<string> tags;
        private string taxID;

        public Invoice(int amount, List<Dictionary<string, object>> descriptions, List<Dictionary<string, object>> discounts, List<Dictionary<string, object>> rules, DateTime due, int expiration, double fine, double interest, string name, List<string> tags, string taxID)
        {
            this.amount = amount;
            this.descriptions = descriptions;
            this.discounts = discounts;
            this.rules = rules;
            this.due = due;
            this.expiration = expiration;
            this.fine = fine;
            this.interest = interest;
            this.name = name;
            this.tags = tags;
            this.taxID = taxID;
        }
    }
}
