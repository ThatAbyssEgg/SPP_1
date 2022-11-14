using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_1
{
    internal interface ISerialize
    {
        void Serialize(TraceResult traceResult);
        string Deserialize(TraceResult traceResult);
    }
}
