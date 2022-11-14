using System;
using System.Text.Json;
using System.IO;
using SPP_1.Tracing;

namespace SPP_1.Serialization
{
    public class TraceToJsonSerializer : ITraceSerializer
    {
        public void Serialize(TraceResult traceResult)
        {
            using (FileStream fileStream = new FileStream("data.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fileStream, traceResult, new JsonSerializerOptions { WriteIndented = true });
            }

            using (StreamReader streamReader = new StreamReader("data.json"))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
        }
    }
}
