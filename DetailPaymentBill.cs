using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace ConsoleApp.NET_Homework_10_1
{
    [Serializable]
    public class DetailPaymentBill : PaymentBill
    {
        public int PaymentWithoutPenalty;
        public int Fine;
        public int TotalAmountDue;

        [XmlIgnore]
        public int paymentWithoutPenalty
        {
            get { return PaymentPerDay * AmountDays; }
            set { PaymentWithoutPenalty = value; }
        }
        [XmlIgnore]
        public int fine
        {
            get { return PenaltyOneDayLatePayment * NumberDaysPaymentDelay; }
            set { Fine = value; }
        }
        [XmlIgnore]
        public int totalAmountDue
        {
            get { return PaymentWithoutPenalty + Fine; }
            set { Fine = value; }
        }
        public DetailPaymentBill() { }

        public DetailPaymentBill(int paymentPerDay, int amountDays, int penaltyOneDayLatePayment, int numberDaysPaymentDelay)
            : base(paymentPerDay, amountDays, penaltyOneDayLatePayment, numberDaysPaymentDelay) { }
    }
}
