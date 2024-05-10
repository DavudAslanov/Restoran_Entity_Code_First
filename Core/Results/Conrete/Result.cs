using Core.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Conrete
{
    public class Result : IResult
    {
        public Result(bool İsSucces)
        {
            İsSucces = İsSucces;
        }

        public Result(string Message, bool İsSucces):this(İsSucces)
        {
            Message= Message;
        }

        public string Message { get; }

        public bool İsSucces { get;}
    }
}
