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

using NET_Homework_10_1;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Введіть true, якщо потрібна серіалізація, або false, якщо не потрібна:");
bool isSerializationNeeded = Convert.ToBoolean(Console.ReadLine());

InvoiceForPayment invoiceForPayment = new InvoiceForPayment(100, 10, 50, 2);

InvoiceForPayment.SerializationEnabled = isSerializationNeeded;

// Серіалізація
FileStream fileStream = new FileStream("InvoiceForPayment.json", FileMode.Create);
DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
settings.SerializeReadOnlyTypes = true;
DataContractJsonSerializer data = new DataContractJsonSerializer(typeof(InvoiceForPayment), settings);

    data.WriteObject(fileStream, invoiceForPayment);

fileStream.Close();

// Десеріалізація
fileStream = new FileStream("InvoiceForPayment.json", FileMode.Open);
InvoiceForPayment rez = (InvoiceForPayment)data.ReadObject(fileStream);
Console.WriteLine(rez);
fileStream.Close();

