using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Conrete
{
    public class ErrorResult : Result
    {
        public ErrorResult(bool İsSucces) : base(false)
        {
        }

        public ErrorResult(string Message, bool İsSucces) : base(Message, false)
        {
        }
    }
}
