using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Conrete
{
    public class DataErrorResult<T> : DataResult<T>
    {
        public DataErrorResult(T Data, bool İsSucces) : base(Data, false)
        {
        }

        public DataErrorResult(T Data, string Message, bool İsSucces) : base(Data, Message, false)
        {
        }
    }
}
