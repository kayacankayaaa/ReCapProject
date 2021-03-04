using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
            //Data ve mesaj verilir 
        }

        public ErrorDataResult(T data) : base(data, false)
        {
            //Data verilip mesaj verilmez
        }
        public ErrorDataResult(string message) : base(default, false, message)
        {
            //sadece mesaj
        }
        public ErrorDataResult() : base(default, false)
        {
            //hiçbir şey verilmez
        }
    }
}
