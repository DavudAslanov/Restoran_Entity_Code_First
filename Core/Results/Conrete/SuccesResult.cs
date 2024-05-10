using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results.Conrete
{
    public class SuccesResult : Result
    {
        public SuccesResult(bool İsSucces) : base(true)
        {
        }

        public SuccesResult(string Message, bool İsSucces) : base(Message, true)
        {
        }
    }
}
