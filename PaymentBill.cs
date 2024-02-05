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
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp.NET_Homework_10_1
{
    public class PaymentBill
        {
            //Поля
            public int PaymentPerDay { get; set; }
            public int AmountDays { get; set; }
            public int PenaltyOneDayLatePayment { get; set; }
            public int NumberDaysPaymentDelay { get; set; }

            //Статична властивість для формотування

            public static bool SerializationEnabled { get; set; }
            static PaymentBill()
            {
                SerializationEnabled = false;
            }
            public PaymentBill(int paymentPerDay, int amountDays, int penaltyOneDayLatePayment, int numberDaysPaymentDelay)
            {
                PaymentPerDay = paymentPerDay;
                AmountDays = amountDays;
                PenaltyOneDayLatePayment = penaltyOneDayLatePayment;
                NumberDaysPaymentDelay = numberDaysPaymentDelay;
            }

            public PaymentBill() { }
        }
    }