using Core.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Conrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T Data ,bool İsSucces) : base(İsSucces)
        {
            Data = Data;
        }

        public DataResult(T Data,string Message, bool İsSucces) : base(Message, İsSucces)
        {
            Data = Data;
        }

        public T Data { get; }
    }
}
