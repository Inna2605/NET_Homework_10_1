using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp.NET_Homework_10_1
{
    public static class SerializeBill
    {
        public static string SerializeToXml(PaymentBill pb)
        {
            var serializer = new XmlSerializer(typeof(PaymentBill));
            using (var stringWriter = new StringWriter())
            {
                var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true });
                serializer.Serialize(xmlWriter, pb);
                return stringWriter.ToString();
            }
        }

        public static string SerializeToXml(DetailPaymentBill pb)
        {
            var serializer = new XmlSerializer(typeof(DetailPaymentBill));
            using (var stringWriter = new StringWriter())
            {
                var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true });
                serializer.Serialize(xmlWriter, pb);
                return stringWriter.ToString();
            }
        }
    }
}