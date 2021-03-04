using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message):base(data,true,message)
        {
            //Data ve mesaj verilir 
        }

        public SuccessDataResult(T data):base(data,true)
        {
            //Data verilip mesaj verilmez
        }
        public SuccessDataResult(string message):base(default,true,message)
        {
            //sadece mesaj
        }
        public SuccessDataResult():base(default,true)
        {
            //hiçbir şey verilmez
        }
    }
}
