using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Conrete
{
    public class DataSuccesResult<T> : DataResult<T>
    {
        public DataSuccesResult(T Data, bool İsSucces) : base(Data, true)
        {
        }

        public DataSuccesResult(T Data, string Message, bool İsSucces) : base(Data, Message, true)
        {
        }
    }
}
