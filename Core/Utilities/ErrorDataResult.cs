using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class ErrorDataResult<T> : DataResult<T>
    {

        public ErrorDataResult(T data) : base(data, true)
        {
        }

        public ErrorDataResult(T data, string messages) : base(data, true, messages)
        {
        }
        public ErrorDataResult(string messages) : base(default, true, messages)
        {
        }
        public ErrorDataResult() : base(default, true)
        {

        }
    }
}
