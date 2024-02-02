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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NET_Homework_10_1
{
    public sealed class SerializationAttribute:Attribute
    {
        public string Name;
        public SerializationAttribute(string name)
        {
            Name = name;
        }
    }

    public class Converter : JsonConverter<int>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            var attrs = typeToConvert.GetCustomAttributes(typeof(SerializationAttribute), false);
            return attrs.Length > 0;
        }

        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return 0;
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            var attrs = value.GetType().GetCustomAttributes(typeof(SerializationAttribute), false);
            if (attrs.Length > 0 && InvoiceForPayment.SerializationEnabled)
            {
                writer.WriteNumber(Encoding.UTF8.GetBytes((attrs[0] as SerializationAttribute).Name), (int)value);
            }
        }
    }
}
