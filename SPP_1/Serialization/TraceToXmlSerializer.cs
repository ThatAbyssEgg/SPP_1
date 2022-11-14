using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using SPP_1.Tracing;

namespace SPP_1.Serialization
{
    public class TraceToXmlSerializer : ITraceSerializer
    {
        public void Serialize(TraceResult traceResult)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TraceResult));

            using (FileStream fs = new FileStream("data.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, traceResult);
            }

            XmlDocument doc = new XmlDocument();

            doc.Load(@"data.xml");
            doc.Save(Console.Out);
        }
    }
}
