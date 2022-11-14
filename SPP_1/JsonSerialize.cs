using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SPP_1
{
    internal class JsonSerialize : ISerialize
    {
        public string Deserialize(TraceResult traceResult)
        {
            throw new NotImplementedException();
        }

        public async void Serialize(TraceResult traceResult)
        {
           using (FileStream fs = new FileStream("data.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<TraceResult>(fs, traceResult);
            }

            using (StreamReader sr = new StreamReader("data.json"))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
    }
}
