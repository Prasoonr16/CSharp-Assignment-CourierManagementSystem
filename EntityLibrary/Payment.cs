using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int CourierID { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        // Parameterized constructor
        public Payment(int paymentID, int courierID, double amount, DateTime paymentDate)
        {
            PaymentID = paymentID;
            CourierID = courierID;
            Amount = amount;
            PaymentDate = paymentDate;
        }
    }
}
