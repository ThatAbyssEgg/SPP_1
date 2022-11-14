using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace SPP_1
{
    internal class XMLSerialize : ISerialize
    {
        public string Deserialize(TraceResult traceResult)
        {
            throw new NotImplementedException();
        }

        public async void Serialize(TraceResult traceResult)
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
