//Разработать класс "Счет для оплаты".
//В классе предусмотреть следующие поля
//- оплата за день
//- количество дней
//- штраф за один день задержки оплаты
//- количество дней задержки оплаты
//- сумма к оплате без штрафа (вычисляемое поле)
//- штраф (вычисляемое поле)
//- общая сумма к оплате (вычисляемое поле)
//В классе объявить статическое свойство типа bool, значение которого влияет на процесс форматирования
//объектов этого класса. Если значение этого свойства равно true, тогда сериализуется и все поля,
//если false - вычисляемые поля не сериализуются.
//Разработать приложение, в котором необходимо продемонстрировать использование этого класса,
//результаты должны записываться и считываться из файла.

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NET_Homework_10_1
{
    [Serializable]
    [DataContract]
    public class InvoiceForPayment
    {
        [DataMember]
        public int PaymentPerDay { get; set; }
        [DataMember]
        public int AmountDays { get; set; }
        [DataMember]
        public int PenaltyOneDayLatePayment { get; set; }
        [DataMember]
        public int NumberDaysPaymentDelay { get; set; }

        public static bool SerializationEnabled { get; set; }
        [Serialization]
        public int PaymentWithoutPenalty => PaymentPerDay * AmountDays;
        [Serialization]
        public int Fine => PenaltyOneDayLatePayment * NumberDaysPaymentDelay;
        [Serialization]
        public int TotalAmountDue => PaymentWithoutPenalty + Fine;

        public InvoiceForPayment() { }
        public InvoiceForPayment(int paymentPerDay, int amountDays, int penaltyOneDayLatePayment, int numberDaysPaymentDelay)
        {
            PaymentPerDay = paymentPerDay;
            AmountDays = amountDays;
            PenaltyOneDayLatePayment = penaltyOneDayLatePayment;
            NumberDaysPaymentDelay = numberDaysPaymentDelay;
        }

        public override string ToString()
        {
            var result = $"PaymentPerDay: {PaymentPerDay}\n" +
                $"AmountDays: {AmountDays}\n" +
                $"PenaltyOneDayLatePayment {PenaltyOneDayLatePayment} \n" +
                $"NumberDaysPaymentDelay {NumberDaysPaymentDelay}\n";
            if (SerializationEnabled)
            {
                result += $"PaymentWithoutPenalty {PaymentWithoutPenalty}\n" +
                $"Fine {Fine}\n" +
                $"TotalAmountDue {TotalAmountDue}\n";
            }
            return result;
        }
    }

}