using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Domain.Common
{
    public class ResponseDto<T>
    {
        public ResponseDto(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = new List<ErrorDto>();
            Data = data;
        }

        public ResponseDto(T data, string message)
        {
            Succeeded = true;
            Message = message;
            Errors = new List<ErrorDto>();
            Data = data;
        }

        public ResponseDto( string message,List<ErrorDto> errors)
        {
            Succeeded = false;
            Message = message;
            Errors = errors;
            Data = default;
        }


        public ResponseDto(string message,bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
            Errors = new List<ErrorDto>();
            Data = default;
        }

        public ResponseDto()
        {
            Errors= new List<ErrorDto>();
        }



        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<ErrorDto> Errors { get; set; }
        public T? Data { get; set; }
    }
}
